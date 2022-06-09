using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0134
{
    public interface ISyntaxTokenAnnotation
    {
        public SyntaxAnnotation SyntaxAnnotation { get; }
    }
}
