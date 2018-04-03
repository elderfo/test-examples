using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BusinessLogic;
using ViewModels.Annotations;

namespace ViewModels
{
    public class BatchListPresenter 
    {
        private readonly IBatchService _batchService;
        private readonly WeakEventManager _weakEventManager;

        public BatchListPresenter(
            IBatchService batchService,
            WeakEventManager weakEventManager
        )
        {
            _batchService = batchService;
            _weakEventManager = weakEventManager;
        }

        public BatchListViewModel GetBatchListViewModel()
        {
            IEnumerable<Batch> batches = _batchService.getAll();
            return new BatchListViewModel(batches, new AddBatchCommand(this), _weakEventManager);
        }

        public void AddBatch(Batch batch)
        {
            Batch created = _batchService.Create(batch);
            _weakEventManager.Dispatch(created);
        }
    }
}