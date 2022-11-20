using Contracts;
using Moq;

namespace TestProject.Tests.Mocks
{
    /// <summary>
    /// A central place for all mock objects
    /// </summary>
    public class RepoWrapper
    {
        public static Mock<IRepositoryManager> GetMock()
        {
            var mock = new Mock<IRepositoryManager>();

            var userRepoMock = MockIUserRepository.GetMock();
            var accountRepoMock = MockIAccountRepository.GetMock();

            mock.Setup(r => r.Account).Returns(() => accountRepoMock.Object);


            mock.Setup(r => r.User).Returns(() => userRepoMock.Object);

            mock.Setup(r => r.SaveAsync()).Callback(() => { return; });
            
            return mock;
        }
    }
}
