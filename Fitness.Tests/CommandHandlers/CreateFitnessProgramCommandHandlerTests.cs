using AutoFixture.Xunit2;
using AutoMapper;
using Fitness.Infrastracture;
using FitnessWeb.API.CommandHandlers;
using FitnessWeb.API.Commands;
using FitnessWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Fitness.Tests.CommandHandlers
{

    [TestClass]
    public class CreateFitnessProgramCommandHandlerTests
    {
        private Mock<IRepository<FitnessProgram>> fitnessProgramRepository;
        public CreateFitnessProgramCommandHandlerTests()
        {
            this.fitnessProgramRepository = new Mock<IRepository<FitnessProgram>>();
        }
        [TestMethod]
        public void Given_CreateFitnessProgramCommand_WhenHandle()
        {
            //Arrange
            CreateFitnessProgramCommandHandler handler = new CreateFitnessProgramCommandHandler(this.fitnessProgramRepository.Object);
            CreateFitnessProgramCommand command = new CreateFitnessProgramCommand
            {
                Name = "Power",
                Description = "Training"
            };
            CancellationToken token = CancellationToken.None;

            //Act
            var result = handler.Handle(command, token);
            //Assert
            Assert.IsNotNull(result);
            fitnessProgramRepository.Verify(x => x.Insert(It.IsAny<FitnessProgram>()), Times.Once());
            fitnessProgramRepository.Verify(x => x.Save(), Times.Once());
        }
    }
}
