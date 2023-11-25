using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Models;

namespace Tickets.Data.Repositories.IRepositoryInterface
{
    public interface IActor
    {
        public Task<IEnumerable<Actor>> GetAll();
        public  Task<Actor> GetById(int Id);
        public void Add(Actor actor);
        public Task<Actor> Update(int Id,Actor actor);
        public Task<bool> Delete(int Id);
    }
}
