using System.ComponentModel.DataAnnotations.Schema;

namespace HotWalletsTrialApp.Models.Abstract
{
    public interface IEntity
    {
        #region Properties
        int Id { get; set; }
        DateTime CreateDate { get; set; }
        DateTime? UpdateDate { get; set; }
        DateTime? EndDate { get; set; }
        #endregion

        #region Relationships
        int CreateAccountId { get; set; }
        #endregion
    }
}
