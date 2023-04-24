using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Resultado
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Required]
    public decimal Value1 { get; set; }
    [Required]
    public decimal Value2 { get; set; }
    [Required]
    [StringLength(50)]
    public string Method { get; set; }
    [Required]
    public decimal Result { get; set; }

    public Resultado() { }

}