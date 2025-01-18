using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Market_Web.Object.Model
{
    [Table("market")]
    public class Market
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }


        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("Employee")]
        public int Employee { get; set; }

        [Required]
        [Column("Inauguration")]
        public DateOnly Inauguration { get; set; }



        [Required]
        [Column("SalesPerMonth")]
        public double SalesPerMonth { get; set; }



    }
}
