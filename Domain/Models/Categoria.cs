using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Categoria
{
    [Key]
    public Guid IdCategoria { get; set; }

    [Required]
    public string NomeCategoria { get; set; }

    [Required]
    [Column(TypeName = "timestamp(6)")]
    public DateTime DataAlteracao { get; set; }

    [Required]
    public bool Ativo { get; set; }

    public ICollection<Produto> Produtos { get; set; }
}
