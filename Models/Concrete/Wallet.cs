using System.ComponentModel.DataAnnotations;

namespace HotWalletsTrialApp.Models.Concrete
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

        public ICollection<WalletAuthorization>? AuthorizationList { get; set; }

        public ICollection<WalletTransaction>? TransactionList { get; set; }
        #endregion
    }
}
