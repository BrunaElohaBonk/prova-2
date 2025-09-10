using Microsoft.EntityFrameworkCore;
using Prova2.Models;

namespace Prova2.UseCase.GetTour;

public class UseCaseGetTour(provaDbContext ctx)
{
    public async Task<Result<ResponseGetTour>> Do(PayloadGetTour payload)
    {
        var tour = await ctx.Tours
        .Include(p => p.Points)
        .FirstOrDefaultAsync(p => p.ID == payload.PointId);

        var response = new ResponseGetTour
        (
            tour.Title,
            tour.Description,
            from p in tour.Points
            select new Point
            (
                p.Title,
                p.Tours.Where(p => p.PointId == payload.PointId).FirstOrDefault()?.Name
            )
        );

        return Result<ResponseGetTour>.Success(response);
    }
}