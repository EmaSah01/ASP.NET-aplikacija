using ASP.NET_aplikacija.Entities;
using ASP.NET_aplikacija.Data;
using System;

namespace ASP.NET_aplikacija.DAO
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
