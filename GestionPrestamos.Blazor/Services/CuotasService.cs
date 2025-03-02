using GestionPrestamos.Context;
using GestionPrestamos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionPrestamos.Services
{
    public class CuotasService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Existe(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Cuotas
                .AnyAsync(c => c.CuotaId == id);
        }

        public async Task<bool> Insertar(Cuotas cuota)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Cuotas.Add(cuota);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<List<Cuotas>> Listar(Expression<Func<Cuotas, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Cuotas
                .Include(c => c.Prestamo)
                .Where(criterio)
                .ToListAsync();
        }

    }
}
