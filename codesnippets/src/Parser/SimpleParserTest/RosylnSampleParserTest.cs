using System;
using FluentAssertions;
using NUnit.Framework;
using SimpleParser.Model;

namespace SimpleParserTest
{
    [TestFixture()]
    public class RosylnSampleParserTest
    {
        [Test(Description = "Test add(10,20)")]
        public void SuccessfulParserWithIntegerAgumentsTest()
        {
            var method = SimpleParser.RosylnSample.Parser.Parse("add(10,20)");
            method.Name.Should().Be("add");
            method.Arguments.Should().BeEquivalentTo(
                new Argument("arg1", "10", 1),
                new Argument("arg2", "20", 2));
        }

        [Test(Description = "Test add(10,20)")]
        public void SuccessfulParserWithStringArgumentsTest()
        {
            var method = SimpleParser.RosylnSample.Parser.Parse("add(input1,input2)");
            Console.WriteLine(method);
            method.Name.Should().Be("add");
            method.Arguments.Should().BeEquivalentTo(
                new Argument("arg1", "input1", 1),
                new Argument("arg2", "input2", 2));
        }

        [Test(Description = "Test add(10,20)")]
        public void SuccessfulParserWithVariableStringArgumentsTest()
        {
            var method = SimpleParser.RosylnSample.Parser.Parse("add(var.input1,input2)");
            Console.WriteLine(method);
            method.Name.Should().Be("add");
            method.Arguments.Should().BeEquivalentTo(
                new Argument("arg1", "input1", 1)
                {
                    IsVariable = true
                },
                new Argument("arg2", "input2", 2)
                {
                    IsVariable = false
                });
        }

        public void VariableTest()
        {
            var method = SimpleParser.RosylnSample.Parser.Parse("var.input");
            Console.WriteLine(method);
        }
    }
}
