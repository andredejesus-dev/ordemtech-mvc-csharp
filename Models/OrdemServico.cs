using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdemTech.Models
{
    public class OrdemServico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição do problema é obrigatória.")]
        public string DescricaoProblema { get; set; } = string.Empty;

        [Required(ErrorMessage = "O valor do orçamento é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValorOrcamento { get; set; }

        public DateTime DataAbertura { get; set; } = DateTime.Now;

        public bool Finalizada { get; set; } = false;

        // Chave Estrangeira (Relacionamento 1:N)
        [Required]
        public int ClienteId { get; set; }
        
        [ForeignKey("ClienteId")]
        public virtual Cliente? Cliente { get; set; }
    }
}