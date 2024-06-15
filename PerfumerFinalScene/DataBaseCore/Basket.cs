using System;
using System.ComponentModel.DataAnnotations;

namespace PerfumerFinalScene.DataBaseCore
{
    public class Basket
    {
        [Key]
        public int id { get; set; }
        public string userId { get; set; }
        public DateTime date { get; set; }
        public int payId { get; set; }
        public int shopId { get; set; }
        public int statusId { get; set; }

        public Basket()
        {
            
        }
    }
}
