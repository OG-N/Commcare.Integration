using Commcare.Integration.Entities;
using Commcare.Integration.Repositories;

namespace Commcare.Integration.Services
{
    public class FormDataService
    {
        private readonly FormDataRepository _repository;
        public FormDataService(FormDataRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<FormData> Save(IEnumerable<FormData> formDatas)
        {
            List<FormData> saveddata = new List<FormData>();
            try
            {
                saveddata = _repository.CreateMultiple(formDatas.ToList());
                return saveddata;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<FormData> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
