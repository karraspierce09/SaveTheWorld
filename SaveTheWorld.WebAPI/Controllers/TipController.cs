using Microsoft.AspNet.Identity;
using SaveTheWorld.Models.Tip;
using SaveTheWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SaveTheWorld.WebAPI.Controllers
{
    [Authorize]
    public class TipController : ApiController
    {
        private TipService CreateTipService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var tipService = new TipService(userID);
            return tipService;
        }


        public IHttpActionResult Get()
        {
            TipService tipService = CreateTipService();
            var tips = tipService.GetTips();
            return Ok(tips);
        }

        public IHttpActionResult Get(int id)
        {
            TipService tipService = CreateTipService();
            var tip = tipService.GetTipByID(id);
            return Ok(tip);
        }

        public IHttpActionResult Post(TipCreate tip)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTipService();

            if (!service.CreateTip(tip))
                return InternalServerError();

            return Ok("Tip has been created");
        }

        public IHttpActionResult Put(TipEdit tip, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTipService();

            if (!service.UpdateTip(tip, id))
                return InternalServerError();

            return Ok("This has been updated");
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateTipService();

            if (!service.DeleteTip(id))
                return InternalServerError();

            return Ok("Tip has been deleted");
        }

    }
}
