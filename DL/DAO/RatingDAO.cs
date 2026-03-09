using System;
using ASP.NET_aplikacija.DL.Entities;
using ASP.NET_aplikacija.Areas.Identity.Data;

namespace ASP.NET_aplikacija.DL.DAO
{
    public class RatingDAO
    {
        private readonly AppDbContext _context;

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
