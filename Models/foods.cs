namespace projectServices.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FOODS")]

    public class Foods
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string foodName { get; set; }

        public string foodDescription { get; set; }
        public string FoodImage { get; set; }

        public string foodPrice { get; set; }

    }
}