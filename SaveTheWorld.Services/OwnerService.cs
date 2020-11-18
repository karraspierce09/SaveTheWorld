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