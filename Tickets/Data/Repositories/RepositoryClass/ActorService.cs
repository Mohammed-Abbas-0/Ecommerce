using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Data.Repositories.IRepositoryInterface;
using Tickets.DatabaseContext;
using Tickets.Models;

namespace Tickets.Data.Repositories.RepositoryClass
{
    public class ActorService : IActor
    {
        private readonly AppDbContext db;
        public ActorService(AppDbContext _db) => db = _db;
        
        public void Add(Actor actor)
        {
            db.Actors.Add(actor);
            db.SaveChanges();
        }

        public async Task<bool> Delete(int Id)
        {
            Actor actor = await db.Actors.Where(idx=>idx.Id == Id).FirstOrDefaultAsync();
            actor.Deleted = true;
            actor.DeletedOn = DateTime.Now;
            return db.SaveChanges() > 0 ? true:false;
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            List<Actor> actors =
                await db.Actors.Where(idx => idx.Deleted != true).ToListAsync();
            return actors;
        }

        public async Task<Actor> GetById(int Id)
        {
            Actor actor = await db.Actors.Where(idx=>idx.Id == Id && idx.Deleted !=true).FirstOrDefaultAsync();
            return actor;
        }

        public Task<Actor> Update(int Id, Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
