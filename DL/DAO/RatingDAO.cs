using System;
using ASP.NET_aplikacija.DL.Entities;
using ASP.NET_aplikacija.Areas.Identity.Data;

namespace ASP.NET_aplikacija.DL.DAO
{
    public class RatingDAO
    {
        private readonly AppDbContext _context;
        // ova varijabla varijabla
        // predstavlja konekciju sa bazom podataka

        public RatingDAO(AppDbContext context)
        {
            _context = context;
        }

        public void SaveRatings(List<RatingEntity> ratings)
        {
            _context.Ratings.AddRange(ratings);
            _context.SaveChanges();
        }
    }
}

// klasa koja sadrzi metode za pristup bazi podataka,
// npr. SaveRatings koja cuva ocene u bazu,
// GetRatings koja vraca ocene iz baze itd.