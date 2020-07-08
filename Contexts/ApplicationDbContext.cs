using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIAgendaTOP.Controllers.Entities;

namespace WebAPIAgendaTOP.Contexts
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteSinTareas> ClientesSinTareas { get; set; }
        public DbSet<ClienteBasico> ClientesBasico { get; set; }
        public DbSet<Tarea> Agenda { get; set; }
        public DbSet<TablaG> TablasGenerales { get; set; }
        public DbSet<User> Usuarios { get; set; }
    }
}
