using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;
using Prova2.Models;

namespace Prova2.UseCase.CadastroUser;

public record PayloadCadastroUser
{
    [Required] 
    public string Name { get; init; }

    [Required] 
    public string UserName { get; init; }

    [Required]
    [MinLength(8)]
    public string Password { get; init; }
}