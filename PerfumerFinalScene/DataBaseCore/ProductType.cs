using System.ComponentModel.DataAnnotations;

namespace PerfumerFinalScene.DataBaseCore
{
    public class ProductType
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public ProductType()
        {
            
        }
    }
}
