using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DATA
{
    //va a representar mi bd
    public class HeroeDB : DbContext
        {
            public HeroeDB(DbContextOptions<HeroeDB> options) : base(options)
            {

            }

            public DbSet<Heroe> Heroe => Set<Heroe>();
            public DbSet<Habilidad> Habilidad => Set<Habilidad>();
        }
    }

