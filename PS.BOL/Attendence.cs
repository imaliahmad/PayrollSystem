using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.Design;
using PS.BOL.DataTypes;
using System.Web.Mvc;

namespace PS.BOL
{
    [Table("Attendence")]
    public class Attendence
    {
        [Key]
        public int AttId { get; set; }

        [Required(ErrorMessage = "Attendence Date is required")]
        public DateTime Date { get; set; }
        public BatchTypes?  Batch { get; set; }
        public SectionTypes? Section { get; set; }
        public LectureTypes? Lecture { get; set; }
        public StatusTypes? Status { get; set; }

        [ForeignKey("Employee")]

        [DisplayName("Employee")]

        public int EmpId { get; set; }
        public virtual Employee? Employee { get; set; }

        
    }
}
