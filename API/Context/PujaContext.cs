using System.Data.Entity;

public class PujaContext : DbContext
{
    public PujaContext(string connectionString) : base(connectionString)
    { }
    public DbSet<PujaEntity> Pujas { get; set; }


    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
