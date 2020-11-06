using SaveTheWorld.Data;
using SaveTheWorld.Models;
using SaveTheWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace SaveTheWorld.WebAPI.Controllers
{
    public class OwnerController
    {
        public IHttpActionResult Get()
        {
            OwnerService ownerService = CreateOwnerService();
            var users = ownerService.Getuser();
            return Ok(users);
        }

        public IHttpActionResult Post(OwnerCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOwnerService();

            if (!service.CreateOwner(user))
                return InternalServerError();

            return Ok();

        }


        private OwnerService CreateOwnerService()
        {
            var userId = Guid.Parse(Owner.Identity.GetUserId());
            var userService = new OwnerService(userId);
            return userService;

        }
    }
}
