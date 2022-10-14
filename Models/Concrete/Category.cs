using System.ComponentModel.DataAnnotations;

namespace HotWalletsTrialApp.Models.Concrete
{
    public class Category : Entity
    {
        #region Properties
        [Required]
        public string Name { get; set; }
        public string Icon { get; set; } = string.Empty;
        #endregion

        #region Relationships
        public ICollection<WalletTransaction>? WalletTransactionList { get; set; }
        #endregion
    }
}
