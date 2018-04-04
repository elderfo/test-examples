using System;
using System.ComponentModel;
using System.Windows.Input;

namespace ViewModels
{
    public class DeleteBatchCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        private readonly DonkeyListPresenter _donkeyListPresenter;
        private readonly DonkeyListViewModel _donkeyListViewModel;

        public DeleteBatchCommand(DonkeyListPresenter donkeyListPresenter, DonkeyListViewModel donkeyListViewModel)
        {
            _donkeyListPresenter = donkeyListPresenter;
            _donkeyListViewModel = donkeyListViewModel;

            _donkeyListViewModel.PropertyChanged += OnDonkeyListViewModelOnPropertyChanged;
        }

        public bool CanExecute(object parameter)
        {
            return _donkeyListViewModel.SelectedDonkey != null;
        }

        public void Execute(object parameter)
        {
            _donkeyListPresenter.DeleteBatch(_donkeyListViewModel.SelectedDonkey);
            _donkeyListViewModel.Batches.Remove(_donkeyListViewModel.SelectedDonkey);
            _donkeyListViewModel.SelectedDonkey = null;
        }
        
        private void OnDonkeyListViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(_donkeyListViewModel.SelectedDonkey))
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}