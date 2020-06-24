using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FeedbackDao
    {
        OnlineShopDbContext db = null;

        public FeedbackDao()
        {
            db = new OnlineShopDbContext();
        }
        public int InsertFeedback(Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }
    }
}
