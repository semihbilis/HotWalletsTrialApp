using System.ComponentModel.DataAnnotations;

namespace HotWalletsTrialApp.Models.Concrete
{
    public class WalletTransaction : Entity
    {
        #region Properties
        [Required]
        public bool IsIncrease { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        #endregion

        #region Relationships
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion
    }
}
