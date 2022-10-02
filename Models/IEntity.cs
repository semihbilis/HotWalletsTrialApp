using System.ComponentModel.DataAnnotations;

namespace HotWalletsTrialApp.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        DateTime EndDate { get; set; }
        int AccountId { get; set; }
    }
}
