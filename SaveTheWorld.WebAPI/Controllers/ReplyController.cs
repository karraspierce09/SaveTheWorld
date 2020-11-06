using Microsoft.AspNet.Identity;
using SaveTheWorld.Models;
using SaveTheWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SaveTheWorld.WebAPI.Controllers
{   // Add authorization attribute tag, add method to create ReplyService, add endpoints
    [Authorize]
    public class ReplyController : ApiController
    {
        // Create: creating ReplyService to allow us to use our ReplyService in our methods
        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }

        // Post method: Create method - to make a reply
        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.CreateReply(reply))
                return InternalServerError();

            return Ok("Reply has been created");
        }

        // Get All method: Read all - view all replies for a user
        public IHttpActionResult Get()
        {
            ReplyService replyService = CreateReplyService();
            var replies = replyService.GetReplies();
            return Ok(replies);
        }

        // Get by ID method: Read single - view a reply by its ReplyId. Attached code is in ReplyService.cs
        public IHttpActionResult Get(int id)
        {
            ReplyService replyService = CreateReplyService();
            var reply = replyService.GetReplyById(id);
            return Ok(reply);
        }

        // Put method: Update - For updating/editing a reply
        // added int id and id parameters to make sure id cant be edited
        public IHttpActionResult Put(ReplyEdit reply, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.UpdateReply(reply, id))
                return InternalServerError();

            return Ok("Reply has been updated");
        }

        // Delete method: Delete a reply by its id. More code for this method to work is in ReplyService.cs
        public IHttpActionResult Delete(int id)
        {
            var service = CreateReplyService();

            if (!service.DeleteReply(id))
                return InternalServerError();

            return Ok("Reply has been deleted");
        }

    }
}
