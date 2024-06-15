using System.ComponentModel.DataAnnotations;

namespace PerfumerFinalScene.DataBaseCore
{
    public class User
    {
        [Key]
        public string login { get; set; }
        public string password { get; set; }
        public int roleId { get; set; }

        public User()
        {
            
        }
    }
}
