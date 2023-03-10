using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commcare.Integration.Entities
{
    [Table("form_fields")]
    public class FormField : Entity
    {
        [Column("app_id")]
        public string? AppId { get; set; }
        [Column("field_name")]
        public string? FieldName { get; set; }
    }
}
