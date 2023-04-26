using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Operation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; }

    public string? Values { get; set; }
    [Required]
    [StringLength(50)]
    public string Method { get; set; }

    public Resultado resultado { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Method: {Method}, Values: {Values ?? "null"}";
    }
}
