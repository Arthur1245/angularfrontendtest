using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingService.DTO
{
    public class FilmDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Length { get; set; } //? TimeSpan
        public DateTime ReleaseYear { get; set; }
        public int RentalDuration { get; set; }
        public int RentalPrice { get; set; }
        public int PurchasePrice { get; set; }
        public string Rating { get; set; } //bv 18+ (leeftijdscategory)
        public int Review { get; set; }
        public List<Category> Category { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Director> Directors { get; set; }
    }
}
