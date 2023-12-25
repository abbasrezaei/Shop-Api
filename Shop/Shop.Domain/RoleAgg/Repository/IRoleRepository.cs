using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.RoleAgg.Repository
{
    public class IRoleRepository : IBaseRepository<Role>
    {
        public void Add(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRange(ICollection<Role> entities)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<Role, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<Role, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Role? Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Role?> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Role?> GetTracking(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
