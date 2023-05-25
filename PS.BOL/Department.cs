using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.BOL
{ 
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        public string DeptName { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Employee> Employee { get; set; }
    }
}
