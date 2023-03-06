using System.ComponentModel.DataAnnotations;

namespace Commcare.Integration.Entities
{
    public class Entity
    {
        [Key]
        public virtual int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
