using System.ComponentModel.DataAnnotations.Schema;

namespace Commcare.Integration.Entities
{
    [Table("pull_history")]
    public class PullHistory : Entity
    {
        [Column("pull_date")]
        public DateTime PullDate { get; set; }
        [Column("pull_status")]
        public string? PullStatus { get; set; }       
    }
}
