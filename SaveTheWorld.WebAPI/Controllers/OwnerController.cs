using Microsoft.AspNet.Identity;
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
    [Authorize]
    public class OwnerController : ApiController
    {


        private OwnerService CreateOwnerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var userService = new OwnerService(userId);
            return userService;
        }
    }
}