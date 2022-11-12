using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotWalletsTrialApp.Models.Abstract;
public interface IEntity
{
  #region Properties
  int Id { get; set; }
  DateTime CreateDate { get; }
  DateTime? UpdateDate { get; set; }
  DateTime? EndDate { get; set; }

  bool IsDeleted { get; }
  #endregion

  #region Relationships
  int CreatedByAccountId { get; }
  #endregion
}