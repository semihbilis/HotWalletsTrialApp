using HotWalletsTrialApp.Models.DataCategory;
using HotWalletsTrialApp.Models.DataWallet;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotWalletsTrialApp.Models.DataWalletTransaction
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
