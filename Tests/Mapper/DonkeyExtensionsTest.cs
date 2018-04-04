using BusinessLogic;
using FluentAssertions;
using ViewModels;
using ViewModels.Mapper;
using Xunit;

namespace Tests.Mapper
{
    public class DonkeyExtensionsTest : UnitTestBase
    {
        [Fact]
        public void ToBatchViewModel_ReturnsExpectedViewModel()
        {
            Donkey expected = CreateRandom<Donkey>();
            
            DonkeyViewModel actual = expected.ToBatchViewModel();
            
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
