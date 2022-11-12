using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotWalletsTrialApp.Common;

namespace HotWalletsTrialApp.Models.Concrete;
public class Account : Entity
{
  #region Properties
  [Required]
  [DataType(DataType.Text, ErrorMessage = "{0} is invalid.")]
  [Range(5, 17, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
  public string FirstName { get; set; }

  [Required]
  [DataType(DataType.Text, ErrorMessage = "{0} is invalid.")]
  [Range(5, 17, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
  public string LastName { get; set; }

  [Required]
  [DataType(DataType.EmailAddress, ErrorMessage = "{0} address is invalid.")]
  [Range(5, 27, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
  public string Email { get; set; }

  [Required]
  [Range(5, 11, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
  public string Username { get; set; }

  [Required]
  [DataType(DataType.Password, ErrorMessage = "{0} is invalid.")]
  [Range(5, 11, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
  public string Password { get; set; }

  [NotMapped]
  [Compare(nameof(Password), ErrorMessage = "Password and confirmation password did not match.")]
  public string PasswordConfirm { get; set; }

  [NotMapped]
  public string FullName => String.Format(Consts.FormatFullName, FirstName, LastName);
  #endregion

  #region Relationships
  public ICollection<WalletAuthorization>? AuthorizationList { get; set; }
  #endregion
}