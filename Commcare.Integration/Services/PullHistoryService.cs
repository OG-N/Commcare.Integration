using Commcare.Integration.Entities;
using Commcare.Integration.Repositories;

namespace Commcare.Integration.Services
{
    public class PullHistoryService
    {
        private readonly PullHistoryRepository _repository;
        public PullHistoryService(PullHistoryRepository repository)
        {
            _repository = repository;
        }

        public PullHistory Save(PullHistory history)
        {
            try
            {
                return _repository.Create(history);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<PullHistory> GetAll()
        {
            return _repository.GetAll();
        }

        public PullHistory GetLastRecord()
        {
            List<PullHistory> records = _repository.GetAll().ToList();

            if (records.Count > 0)
            {
                return records.OrderByDescending(x => x.CreateDate).FirstOrDefault();
            }
            else
            { 
                return new PullHistory { CreateDate=DateTime.Now.AddMonths(-1), PullStatus="Never" };
            }
        }
    }
}
