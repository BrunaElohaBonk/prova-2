using Prova2.Models;

namespace Prova2.UseCase.GetTour;

public record ResponseGetTour(
    string Title,
    string Description,
    ICollection<Tour> ? Tours
);