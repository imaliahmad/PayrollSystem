using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.BOL
{
    [Table("Brands")]
    public class Brands:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigations
        public virtual IEnumerable<Product> Products { get; set; }
        public Brands()
        {

        }

        public Brands(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
