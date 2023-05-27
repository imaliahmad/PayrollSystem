using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.BOL
{
    public class BaseEntity
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } // "32jh3j4-njk3jk4h3jkl4h-kjh34j-kh34jkh" 
        public DateTime CreatedDate { get; set; } 
        public Guid CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public BaseEntity()
        {

        }
        // <= 120 
        public BaseEntity(Guid id, DateTime createdDate, Guid createdBy, 
                          DateTime modifiedDate, Guid modifiedBy, bool isActive)
        {
            Id = id;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
            IsActive = isActive;
        }
    }
}
