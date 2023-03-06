using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commcare.Integration.Entities
{
    [Table("form_data")]
    public class FormData : Entity
    {
        public string? FormId { get; set; }
        public string? FieldName { get; set; }
        public string? FieldValue { get; set; }
        public string? AppId { get; set; }
    }
}
