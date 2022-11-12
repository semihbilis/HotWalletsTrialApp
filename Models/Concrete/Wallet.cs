using HotWalletsTrialApp.Common;
using System.ComponentModel.DataAnnotations;

namespace HotWalletsTrialApp.Models.Concrete;
public class Wallet : Entity
{
  #region Properties
  [Required]
  public string Name { get; set; } = Consts.DefaultWalletName;
  public string Icon { get; set; } = string.Empty;
  #endregion

  #region Relationships
  public ICollection<WalletAuthorization>? AuthorizationList { get; set; }

  public ICollection<WalletTransaction>? TransactionList { get; set; }
  #endregion
}