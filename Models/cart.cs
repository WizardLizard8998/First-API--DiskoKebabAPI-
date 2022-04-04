
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectServices.Models
{

    [Table("Order")]
    public class Cart
    {
        public Cart()
        {
            OrderTime = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Adress { get; set; }

        public string Mail { get; set; }

        public string Order { get; set; }
        public DateTime OrderTime { get; set; }

    }
}