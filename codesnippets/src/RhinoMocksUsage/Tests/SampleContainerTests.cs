using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Rhino.Mocks;
using RhinoMocksUsage.Src;

namespace RhinoMocksUsage.Tests
{
    [TestFixture]
    public class SampleContainerTests
    {
        [Test(Description = "Demonstrates Out stub.")]
        public void OutSimulationTest()
        {
            // Arrange
            int ret = 0;
            var mockSample = MockRepository.GenerateMock<ISample>();
            var container = new SampleContainer(mockSample);
            mockSample.Stub(s => s.MethodWithOutParameter(out ret)).OutRef(100);

            // Act
            container.MethodWithOutParameter(out ret);

            // Assert
            ret.Should().Be(100);
        }
    }
}
