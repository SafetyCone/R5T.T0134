using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0134
{
    public class SyntaxTriviaAnnotation : TypedSyntaxAnnotation<SyntaxTrivia>, ISyntaxTriviaAnnotation
    {
        #region Static

        public static SyntaxTriviaAnnotation From(SyntaxAnnotation annotation)
        {
            var output = new SyntaxTriviaAnnotation(annotation);
            return output;
        }

        #endregion


        public SyntaxTriviaAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
