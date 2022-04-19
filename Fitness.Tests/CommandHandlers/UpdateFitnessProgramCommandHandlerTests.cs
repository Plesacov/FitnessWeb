using Fitness.Core.Models;
using Fitness.Infrastracture;
using FitnessWeb.API.CommandHandlers;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace Fitness.Tests.CommandHandlers
{

    [TestClass]
    public class UpdateFitnessProgramCommandHandlerTests
    {
        private Mock<IRepository<FitnessType>> fitnessProgramRepository;
        public UpdateFitnessProgramCommandHandlerTests()
        {
            this.fitnessProgramRepository = new Mock<IRepository<FitnessType>>();
        }
        [TestMethod]
        public void Given_UpdateFitnessProgramCommand_WhenHandle()
        {
            //Arrange
            FitnessType fitnessType = new FitnessType() { Id = 1 };
            this.fitnessProgramRepository
                .Setup(fitnessProgramRepository => fitnessProgramRepository
                .FindBy(It.IsAny<Expression<Func<FitnessType, bool>>>())).Returns(new[] { fitnessType }.AsEnumerable());
            UpdateFitnessProgramCommandHandler handler = new UpdateFitnessProgramCommandHandler(this.fitnessProgramRepository.Object);
            UpdateFitnessProgramCommand command = new UpdateFitnessProgramCommand
            {
                Id = 1,
                Name = "Power",
                Description = "Training"
            };
            CancellationToken token = CancellationToken.None;

            //Act
            var result = handler.Handle(command, token);

            //Assert
            Assert.IsNotNull(result);
            fitnessProgramRepository.Verify(x => x.FindBy(It.IsAny<Expression<Func<FitnessType, bool>>>()), Times.Once());
            fitnessProgramRepository.Verify(x => x.Update(It.IsAny<FitnessType>()), Times.Once());
            fitnessProgramRepository.Verify(x => x.Save(), Times.Once());
        }
    }
}
