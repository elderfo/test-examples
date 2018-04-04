using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using ViewModels.Mapper;

namespace ViewModels
{
    public class DonkeyListPresenter
    {
        private readonly IDonkeyService _donkeyService;

        public DonkeyListPresenter(IDonkeyService donkeyService)
        {
            _donkeyService = donkeyService;
        }

        public DonkeyViewModel AddBatch(string name)
        {
            Donkey created = _donkeyService.Create(name);
            return new DonkeyViewModel(created.Id, created.Name);
        }

        public void DeleteBatch(DonkeyViewModel donkey)
        {
            _donkeyService.Delete(donkey.Id);
        }

        public IEnumerable<DonkeyViewModel> GetAllBatches()
        {
            return _donkeyService.getAll()
                .Select(b => b.ToBatchViewModel());
        }
    }
}