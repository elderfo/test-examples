using System.Linq;
using AutoFixture;
using Tests.Mocks;
using ViewModels;
using Xunit;

namespace Tests
{
    public class BatchListViewModelTest
    {
        private readonly Fixture _fixture = new Fixture();
        private readonly BatchListViewModel _systemUnderTest;

        private readonly MockBatchService _mockBatchService = new MockBatchService();

        public BatchListViewModelTest()
        {
            _mockBatchService.Clear();
            BatchListPresenter presenter = new BatchListPresenter(_mockBatchService, new WeakEventManager());
            _systemUnderTest = presenter.GetBatchListViewModel();
        }

        [Fact]
        public void AddBatchCommand_addsBatch_whenExecuted()
        {
            Assert.Empty(_systemUnderTest.Batches);


            _systemUnderTest.AddBatchCommand.Execute(null);

            Assert.Equal(_systemUnderTest.Batches.Count(), 1);
        }
    }
}