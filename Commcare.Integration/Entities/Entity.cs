using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Commcare.Integration.Entities
{
    public class Entity
    {
        [Key]
        [Column("id")]
        public virtual int Id { get; set; }
        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        protected Entity()
        {
            CreateDate = DateTime.Now;
        }
    }
}
