using System.ComponentModel.DataAnnotations;

namespace PerfumerFinalScene.DataBaseCore
{
    public class UserProfile
    {
        [Key]
        public int id { get; set; }
        public string userId { get; set; }
        public string photo { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        public int age { get; set; }
        public double totalMoney { get; set; }

        public UserProfile()
        {
            
        }
    }
}
