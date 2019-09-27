using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using SimpleParser.Exceptions;

namespace SimpleParserTest
{
    [TestFixture]
    public class ParserTest
    {
        [Test(Description = "Successful parsing ${add(num1=10,num=20,num3=30)")]
        public void SuccessfulParser()
        {
            var methodInfo = SimpleParser.Parser.Parse("${add(num1=10,num2=20,num3=30)");
            methodInfo.Name.Should().Be("add");
            methodInfo.Parameters.Should().BeEquivalentTo(new Dictionary<string, string>()
            {
                {"num1", "10" },
                {"num2", "20" },
                {"num3", "30" }
            });
        }

        [Test(Description = "Successful parsing ${add()")]
        public void SuccessfulParserWithNoArguments()
        {
            var methodInfo = SimpleParser.Parser.Parse("${add()");
            methodInfo.Name.Should().Be("add");
            methodInfo.Parameters.Should().BeEquivalentTo(new Dictionary<string, string>());
        }

        [Test(Description = "Missing method name ${()")]
        public void MethodNameMissing()
        {
            Action parseWithoutMethodName = () => SimpleParser.Parser.Parse("${()}");
            parseWithoutMethodName.Should().Throw<DslParserException>().WithMessage("Method name missing.");
        }

        //[Test(Description = "Missing method name ${(num1=10)")]
        //public void MethodNameMissingContainingArguments()
        //{
        //    Action parseWithoutMethodName = () => SimpleParser.Parser.Parse("${(num1=10)}");
        //    parseWithoutMethodName.Should().Throw<DslParserException>().WithMessage("Method name missing.");
        //}

    }
}
