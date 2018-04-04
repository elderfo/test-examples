using System;
using System.Windows.Input;
using BusinessLogic;

namespace ViewModels
{
    public class AddDonkeyCommand : ICommand
    {
        private readonly DonkeyListPresenter _donkeyListPresenter;
        private readonly DonkeyListViewModel _donkeyListViewModel;

        public AddDonkeyCommand(DonkeyListPresenter donkeyListPresenter, DonkeyListViewModel donkeyListViewModel)
        {
            _donkeyListPresenter = donkeyListPresenter;
            _donkeyListViewModel = donkeyListViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DonkeyViewModel donkey = _donkeyListPresenter.AddBatch("Dummy Batch");
            _donkeyListViewModel.Batches.Add(donkey);
        }

        public event EventHandler CanExecuteChanged;
    }
}