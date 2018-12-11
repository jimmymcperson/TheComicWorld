using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheComicWorld.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public string ReviewText { get; set; }
    }
}
