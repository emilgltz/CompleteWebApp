using Microsoft.EntityFrameworkCore;
using CompleteWebApp1.Domain.Models;

namespace CompleteWebApp1.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Rover> Rovers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Rover>().HasData(new Rover { Id = 3, Name = "Curiosity", Description = "Curiosity drivs av en radioisotopgenerator (RIG) som beräknas leverera en uteffekt på 125 W begynnelsevis. Efter generatorns minimilivslängd om 14 år beräknas uteffekten ha sjunkit till 100 W. Solenergi är inte en effektiv kraftkälla och användes bara på Mars Pathfinder och MER på grund av politiskt införda förbud mot RIG. Solenergisystem kan inte användas effektivt på hög latitud, i skugga eller i dammiga områden. Dessutom kan man inte hålla farkosten varm under natten vilket minskar livslängden på elektroniken. Som jämförelse alstrade Spirit och Opportunity 0,6 kWh per dag medan Curiosity kommer att alstra 2,5 kWh per dag." });
            modelBuilder.Entity<Rover>().HasData(new Rover { Id = 2, Name = "Opportunity", Description = "I juni 2018 förloras kontakten med sonden. Detta efter en våldsam sandstorm. Sandstormen är så kraftig att den täcker en fjärdedel av Mars yta och noteras även av Nasas rymdsond Curiosity, som befinner sig på andra sidan av planeten. Den solcellsdrivna sondens energitillförsel bryts i samband med den kraftiga och långvariga sandstormen, eftersom solcellspanelerna täcks av damm. Den 17 september 2018 meddelar Nasa att extremvädret har bedarrat, men trots det lyckas Nasa inte få kontakt med landfarkosten. Det är inte avgjort om det beror på dammet på solcellerna eller att någon del av farkosten har gått sönder i stormen" });
            modelBuilder.Entity<Rover>().HasData(new Rover { Id = 1, Name = "Spirit", Description = "Spirit, också känd som MER-A (Mars Exploration Rover – A) eller MER-2, var NASAs första sond i Marsutforskningsprogrammet Mars Exploration Rover Mission. Den sköts upp med en Delta II-raket från Cape Canaveral Air Force Station, den 10 juni 2003 och landade på Mars yta, den 3 januari 2004. Uppdraget var tänkt att pågå i 90 dagar, men tack vare att solcellerna då och då blåstes rena av starka vindar på Mars, överlevde Spirit i 2 269 dagar. Under sin tid på Mars tillryggalade den totalt 7,73 kilometer." });
            
            
        }
    }
}
