using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BusinessLogic;

namespace ViewModels
{
    public class BatchListViewModel
    {
        public ICommand AddBatchCommand { get; }

        public ObservableCollection<Batch> Batches { get; }

        public BatchListViewModel(
            IEnumerable<Batch> batches,
            ICommand addBatchCommand,
            WeakEventManager weakEventManager
        )
        {
            AddBatchCommand = addBatchCommand;
            Batches = new ObservableCollection<Batch>(batches);
            weakEventManager.AddListener(OnHandleBatchAdd);
        }

        private void OnHandleBatchAdd(object sender, Batch batch)
        {
            Batches.Add(batch);
        }
    }
}