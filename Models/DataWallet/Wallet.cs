using HotWalletsTrialApp.Models.DataAccount;
using HotWalletsTrialApp.Models.DataAuthorization;
using HotWalletsTrialApp.Models.DataWalletTransaction;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotWalletsTrialApp.Models.DataWallet
{
    public class Wallet : Entity
    {
        #region Properties
        [Required]
        public string Name { get; set; }
        public string Icon { get; set; } = string.Empty;
        #endregion

        #region Relationships
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public ICollection<Authorization> AuthorizationList { get; set; }

        public ICollection<WalletTransaction> TransactionList { get; set; }
        #endregion
    }
}
