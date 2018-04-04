using System.Collections.Generic;
using BusinessLogic;

namespace ViewModels
{
    public class DonkeyListViewModelFactory
    {
        private readonly DonkeyListPresenter _donkeyListPresenter;

        public DonkeyListViewModelFactory(DonkeyListPresenter donkeyListPresenter)
        {
            _donkeyListPresenter = donkeyListPresenter;
        }

        public DonkeyListViewModel CreateBatchListViewModel()
        {
            IEnumerable<DonkeyViewModel> batches = _donkeyListPresenter.GetAllBatches();
            return new DonkeyListViewModel(batches, new DonkeyListCommandFactory(_donkeyListPresenter));
        }
    }
}