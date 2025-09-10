using Microsoft.EntityFrameworkCore;
using Prova2.Models;

namespace Prova2.UseCase.Editar;

public class UseCaseEditar(provaDbContext ctx)
{
    public async Task<Result<ResponseEditar>> Do(PayloadEditar payload)
    {
        var point = await ctx.Points.FirstOrDefaultAsync(p => p.ID == payload.PointId);
        var tour = await ctx.Tour.FirstOrDefaultAsync(t => t.ID == payload.TourId);



        await ctx.SaveChangesAsync();

        return Result<ResponseEditar>.Success(null);
    }
}