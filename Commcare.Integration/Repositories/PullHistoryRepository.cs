using Commcare.Integration.Entities;

namespace Commcare.Integration.Repositories
{
    public class PullHistoryRepository : Repository<PullHistory>
    {
        public PullHistoryRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
