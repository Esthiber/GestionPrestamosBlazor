﻿using GestionPrestamos.Context;
using GestionPrestamos.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionPrestamos.Services;

public class PrestamosService(IDbContextFactory<Contexto> DbFactory)
{
    private async Task<bool> Existe(int prestamoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prestamos
            .AnyAsync(p => p.PrestamoId == prestamoId);
    }

    public async Task<bool> Insertar(Prestamos prestamo)
    {
        prestamo.Balance = prestamo.Monto;
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Prestamos.Add(prestamo);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Prestamos prestamo)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(prestamo);
        return await contexto
            .SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Prestamos prestamo)
    {
        prestamo.Balance = prestamo.Monto;
        if (!await Existe(prestamo.PrestamoId))
        {
            return await Insertar(prestamo);
        }
        else
        {
            return await Modificar(prestamo);
        }
    }

    public async Task<Prestamos> Buscar(int prestamoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prestamos
            .Include(d => d.Deudor)
            .Include(c => c.CuotasDetalle)
            .FirstOrDefaultAsync(p => p.PrestamoId == prestamoId);
    }

    public async Task<bool> Eliminar(int prestamoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prestamos
            .Where(p => p.PrestamoId == prestamoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Prestamos>> GetList(Expression<Func<Prestamos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prestamos
            .Include(d => d.Deudor)
            .Include(c => c.CuotasDetalle)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<List<Prestamos>> GetPrestamosPendientes(int deudorId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prestamos
            .Where(p => p.DeudorId == deudorId && p.Balance > 0)
            .OrderBy(p => p.PrestamoId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Prestamos?> BuscarPrestamo(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Prestamos.
            Include(p => p.Deudor)
            .Include(d => d.CuotasDetalle)
            .FirstOrDefaultAsync(p => p.DeudorId == id);
    }
}
