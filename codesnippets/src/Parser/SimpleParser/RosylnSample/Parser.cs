using System;
using System.Xml.Schema;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SimpleParser.Exceptions;
using SimpleParser.Model;

namespace SimpleParser.RosylnSample
{
    public class Parser
    {
        public static MethodData2 Parse(string expression)
        {
            var syntax = SyntaxFactory.ParseExpression(expression);
            var walker = new MethodExtractWalker(expression);
            walker.Visit(syntax);
            return walker.Method;
        }

        class MethodExtractWalker : CSharpSyntaxWalker
        {
            private readonly string _expression;
            private bool _methodInvocationVisited;
            private bool _methodNameExtracted;
            private MethodData2 _methodData2;
            private int _currentArgumentCount;


            public MethodExtractWalker(string expression)
            {
                _expression = expression;
            }

            public MethodData2 Method => _methodData2;

            public override void Visit(SyntaxNode node)
            {
                Console.WriteLine($"node:{node.GetType()} {node.GetText()}");
                base.Visit(node);
            }

            public override void VisitInvocationExpression(InvocationExpressionSyntax node)
            {
                this._methodInvocationVisited = true;
                base.VisitInvocationExpression(node);
            }

            public override void VisitIdentifierName(IdentifierNameSyntax node)
            {
                if (this._methodInvocationVisited && !_methodNameExtracted)
                {
                    _methodData2 = new MethodData2(node.GetText().ToString());
                    _methodNameExtracted = true;
                }

                base.VisitIdentifierName(node);
            }

            public override void VisitArgument(ArgumentSyntax node)
            {
                if (_methodData2 == null)
                {
                    throw new InvalidSyntaxException($"Method name not found in {this._expression}");
                }

                _currentArgumentCount++;
                _methodData2.AddParameter($"arg{_currentArgumentCount}", node.GetText().ToString(), _currentArgumentCount);
                base.VisitArgument(node);
            }
        }
    }
}
