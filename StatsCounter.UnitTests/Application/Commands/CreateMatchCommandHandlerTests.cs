using Microsoft.AspNetCore.Mvc;
using Moq;
using StatsCounter.Application.Commands.CreateMatch;
using StatsCounter.Core.Repositories;

namespace StatsCounter.UnitTests.Application.Commands
{
    public class CreateMatchCommandHandlerTests
    {
        private readonly Mock<IMatchRepository> _matchRepositoryMock;
        public CreateMatchCommandHandlerTests()
        {
            _matchRepositoryMock = new Mock<IMatchRepository>();
        }
        [Fact]
        public async void InputDateIsOk_Executed_ReturnMatchId()
        {

            var createMatchCommand = new CreateMatchCommand(playerId: 1, date: DateTime.Now);

            var createMatchCommandHandler = new CreateMatchCommandHandler(_matchRepositoryMock.Object);

            var id = await createMatchCommandHandler.Handle(createMatchCommand, new CancellationToken());

            Assert.True(id >= 0);
        }
    }
}
