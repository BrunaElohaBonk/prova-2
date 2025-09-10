using System.ComponentModel.DataAnnotations;
using Prova2.Models;

namespace Prova2.UseCase.Cadastro
{
    [Required]
    [MaxLength(20)]
    public string Title { get; set; }

    [Required]
    [MinLength(4)]
    [MaxLength(200)]
    public string Description { get; set; }
}