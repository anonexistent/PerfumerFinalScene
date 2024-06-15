using System.ComponentModel.DataAnnotations;

namespace PerfumerFinalScene.DataBaseCore
{
    public class BasketList
    {
        [Key]
        public int id { get; set; }
        public int basketId { get; set; }
        public int productId { get; set; }

        public BasketList()
        {
            
        }
    }
}
