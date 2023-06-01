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
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        public string Name { get; set; }
        public string Code { get; set; }
        public string PhoneNo { get; set; }

        [ForeignKey("Department")]

        [DisplayName("Department")]

        public int DeptId { get; set; }
        public virtual Department? Department { get; set; }

        public virtual IEnumerable<Attendence> Attendence { get; set; }
        public virtual IEnumerable<Leave> Leave { get; set; }
        public virtual IEnumerable<Salary> Salary { get; set; }

    }
}
