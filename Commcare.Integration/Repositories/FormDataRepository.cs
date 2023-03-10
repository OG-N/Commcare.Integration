using Commcare.Integration.Entities;

namespace Commcare.Integration.Repositories
{
    public class FormDataRepository:Repository<FormData>
    {
        public FormDataRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
