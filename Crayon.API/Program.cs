using Crayon.API.DB;
using Crayon.API.Endpoints;
using Crayon.API.Services;
using Crayon.API.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

builder.Services.AddSingleton<ImUserService>(new UserService());
builder.Services.AddSingleton<ImSoftwareServiceService>(new SoftwareServiceService());
builder.Services.AddSingleton<ImAccountSoftwareServiceService>(new AccountSoftwareServiceService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

DbMock.Seed();

UserEndpoints.Register(app);
SoftwareServiceEndpoints.Register(app);
LicenceEndpoints.Register(app);

app.Run();
