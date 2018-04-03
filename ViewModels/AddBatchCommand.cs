using System;
using System.Windows.Input;
using BusinessLogic;

namespace ViewModels
{
    public class AddBatchCommand : ICommand
    {
        private readonly BatchListPresenter _batchListPresenter;

        public AddBatchCommand(BatchListPresenter batchListPresenter)
        {
            _batchListPresenter = batchListPresenter;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _batchListPresenter.AddBatch(new Batch(2));
        }

        public event EventHandler CanExecuteChanged;
    }
}