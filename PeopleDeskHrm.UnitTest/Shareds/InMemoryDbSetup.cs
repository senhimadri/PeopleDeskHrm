using Microsoft.EntityFrameworkCore;
using PeopleDeskHrm.Persistence;

namespace PeopleDeskHrm.UnitTest.Shareds;

internal static class InMemoryDbSetup
{
    public static AppDbContext CreateInMemoryDbContext()
    {
        var option = new DbContextOptionsBuilder<AppDbContext>()
                        .UseInMemoryDatabase(Guid.NewGuid().ToString())
                        .Options;

        return new AppDbContext(option);
    }
}
