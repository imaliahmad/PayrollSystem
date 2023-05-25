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
    [Table("Salary")]
    public class Salary
    {
        [Key]
        public int SId { get; set; }

        [ForeignKey("Employee")]

        [DisplayName("Employee")]

        public int EmpId { get; set; }
        public virtual Employee? Employee { get; set; }

        public DateTime Date { get; set; }
        public string Status { get; set; }

    }
}

