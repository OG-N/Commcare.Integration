using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commcare.Integration.Entities
{
    [Table("form_fields")]
    public class FormField : Entity
    {
        public string? AppId { get; set; }
        public string? FieldName { get; set; }
    }
}
