using SaveTheWorld.Data;
using SaveTheWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SaveTheWorld.Services
{
    public class OwnerService
    {
        private readonly Guid _userId;
        public OwnerService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateUser(OwnerCreate model)
        {
            var entity =
                new Owner()
                {
                    OwnerId = _userId, // added this in
                    //Id = model.OwnerID, don't need this here
                    Name = model.Name,
                    Email = model.Email
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<OwnerListItem> GetUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Select(
                        e =>
                        new OwnerListItem
                        {
                            Id = e.OwnerId,
                            Name = e.Name,
                            Email = e.Email
                        }
                   );
                return query.ToArray();
            }
        }
    }
}