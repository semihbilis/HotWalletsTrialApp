using HotWalletsTrialApp.Models.DataWalletTransaction;
using System.ComponentModel.DataAnnotations;

namespace HotWalletsTrialApp.Models.DataCategory
{
    public class Category : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Icon { get; set; } = string.Empty;

        public ICollection<WalletTransaction> WalletTransactionList { get; set; }
    }
}
