using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commcare.Integration.Entities
{
    [Table("form_details")]
    public class FormDetail : Entity
    {
        [Column("app_id")]
        public string? AppId { get; set; }
        [Column("form_id")]
        public string? FormId { get; set; }
        [Column("time_start")]
        public DateTime TimeStart { get; set; }
        [Column("time_end")]
        public DateTime TimeEnd { get; set; }
        [Column("username")]
        public string? Username { get; set; }
        [Column("quart_num")]
        public string? QuartNum { get; set; }
        [Column("survey_date")]
        public DateTime SurveyDate { get; set; }
        [Column("form_link")]
        public string? FormLink { get; set; }
    }
}
