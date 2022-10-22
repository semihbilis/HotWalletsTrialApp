using System.ComponentModel.DataAnnotations;

namespace HotWalletsTrialApp.Models.Concrete
{
    public class Account : Entity
    {
        #region Properties
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        #endregion

        #region Relationships
        public int? WalletId { get; set; }
        public Wallet? Wallet { get; set; }

        public ICollection<WalletAuthorization>? AuthorizationList { get; set; }
        #endregion
    }
}
