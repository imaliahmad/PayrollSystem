using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.BOL.DataTypes;

namespace PS.BOL
{
    [Table("Leave")]
    public class Leave
    {
        [Key]
        public int LeaveId { get; set; }

        [Required(ErrorMessage = "Leave Date is required")]
        public DateTime LeaveDate { get; set; }

        [ForeignKey("Employee")]

        [DisplayName("Employee")]

        public int EmpId { get; set; }
        public virtual Employee? Employee { get; set; }
        public LeaveStatusTypes? Status { get; set; }

    }
}

