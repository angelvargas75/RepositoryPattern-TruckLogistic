using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlRepository.Conductor
{
    [Table("Conductor")]
    public partial class Conductor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Pais { get; set; }

        [Required]
        [StringLength(20)]
        public string Ciudad { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }
    }
}
