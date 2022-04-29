using AutoFixture.Xunit2;
using AutoMapper;
using Fitness.Core.Models;
using Fitness.Infrastracture;
using FitnessWeb.API.CommandHandlers;
using FitnessWeb.API.Commands;
using FitnessWeb.API.Queries;
using FitnessWeb.API.QueryHandlers;
using FitnessWeb.API.ViewModels;
using FitnessWeb.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Fitness.Tests.CommandHandlers
{

    [TestClass]
    public class FitnessProgramQueryHandlerTests
    {
        private Mock<IRepository<FitnessProgram>> fitnessProgramRepository;
        private Mock<IMapper> mapper;
        public FitnessProgramQueryHandlerTests()
        {
            this.fitnessProgramRepository = new Mock<IRepository<FitnessProgram>>();
            this.mapper = new Mock<IMapper>();
        }
        [TestMethod]
        public void Given_SearchFitnessProgramCommand_WhenHandle()
        {
            //Arrange
            FitnessProgramQueryHandler handler = new FitnessProgramQueryHandler(this.fitnessProgramRepository.Object, this.mapper.Object);
            FitnessProgramQuery query = new FitnessProgramQuery
            {
                SearchTerm = "Power",
            };
            CancellationToken token = CancellationToken.None;
            var fitnessProgram = new FitnessProgram
            {
                FitnessType = new FitnessType
                {
                    Name = "Power"
                }
            };

            this.fitnessProgramRepository
                .Setup(fitnessProgramRepository => fitnessProgramRepository
                .GetWithInclude(It.IsAny<Expression<Func<FitnessProgram, bool>>>(),
                                It.IsAny<Expression<Func<FitnessProgram, object>>>(),
                                It.IsAny<Expression<Func<FitnessProgram, object>>>(),
                                It.IsAny<Expression<Func<FitnessProgram, object>>>())).Returns(new[] { fitnessProgram }.AsEnumerable());

            //Act
            var result = handler.Handle(query, token);
            //Assert
            Assert.IsNotNull(result);
            fitnessProgramRepository.Verify(x => x.GetWithInclude(It.IsAny<Expression<Func<FitnessProgram, bool>>>(),
                                It.IsAny<Expression<Func<FitnessProgram, object>>>(),
                                It.IsAny<Expression<Func<FitnessProgram, object>>>(),
                                It.IsAny<Expression<Func<FitnessProgram, object>>>()), Times.Once());
        }
    }
}
