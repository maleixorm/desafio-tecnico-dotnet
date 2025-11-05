using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoDeVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeVendas.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {
            
        }

        public DbSet<Pedido> Pedidos { get; set; }
    }
}