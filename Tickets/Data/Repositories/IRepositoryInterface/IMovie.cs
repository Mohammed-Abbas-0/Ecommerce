using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Data.Base;
using Tickets.Models;

namespace Tickets.Data.Repositories.IRepositoryInterface
{
    public interface IMovie : IEntityBase<Movie>
    {
        Task<List<Movie>> GetAllMovies();
        //Task<Movie> GetMovieByIdAsync(int id);
        //Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        //Task AddNewMovieAsync(NewMovieVM data);
        //Task UpdateMovieAsync(NewMovieVM data);
    }
}
