using System.Windows.Input;

namespace ViewModels
{
    public class DonkeyListCommandFactory
    {
        private readonly DonkeyListPresenter _donkeyListPresenter;

        public DonkeyListCommandFactory(DonkeyListPresenter donkeyListPresenter)
        {
            _donkeyListPresenter = donkeyListPresenter;
        }

        public ICommand CreateAddBatchCommand(DonkeyListViewModel donkeyListViewModel)
        {
            return new AddDonkeyCommand(_donkeyListPresenter, donkeyListViewModel);
        }

        public ICommand CreateDeleteBatchCommand(DonkeyListViewModel donkeyListViewModel)
        {
            return new DeleteBatchCommand(_donkeyListPresenter, donkeyListViewModel);
        }
    }
}