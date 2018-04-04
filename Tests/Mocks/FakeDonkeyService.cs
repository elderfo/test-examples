using System.Collections.Generic;
using System.Linq;
using BusinessLogic;

namespace Tests.Mocks
{
    public class FakeDonkeyService : IDonkeyService
    {
        private readonly IList<Donkey> _batches;

        public FakeDonkeyService(IList<Donkey> batchViewModels)
        {
            _batches = batchViewModels;
        }

        public FakeDonkeyService() : this(new List<Donkey>())
        {
        }

        public IEnumerable<Donkey> getAll()
        {
            return _batches;
        }

        public void Delete(int batchId)
        {
            Donkey donkey = _batches.FirstOrDefault(b => b.Id == batchId);

            if (donkey == null) return;

            _batches.Remove(donkey);
        }

        public Donkey Create(string batchName)
        {
            Donkey donkey = new Donkey(GetBatchId(), batchName);

            _batches.Add(donkey);

            return donkey;
        }

        private int GetBatchId()
        {
            if (_batches.Any())
            {
                return _batches.Max(b => b.Id) + 1;
            }

            return 1;
        }

        public void Clear()
        {
            _batches.Clear();
        }
    }
}