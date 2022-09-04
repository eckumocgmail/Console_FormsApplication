using Microsoft.EntityFrameworkCore;

public interface IEntityRepository<T>
{
}

public class EntityRepository<T> : IEntityRepository<T>
{
    private DbContext applicationDbContext;

    public EntityRepository(DbContext applicationDbContext)
    {
        this.applicationDbContext = applicationDbContext;
    }
}