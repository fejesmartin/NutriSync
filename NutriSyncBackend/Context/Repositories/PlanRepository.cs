using Microsoft.EntityFrameworkCore;

namespace NutriSyncBackend.Context.Repositories;

public class PlanRepository: IRepository<Plan>
{
    public NutriSyncDBContext _dbContext;

    public PlanRepository(NutriSyncDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Plan> GetAll()
    {
        return _dbContext.Plans.ToList();
    }

    public Plan? GetById(int id)
    {
        return _dbContext.Plans.Find(id);
    }

    public void Create(Plan obj)
    {
        _dbContext.Plans.Add(obj);
        _dbContext.SaveChanges();
    }

    public void Update(Plan obj)
    {
        _dbContext.Entry(obj).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var plan = _dbContext.Plans.Find(id);
        if (plan != null)
        {
            _dbContext.Plans.Remove(plan);
            _dbContext.SaveChanges();
        }
    }
}