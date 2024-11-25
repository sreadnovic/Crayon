﻿using Crayon.API.DB;
using Crayon.API.Extensions;
using Crayon.API.Model;
using Crayon.API.Services.Contracts;
using System.Security.Claims;

namespace Crayon.API.Services
{
    public class SoftwareServiceService : ImSoftwareServiceService
    {
        public void CancelSoftwareSeervice(ClaimsPrincipal user, int serviceId)
        {
            var softwareServices = DbMock.AccountServices.First(x => x.Account.BearerId == user.GetBearerId())
                .Licences.Where(x => x.SoftwareService.Id == serviceId);

            if (softwareServices is null || !softwareServices.Any()) throw new ArgumentException($"User does not use services with id {serviceId}");

            softwareServices.ToList().ForEach(x => x.Status = false);
        }

        public List<SoftwareService> GetAllSoftwareServices(ClaimsPrincipal user)
         => DbMock.SoftwareServices;
    }
}
