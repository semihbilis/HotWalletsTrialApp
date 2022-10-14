using System.ComponentModel.DataAnnotations;

namespace HotWalletsTrialApp.Models.Concrete
{
    public class WalletAuthorization : Entity
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
