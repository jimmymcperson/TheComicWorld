using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheComicWorld.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        private ApplicationDbContext context;
        public EFReviewRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Review> Reviews => context.Reviews;

        public void SaveReview(Review review)
        {
            if (review.ReviewID == 0)
            {
                context.Reviews.Add(review);
            }
            else
            {
                Review dbEntry = context.Reviews
                    .FirstOrDefault(r => r.ReviewID == review.ReviewID);
                if (dbEntry != null)
                {
                    dbEntry.ReviewID = review.ReviewID;
                    dbEntry.UserID = review.UserID;
                    dbEntry.ReviewText = review.ReviewText;
                    dbEntry.ProductID = review.ProductID;
                }
            }
            context.SaveChanges();
        }

        public Review DeleteReview(int reviewID)
        {
            Review dbEntry = context.Reviews
                .FirstOrDefault(p => p.ReviewID == reviewID);
            if (dbEntry != null)
            {
                context.Reviews.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
