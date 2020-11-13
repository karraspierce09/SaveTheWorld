using SaveTheWorld.Data;
using SaveTheWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveTheWorld.Services
{

    public class TipService
    {
        private readonly Guid _userID;
        public TipService(Guid userID)
        {
            _userID = userID;
        }


        public bool CreateTip(TipCreate model)
         {
             var entity =
                 new Tip()
                 {
                     OwnerId = _userID,
                     TipId = model.TipId,
                     TipText = model.TipText,
                     Title = model.Title
                 };
             using (var ctx = new ApplicationDbContext())
             {
                 ctx.Tips.Add(entity);
                 return ctx.SaveChanges() == 1;
             }
         }
        

        public IEnumerable<TipListItems> GetTips()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Tips
                   .Where(e => e.OwnerId == _userID)
                    .Select(
                        e =>
                        new TipListItems
                        {
                            Title = e.Title,
                            TipId = e.TipId,
                            TipText = e.TipText
                        });
                return query.ToArray();
            }
        }

        public TipDetail GetTipByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Tips
                    .Single(e => e.TipId == id && e.OwnerId == _userID);
                return
                    new TipDetail
                    {
                        TipId = entity.TipId,
                        TipText = entity.TipText,
                        Title = entity.Title,
                        OwnerId = entity.OwnerId
                        //Owner = entity.Owner
                    };
            }
        }

        public bool UpdateTip(TipEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Tips

                    .Single(e => e.TipId == id && e.OwnerId == _userID);


                entity.TipText = model.TipText;

                entity.Title = model.Title;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTip(int tipID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Tips
                    .Single(e => e.TipId == tipID && e.OwnerId == _userID);

                ctx.Tips.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
