using SaveTheWorld.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
                    //Id = model.Id,
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
                            Id = e.Id,
                            Name = e.Name,
                            Email = e.Email
                        }
                   );
                return query.ToArray();
            }
        }
    }
}

