using System.ComponentModel.DataAnnotations;

namespace PerfumerFinalScene.DataBaseCore
{
    public class Role
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public Role()
        {
            
        }
    }
}
