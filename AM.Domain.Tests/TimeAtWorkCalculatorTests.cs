using System;
using System.Collections.Generic;
using System.Linq;
using AM.Data;
using AM.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace AM.Domain.Tests
{
    [TestClass]
    public class TimeAtWorkCalculatorTests
    {
        [TestMethod]
        public void ComputeTotalTimeAtWork_NoPasses_ReturnsZero()
        {
            // arrange
            var passes = new List<Pass>()
            {
                new Pass()
                {
                    EmployeeId = 2,
                    Time = DateTime.Now.AddHours(-4),
                    Type = PassTypeEnum.Arrive,
                },
                new Pass()
                {
                    EmployeeId = 2,
                    Time = DateTime.Now.AddHours(-2),
                    Type = PassTypeEnum.Leave,
                },
            };

            var mockRepository = Substitute.For<IPassRepository>();
            mockRepository.Query.Returns(passes.AsQueryable());

            var timeAtWorkCalculator = new TimeAtWorkCalculator(mockRepository);

            // act
            var hoursAtWork = timeAtWorkCalculator.ComputeTotalTimeAtWork(1);

            // assert
            Assert.AreEqual(TimeSpan.Zero, hoursAtWork);
        }

        [TestMethod]
        public void ComputeTotalTimeAtWork_ValidPasses_ComputesCorrectly()
        {
        }

        [TestMethod]
        public void ComputeTotalTimeAtWork_InvalidPasses_ThrowsException()
        {
        }
    }
}
