using System.Collections.Generic;
using Detetive_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Detetive_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }

        public DbSet<Suspeito> Suspeitos { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Arma> Armas { get; set; }
        public DbSet<SolucaoCrime> SolucaoCrimes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Suspeito>()
            .HasData(
                new List<Suspeito>(){
                    new Suspeito(){
                        Id = 1,
                        Nome = "Esqueleto"
                    },
                    new Suspeito(){
                        Id = 2,
                        Nome = "Khan"
                    },
                    new Suspeito(){
                        Id = 3,
                        Nome = "Dath Vader"
                    },
                    new Suspeito(){
                        Id = 4,
                        Nome = "Sideshow Bob"
                    },
                    new Suspeito(){
                        Id = 5,
                        Nome = "Coringa"
                    },
                    new Suspeito(){
                        Id = 6,
                        Nome = "Duende Verde"
                    }
                }
            );

            builder.Entity<Local>()
            .HasData(
                new List<Local>(){
                    new Local(){
                        Id = 1,
                        Nome = "Etérnia"
                    },
                    new Local(){
                        Id = 2,
                        Nome = "Vulcano"
                    },
                    new Local(){
                        Id = 3,
                        Nome = "Tatooine"
                    },
                    new Local(){
                        Id = 4,
                        Nome = "Springfield"
                    },
                    new Local(){
                        Id = 5,
                        Nome = "Gotham"
                    },
                    new Local(){
                        Id = 6,
                        Nome = "Nova York"
                    },
                    new Local(){
                        Id = 7,
                        Nome = "Sibéria"
                    },
                    new Local(){
                        Id = 8,
                        Nome = "Machu Picchu"
                    },
                    new Local(){
                        Id = 9,
                        Nome = "Show do Katinguele"
                    },
                    new Local(){
                        Id = 10,
                        Nome = "São Paulo"
                    }
                }
            );

            builder.Entity<Arma>()
            .HasData(
                new List<Arma>(){
                    new Arma(){
                        Id = 1,
                        Nome = "Cajado Devastador"
                    },
                    new Arma(){
                        Id = 2,
                        Nome = "Phaser"
                    },
                    new Arma(){
                        Id = 3,
                        Nome = "Peixeira"
                    },
                    new Arma(){
                        Id = 4,
                        Nome = "Trezoitão"
                    },
                    new Arma(){
                        Id = 5,
                        Nome = "Sabre de Luz"
                    },
                    new Arma(){
                        Id = 6,
                        Nome = "Bomba"
                    }
                }
            );
        }
    }
}
