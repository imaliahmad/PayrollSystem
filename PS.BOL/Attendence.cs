using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.BOL
{
    [Table("Attendence")]
    public class Attendence
    {
        [Key]
        public int AttId { get; set; }

        [Required(ErrorMessage = "Attendence Date is required")]
        public DateTime Date { get; set; }
        public string Status { get; set; }
        //public int CheckStatus { get; set; }


        [ForeignKey("Employee")]

        [DisplayName("Employee")]

        public int EmpId { get; set; }
    }
}
