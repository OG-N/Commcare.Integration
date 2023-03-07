using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commcare.Integration.Entities
{
    [Table("app_list")]
    public class AppDetail: Entity
    {
        [Column("app_name")]
        public string? AppName { get; set; }
        [Column("app_id")]
        public string? AppId { get; set; }
    }
}
