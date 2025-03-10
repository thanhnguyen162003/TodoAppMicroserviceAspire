using Shared.EF;

namespace User.App.Shared.Data;

public class CatalogsDbContextDesignFactory()
    : DbContextDesignFactoryBase<CatalogsDbContext>(
        $"{nameof(PostgresOptions)}:{nameof(PostgresOptions.ConnectionString)}"
    );