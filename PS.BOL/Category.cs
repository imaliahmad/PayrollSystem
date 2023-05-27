using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.BOL
{
    [Table("Categorys")]
    public class Category: BaseEntity
    {
        //Food => 10
        //Drinks => 10
        public string Name { get; set; }

        // == Navigation ==
        public virtual IEnumerable<Product> Products { get; set; }


        public Category()
        {

        }

        public Category(string name)
        {
            Name = name;
        }
    }
}
