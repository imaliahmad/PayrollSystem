using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.BOL
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public Guid CategoryId { get; set; } //foreign key
        public Guid BrandId { get; set; } //foreign key



        // === Navigations ===
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brands Brand { get; set; }



        public Product()
        {

        }

        public Product(string name, Guid categoryId, Guid brandId)
        {
            Name = name;
            CategoryId = categoryId;
            BrandId = brandId;
        }





        //Id
        //CreatedBy
        //CreatedDate
        //ModifiedBy
        //ModifiedDate
        //Status
    }
}
