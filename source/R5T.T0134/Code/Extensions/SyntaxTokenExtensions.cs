using System;

using Microsoft.CodeAnalysis;

using R5T.T0134;


namespace System
{
    public static class SyntaxTokenExtensions
    {
        public static SyntaxToken Annotate(this SyntaxToken token,
            out ISyntaxTokenAnnotation syntaxTokenAnnotation)
        {
            var output = token.Annotate_Untyped(out var annotation);

            syntaxTokenAnnotation = SyntaxTokenAnnotation.From(annotation);

            return output;
        }
    }
}
