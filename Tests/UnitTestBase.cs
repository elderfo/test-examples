using AutoFixture;

namespace Tests
{
    public class UnitTestBase
    {
        private readonly Fixture _fixture = new Fixture();

        protected T CreateRandom<T>()
        {
            return _fixture.Create<T>();
        }
    }
}
