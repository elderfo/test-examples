using System.Collections.Generic;
using BusinessLogic;

namespace Tests.Mocks
{
    public class MockBatchService : IBatchService
    {
        private readonly IList<Batch> _batches;

        public MockBatchService(IEnumerable<Batch> batches)
        {
            _batches = new List<Batch>(batches);
        }

        public MockBatchService() : this(new List<Batch>())
        {
        }

        public IEnumerable<Batch> getAll()
        {
            return _batches;
        }

        public Batch Create(Batch batch)
        {
            _batches.Add(batch);
            return batch;
        }

        public void Clear()
        {
            _batches.Clear();
        }
    }
}