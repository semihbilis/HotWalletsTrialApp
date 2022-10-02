using HotWalletsTrialApp.Models.DataAuthorization;
using HotWalletsTrialApp.Models.DataWallet;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotWalletsTrialApp.Models.DataAccount
{
    public class Account : Entity
    {
        #region Properties
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        #endregion

        #region Relationships
        public int WalletId { get; set; }
        public Wallet Wallet { get; set; }

        public ICollection<Authorization> AuthorizationList { get; set; }
        #endregion
    }
}
