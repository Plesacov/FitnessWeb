using Fitness.Core.Models;
using Fitness.Infrastracture;
using FitnessWeb.API.CommandHandlers;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading;

namespace Fitness.Tests.CommandHandlers
{

    [TestClass]
    public class DeleteFitnessProgramCommandHandlerTests
    {
        private Mock<IRepository<FitnessType>> fitnessProgramRepository;
        public DeleteFitnessProgramCommandHandlerTests()
        {
            this.fitnessProgramRepository = new Mock<IRepository<FitnessType>>();
        }
        [TestMethod]
        public void Given_DeleteFitnessProgramCommand_WhenHandle()
        {
            //Arrange
            DeleteFitnessProgramCommandHandler handler = new DeleteFitnessProgramCommandHandler(this.fitnessProgramRepository.Object);
            DeleteFitnessProgramCommand command = new DeleteFitnessProgramCommand
            {
                Id = 1,
            };
            FitnessType fitnessProgram = new FitnessType() { Id = 1 };
            this.fitnessProgramRepository
                .Setup(fitnessProgramRepository => fitnessProgramRepository
                .GetById(command.Id)).Returns(fitnessProgram);

            CancellationToken token = CancellationToken.None;

            //Act
            var result = handler.Handle(command, token);
            //Assert
            Assert.IsNotNull(result);
            fitnessProgramRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once());
            fitnessProgramRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once());
            fitnessProgramRepository.Verify(x => x.Save(), Times.Once());
        }
    }
}
