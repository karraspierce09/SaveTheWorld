using SaveTheWorld.Data;
using SaveTheWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaveTheWorld.Services
{
    // The service layer is how our application interacts with the database. This section will push and pull replies from the database.
    // These methods get called in the ReplyController
    // Add code, add references to .Services from .Data and .Models, add CRUD, add using statements
    public class ReplyService
{

    private readonly Guid _userId;  // 

    public ReplyService(Guid userId)    // edited class name
    {
        _userId = userId;
    }

    // Create: Create a reply
    public bool CreateReply(ReplyCreate model)    // edited naming conventions
    {
            var entity =
                new Reply()
                {
                    Id = _userId.ToString(),
                    ReplyId = model.ReplyId,
                    ReplyText = model.ReplyText,
                    TipId = model.TipId,
                    ModifiedUtc = null,
                    CreatedUtc = DateTime.Now
                    //Owner = model.Owner,
                    
            };

        using (var ctx = new ApplicationDbContext())
        {
            ctx.Replies.Add(entity);
            return ctx.SaveChanges() == 1;
        }
    }

    // Read All: This method will allow us to see all the replies that belong to a specific user.
    public IEnumerable<ReplyListItem> GetReplies()     // edited naming conventions
    {
        using (var ctx = new ApplicationDbContext())
        {
            var query =
                ctx
                    .Replies
                    .Where(e => e.Id == _userId.ToString())
                    .Select(
                        e =>
                            new ReplyListItem
                            {
                                ReplyId = e.ReplyId,
                                ReplyText = e.ReplyText,
                                CreatedUtc = e.CreatedUtc
                            }
                    );

            return query.ToArray();
        }
    }

    // Read Single: View a user's reply by its ReplyId. This is made after adding code to the ReplyController.cs
    public ReplyDetail GetReplyById(int id)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Replies
                    .Single(e => e.ReplyId == id);  // Change to this after adding the Owner class: .Single(e => e.ReplyId == id && e.OwnerId == _userId);
            return
                new ReplyDetail
                {
                    ReplyId = entity.ReplyId,
                    ReplyText = entity.ReplyText,
                       Tip = entity.Tip,
                        Author = entity.Owner, // this was entity.author, changed to entity.owner
                        CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };
        }
    }

    // Update: Update/edit a reply
    public bool UpdateReply(ReplyEdit model, int id)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Replies
                    .Single(e => e.ReplyId == id);     //.Single(e => e.ReplyId == model.ReplyId);   // Once Owner is added: .Single(e => e.ReplyId == id && e.OwnerId == _userId); // OG: .Single(e => e.ReplyId == model.ReplyId && e.OwnerId == _userId);

            entity.ReplyText = model.ReplyText;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return ctx.SaveChanges() == 1;
        }
    }

    // Delete: Deleting a reply by its id
    public bool DeleteReply(int replyId)
    {
        using (var ctx = new ApplicationDbContext())
        {
            var entity =
                ctx
                    .Replies
                    .Single(e => e.ReplyId == replyId);  // .Single(e => e.ReplyId == replyId && e.OwnerId == _userId);

            ctx.Replies.Remove(entity);

            return ctx.SaveChanges() == 1;
        }
    }

}
}