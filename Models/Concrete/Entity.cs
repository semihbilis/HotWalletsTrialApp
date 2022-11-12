using HotWalletsTrialApp.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using HotWalletsTrialApp.Common;

namespace HotWalletsTrialApp.Models.Concrete;
public abstract class Entity : IEntity
{
  #region Properties
  [Key]
  public int Id { get; set; }

  [Required]
  public DateTime CreateDate { get; private set; } = DateTime.Now;

  public DateTime? UpdateDate { get; set; }

  public DateTime? EndDate { get; set; }

  [NotMapped]
  public bool IsDeleted => EndDate == null ? false : EndDate < DateTime.Now;
  #endregion

  #region Relationships
  [Required]
  public int CreatedByAccountId { get; private set; } = Program.CurrentAccount?.Id ?? Consts.DefaultCreatedAccountId;
  #endregion
}