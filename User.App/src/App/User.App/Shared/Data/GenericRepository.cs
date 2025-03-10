using Shared.Core.Persistence.Ef;

namespace User.App.Shared.Data;

public class GenericRepository<T>(CatalogsDbContext dbContext) : EfRepository<T, CatalogsDbContext>(dbContext)
    where T : class;