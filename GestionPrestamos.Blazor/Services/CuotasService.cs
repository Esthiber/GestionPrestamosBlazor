using GestionPrestamos.Context;
using GestionPrestamos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionPrestamos.Services
{
    public class CuotasService(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> ExisteCuotaAsync(int id)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Cuotas
                .AnyAsync(c => c.CuotaId == id);
        }

        public async Task<bool> InsertarCuotaAsync(Cuotas cuota)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.Cuotas.Add(cuota);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> InsertarCuotasDetalleAsync(CuotasDetalle cd)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.CuotasDetalle.Add(cd);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> InsertarListaCuotasAsync(List<Cuotas> listaCuotas)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            foreach (var c in listaCuotas)
            {
                context.Cuotas.Add(c);
            }
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CrearDetalleCuotas(int PrestamoId, int CuotasNo, double CuotasValor)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.CuotasDetalle.Add(new() { PrestamoId = PrestamoId, CuotasNo = CuotasNo });
            await context.SaveChangesAsync();

            var cuotaDetalle = await GetCuotasDetallesAsync(PrestamoId);

            for (int i = 0; i < CuotasNo; i++)
            {
                context.Cuotas.Add(new()
                {
                    CuotaNo = i + 1,
                    CuotasDetalleId = cuotaDetalle.CuotasDetalleId,
                    Valor = CuotasValor
                });
            }

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<List<Cuotas>> ListarCuotasAsync(int CuotasDetalleId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Cuotas
                .Include(c => c.CuotasDetalle)
                .Where(c => c.CuotasDetalleId == CuotasDetalleId)
                .ToListAsync();
        }

        public async Task<List<Cuotas>> ListarCuotasAsync(Expression<Func<Cuotas, bool>> criterio)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.Cuotas
                .Include(c => c.CuotasDetalle)
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<CuotasDetalle?> GetCuotasDetallesAsync(int prestamoId)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            return await context.CuotasDetalle
                .Include(c => c.Cuotas)
                .SingleOrDefaultAsync(c => c.PrestamoId == prestamoId);
        }

        public async Task<bool> ModificarCuotasDetallesAsync(CuotasDetalle cuotasDetalle)
        {
            await using var context = await DbFactory.CreateDbContextAsync();
            context.CuotasDetalle.Update(cuotasDetalle);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarListaCuotasAsync(int CuotasDetalleId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Cuotas
                .Where(c => c.CuotasDetalleId == CuotasDetalleId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<bool> EliminarCuotasDetalleAsync(int CuotasDetalleId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.CuotasDetalle
                .Where(c => c.CuotasDetalleId == CuotasDetalleId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<bool> EliminarDetalleDeCuotas(int CuotasDetalleId)
        {
            var cuotas = await EliminarListaCuotasAsync(CuotasDetalleId);
            var detalle = await EliminarCuotasDetalleAsync(CuotasDetalleId);
            return cuotas && detalle;
        }

        public async Task<bool> AfectarCuotas(int PrestamoId, double balance)
        {
            if (PrestamoId <= 0 || balance < 0)
            {
                throw new ArgumentException("PrestamoId debe ser mayor que 0 y balance no puede ser negativo.");
            }

            using var context = await DbFactory.CreateDbContextAsync();
            var detalle = await GetCuotasDetallesAsync(PrestamoId);
            double restante = balance;

            foreach (var cuota in detalle.Cuotas)
            {
                if (cuota.Balance == cuota.Valor) continue;

                if (restante >= cuota.Valor)
                {
                    restante -= cuota.Valor;
                    cuota.Balance = cuota.Valor;
                }
                else
                {
                    cuota.Balance += restante; 
                    restante = 0; 
                    break; 
                }

                context.Cuotas.Update(cuota);
            }

            return await context.SaveChangesAsync() > 0;
        }
    }
}
