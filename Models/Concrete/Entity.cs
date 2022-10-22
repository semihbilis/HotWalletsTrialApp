using HotWalletsTrialApp.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotWalletsTrialApp.Models.Concrete
{
    public abstract class Entity : IEntity
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? EndDate { get; set; }

        [NotMapped]
        public bool IsDeleted => EndDate == null ? false : EndDate < DateTime.Now;
        #endregion

        #region Relationships
        public int CreateAccountId { get; set; }
        #endregion
    }
}
