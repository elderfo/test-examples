using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ViewModels.Annotations;

namespace ViewModels
{
    public class DonkeyListViewModel : ViewModel
    {
        private DonkeyViewModel _selectedDonkey;

        public ICommand AddBatchCommand { get; }
        public ICommand DeleteBatchCommand { get; }

        public ObservableCollection<DonkeyViewModel> Batches { get; }

        public DonkeyListViewModel(IEnumerable<DonkeyViewModel> batches, DonkeyListCommandFactory donkeyListCommandFactory)
        {
            AddBatchCommand = donkeyListCommandFactory.CreateAddBatchCommand(this);
            DeleteBatchCommand = donkeyListCommandFactory.CreateDeleteBatchCommand(this);

            Batches = new ObservableCollection<DonkeyViewModel>(batches);
        }
        
        public DonkeyViewModel SelectedDonkey
        {
            get => _selectedDonkey;
            set
            {
                if (Equals(value, _selectedDonkey)) return;
                _selectedDonkey = value;
                OnPropertyChanged();
            }
        }

    }
}