using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commcare.Integration.Entities
{
    [Table("app_list")]
    public class AppDetail: Entity
    {
        public string? AppName { get; set; }
        public string? AppId { get; set; }
    }
}
