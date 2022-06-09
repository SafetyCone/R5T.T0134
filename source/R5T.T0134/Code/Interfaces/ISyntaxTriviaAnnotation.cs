using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0134
{
    public interface ISyntaxTriviaAnnotation
    {
        public SyntaxAnnotation SyntaxAnnotation { get; }
    }
}
