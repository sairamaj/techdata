namespace SimpleParser
{
    // ${add(num1=10,num2=20)}	
    public enum TokenType
    {
        Dollar,
        LeftFlowerBracket,
        OpenParenthesis,
        StringValue,
        Comma,
        CloseParenthesis,
        RightFlowerBracket,
        SequenceTerminator,
        Invalid
    }
}
