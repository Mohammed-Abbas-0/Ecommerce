using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Tickets.Data;
using Tickets.Data.Base;

namespace Tickets.Models
{
    public class Movie:IEntity
    {
        [Key]
       // public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public bool? Deleted { get; set; }
        //public DateTime? DeletedOn { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        public List<ActorMovie> ActorMovies { get; set; }

        //Cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
