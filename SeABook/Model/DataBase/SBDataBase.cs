using Microsoft.EntityFrameworkCore;

namespace SeABook.Model.DataBase
{
    public class SBDataBase : DbContext
    {
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;
        public DbSet<Reader> Readers { get; set; } = null!;
        public DbSet<ReadingRoom> ReadingRooms { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public SBDataBase()
        {
            Database.EnsureCreated();
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=sb.db");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(a =>
            {
                a.HasKey(x => x.Id);
                a.Property(x => x.Name).IsRequired();
                a.Property(x => x.Surname).IsRequired();
                a.Property(x => x.Fathername).HasDefaultValue(null).IsRequired(false);
                
            });

            modelBuilder.Entity<Publisher>(p =>
            {
                p.HasKey(x => x.Id);
                p.Property(x => x.Name).IsRequired();
                
            });

            modelBuilder.Entity<Reader>(r =>
            {
                r.HasKey(x => x.Id);
                r.Property(x => x.Name).IsRequired();
                r.Property(x => x.Surname).IsRequired();
                r.Property(x => x.Fathername).HasDefaultValue(null).IsRequired(false);
                r.HasOne(x => x.Account).WithOne(x => x.User).HasForeignKey<Reader>(x => x.AccountId);
            });

            modelBuilder.Entity<ReadingRoom>(r =>
            {
                r.HasKey(x => x.Id);
                r.Property(x => x.Name).IsRequired();
                
            });
            modelBuilder.Entity<Account>(a =>
            {
                a.HasKey(x => x.Id);
                a.Property(x => x.Login).IsRequired();
                a.Property(x => x.Password).IsRequired();
                a.Property(x => x.Admin).HasDefaultValue(false);
            });
            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).IsRequired();
                b.Property(x => x.Anntotation).IsRequired();

                b.HasOne(x => x.Publisher).WithMany(x => x.Books).HasForeignKey(x => x.PublisherId);
                b.HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId);
                b.HasOne(x => x.ReadingRoom).WithMany(x => x.Books).HasForeignKey(x=>x.ReadingRoomId);

                b.HasOne(x => x.Reader).WithMany(x => x.Books).HasForeignKey(x => x.ReaderId);
            });
            modelBuilder.Entity<Account>().HasData(new Account { Id = 1, Admin = true, Login = "admin", Password = "admin" });
            modelBuilder.Entity<Reader>().HasData(new Reader { Id = 1, Name = "Admin", Surname = "Admin", AccountId = 1 });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
