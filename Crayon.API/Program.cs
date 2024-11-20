using Crayon.API.DB;
using Crayon.API.Model;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

DbMock.Seed();

app.MapGet("/useraccounts", (ClaimsPrincipal user) =>
{
    var bearerId = user.Claims.First(x => x.Type == "jti").Value;

    return DbMock.Accounts.Where(x => x.BearerId == bearerId).Select(x => x.Name);
})
.RequireAuthorization();

app.MapGet("/softwareservices", (ClaimsPrincipal user) =>
{
    var bearerId = user.Claims.First(x => x.Type == "jti").Value;

    return DbMock.SoftwareServices.Select(x => x.Name);
})
.RequireAuthorization();

app.MapPost("/ordersoftwarelicence", (ClaimsPrincipal user, int serviceId, DateTime validTo) =>
{
    var bearerId = user.Claims.First(x => x.Type == "jti").Value;

    var softwareService = DbMock.SoftwareServices.First(x => x.Id == serviceId);

    var licence = new SoftwareServiceLicence
    {
        Id = DbMock.SoftwareServiceInstances.Max(x => x.Id) + 1,
        SoftwareService = softwareService,
        ValidTo = validTo
    };
    DbMock.SoftwareServiceInstances.Add(licence);

    DbMock.AccountServices.First(x => x.Account.BearerId == bearerId).Licences.Add(licence);
})
.RequireAuthorization();

app.MapGet("/getpurchasedlicences", (ClaimsPrincipal user) =>
{
    var bearerId = user.Claims.First(x => x.Type == "jti").Value;

    return DbMock.AccountServices.First(x => x.Account.BearerId == bearerId).Licences;
})
.RequireAuthorization();

app.MapPost("/cancelsoftware", (ClaimsPrincipal user, int serviceId) =>
{
    var bearerId = user.Claims.First(x => x.Type == "jti").Value;

    DbMock.AccountServices.First(x => x.Account.BearerId == bearerId)
    .Licences.Where(x => x.SoftwareService.Id == serviceId)
    .ToList()
    .ForEach(x => x.Status = false);
})
.RequireAuthorization();

app.MapPost("/extendlicence", (ClaimsPrincipal user, int licenceId, DateTime validTo) =>
{
    var bearerId = user.Claims.First(x => x.Type == "jti").Value;

    DbMock.AccountServices.First(x => x.Account.BearerId == bearerId)
    .Licences.First(x => x.Id == licenceId).ValidTo = validTo;
})
.RequireAuthorization();

app.Run();
