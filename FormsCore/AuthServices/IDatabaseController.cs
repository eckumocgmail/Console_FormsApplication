using System.Threading.Tasks;

public interface IDatabaseController
{
    public Task<T[]> List<T>() where T : BaseEntity;
    public Task<T[]> Page<T>(int page, int size) where T : BaseEntity;

}