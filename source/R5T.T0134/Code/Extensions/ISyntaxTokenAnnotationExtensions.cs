using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;

using R5T.T0134;


namespace System
{
    public static class ISyntaxTokenAnnotationExtensions
    {
        public static SyntaxToken GetToken(this ISyntaxTokenAnnotation annotation,
            SyntaxNode parentNode)
        {
            var output = parentNode.GetAnnotatedToken(annotation);
            return output;
        }

        public static TParentNode Modify<TParentNode>(this ISyntaxTokenAnnotation annotation,
            TParentNode parentNode,
            Func<SyntaxToken, SyntaxToken> modifier)
            where TParentNode : SyntaxNode
        {
            var token = annotation.GetToken(parentNode);

            var modifiedNode = modifier(token);

            var outputParent = parentNode.ReplaceToken_Better(token, modifiedNode);
            return outputParent;
        }
    }
}
