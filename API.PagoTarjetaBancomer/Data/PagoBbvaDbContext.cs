using API.PagoTarjetaBancomer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class PagoBbvaDbContext : DbContext
{
    public PagoBbvaDbContext(DbContextOptions<PagoBbvaDbContext> options)
        : base(options)
    {
    }

    public DbSet<ConfiguracionPagoBBVA> ConfiguracionPagoBBVA { get; set; }
}