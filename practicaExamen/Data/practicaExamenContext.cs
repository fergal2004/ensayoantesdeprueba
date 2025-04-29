using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using practicaExamen.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL; // Importa el namespace de Npgsql

public class practicaExamenContext : DbContext
{
    public practicaExamenContext (DbContextOptions<practicaExamenContext> options)
        : base(options)
    {
    }

    public DbSet<Carro> Carro { get; set; } = default!;
    public DbSet<Propietario> Propietario { get; set; } = default!;

public DbSet<practicaExamen.Models.persona> persona { get; set; } = default!;

}