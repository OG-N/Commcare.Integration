using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commcare.Integration.Entities
{
    [Table("form_details")]
    public class FormDetail : Entity
    {
        public string? AppId { get; set; }
        public string? FormId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string? Username { get; set; }
        public string? QuartNum { get; set; }
        public DateTime SurveyDate { get; set; }
        public string? FormLink { get; set; }
    }
}
