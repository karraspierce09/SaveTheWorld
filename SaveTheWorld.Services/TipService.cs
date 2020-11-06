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
                    OwnerID = _userID,
                    TipID = model.TipID,
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
                   .Where(e => e.OwnerID == _userID)
                    .Select(
                        e =>
                        new TipListItems
                        {
                            Title = e.Title,
                            TipID = e.TipID,
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
                    .Single(e => e.TipID == id && e.OwnerID == _userID);
                return
                    new TipDetail
                    {
                        TipID = entity.TipID,
                        TipText = entity.TipText,
                        Category = entity.Category,
                        Title = entity.Title,
                        Owner = entity.Owner
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

                    .Single(e => e.TipID == id && e.OwnerID == _userID);
                    //.Single(e => e.TipID == model.TipID && e.OwnerID == _userID);

                entity.TipText = model.TipText;
                entity.TipID = model.TipID;
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
                    .Single(e => e.TipID == tipID && e.OwnerID == _userID);

                ctx.Tips.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
