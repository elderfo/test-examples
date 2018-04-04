using System.Collections.Generic;
using System.Linq;
using BusinessLogic;
using FluentAssertions;
using Tests.Mocks;
using ViewModels;
using Xunit;

namespace Tests
{
    public class DonkeyListViewModelTest : UnitTestBase
    {
        private readonly DonkeyListViewModel _systemUnderTest;

        private readonly FakeDonkeyService _fakeDonkeyService = new FakeDonkeyService();

        public DonkeyListViewModelTest()
        {
            _fakeDonkeyService.Clear();
            _systemUnderTest = CreateSystemUnderTest(_fakeDonkeyService);
        }

        [Fact]
        public void BatchListViewModel_HasExistingBatches_WhenConstructed()
        {
            IList<Donkey> batches = new List<Donkey>
            {
                CreateRandom<Donkey>(),
                CreateRandom<Donkey>(),
            };
            IDonkeyService donkeyService = new FakeDonkeyService(batches);

            DonkeyListViewModel systemUnderTest = CreateSystemUnderTest(donkeyService);
            
            systemUnderTest.Batches.Should().BeEquivalentTo(batches);
        }

        [Fact]
        public void AddBatchCommand_AddsBatch_WhenExecuted()
        {
            _systemUnderTest.AddBatchCommand.Execute(null);

            _systemUnderTest.Batches.Should().NotBeEmpty();
        }
        
        [Fact]
        public void DeleteBatchCommand_IsEnabled_WhenBatchIsSelected()
        {
            CreateAndSelectBatchViewModel();

            _systemUnderTest.DeleteBatchCommand.CanExecute(null).Should().BeTrue();
        }

        [Fact]
        public void DeleteBatchCommand_IsDisabled_WhenNoBatchIsSelected()
        {
            _systemUnderTest.SelectedDonkey = null;
            _systemUnderTest.DeleteBatchCommand.CanExecute(null).Should().BeFalse();
        }

        [Fact]
        public void DeleteBatchCommand_RemovesSelectedBatch_WhenExecuted()
        {
            var batchViewModel = CreateAndSelectBatchViewModel();

            _systemUnderTest.DeleteBatchCommand.Execute(null);

            _systemUnderTest.Batches.Should().NotContain(batchViewModel);
        }

        [Fact]
        public void DeleteBatchCommand_SetsSelectedBatchToNull_WhenExecuted()
        {
            CreateAndSelectBatchViewModel();

            _systemUnderTest.DeleteBatchCommand.Execute(null);

            _systemUnderTest.SelectedDonkey.Should().BeNull();
        }

        private DonkeyViewModel CreateAndSelectBatchViewModel()
        {
            var batchViewModel = CreateRandom<DonkeyViewModel>();

            _systemUnderTest.Batches.Add(batchViewModel);
            _systemUnderTest.SelectedDonkey = batchViewModel;

            return batchViewModel;
        }

        private static DonkeyListViewModel CreateSystemUnderTest(IDonkeyService donkeyService)
        {
            DonkeyListPresenter presenter = new DonkeyListPresenter(donkeyService);
            DonkeyListViewModelFactory viewModelFactory = new DonkeyListViewModelFactory(presenter);

            return viewModelFactory.CreateBatchListViewModel();
        }
    }
}