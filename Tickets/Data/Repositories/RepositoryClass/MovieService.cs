using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tickets.Data.Base;
using Tickets.Data.Repositories.IRepositoryInterface;
using Tickets.DatabaseContext;
using Tickets.Models;

namespace Tickets.Data.Repositories.RepositoryClass
{
    public class MovieService//:IEntityBase<Movie>  ,IMovie
    {
        private readonly AppDbContext db;
        public MovieService(AppDbContext _db) => db = _db;

      
    }
}
