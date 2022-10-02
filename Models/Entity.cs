using System.ComponentModel.DataAnnotations;

namespace HotWalletsTrialApp.Models
{
    public class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]
        public int AccountId { get; set; }
    }
}
