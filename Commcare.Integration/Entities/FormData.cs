using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commcare.Integration.Entities
{
    [Table("form_data")]
    public class FormData : Entity
    {
        [Column("form_id")]
        public string? FormId { get; set; }
        [Column("field_name")]
        public string? FieldName { get; set; }
        [Column("field_value")]
        public string? FieldValue { get; set; }
        [Column("app_id")]
        public string? AppId { get; set; }
    }
}
