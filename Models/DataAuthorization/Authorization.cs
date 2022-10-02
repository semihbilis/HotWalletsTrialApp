using HotWalletsTrialApp.Models.DataAccount;
using HotWalletsTrialApp.Models.DataWallet;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotWalletsTrialApp.Models.DataAuthorization
{
    public class Authorization : Entity
    {
        #region Properties
        [Required]
        public AuthorizationType AuthorizationType { get; set; }
        #endregion

        #region Relationships
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }
        #endregion
    }
}
