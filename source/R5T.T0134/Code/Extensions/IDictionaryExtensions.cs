using System;
using System.Collections.Generic;

using Microsoft.CodeAnalysis;

using R5T.T0134;


namespace System.Linq
{
    public static class IDictionaryExtensions
    {
        public static Dictionary<TNode, TTypedSyntaxAnnotation> ToTypedAnnotationsByNode<TNode, TTypedSyntaxAnnotation>(this IDictionary<TNode, SyntaxAnnotation> untypedAnnotationsByNode,
            Func<SyntaxAnnotation, TTypedSyntaxAnnotation> typedSyntaxAnnotationConstructor)
            where TNode : SyntaxNode
            where TTypedSyntaxAnnotation : ISyntaxNodeAnnotation<TNode>
        {
            var output = untypedAnnotationsByNode
                .Select(xPair => new { xPair.Key, Value = typedSyntaxAnnotationConstructor(xPair.Value) })
                .ToDictionary(
                    x => x.Key,
                    x => x.Value);

            return output;
        }

        public static Dictionary<TNode, SyntaxNodeAnnotation<TNode>> ToTypedAnnotationsByNode<TNode>(this IDictionary<TNode, SyntaxAnnotation> untypedAnnotationsByNode)
            where TNode : SyntaxNode
        {
            var output = untypedAnnotationsByNode
                .Select(xPair => new { xPair.Key, Value = SyntaxNodeAnnotation.From<TNode>(xPair.Value) })
                .ToDictionary(
                    x => x.Key,
                    x => x.Value);

            return output;
        }

        public static Dictionary<SyntaxToken, SyntaxTokenAnnotation> ToTypedAnnotationsByToken(this IDictionary<SyntaxToken, SyntaxAnnotation> untypedAnnotationsByToken)
        {
            var output = untypedAnnotationsByToken
                .Select(xPair => new { xPair.Key, Value = SyntaxTokenAnnotation.From(xPair.Value) })
                .ToDictionary(
                    x => x.Key,
                    x => x.Value);

            return output;
        }

        public static Dictionary<SyntaxTrivia, SyntaxTriviaAnnotation> ToTypedAnnotationsByTrivia(this IDictionary<SyntaxTrivia, SyntaxAnnotation> untypedAnnotationsByToken)
        {
            var output = untypedAnnotationsByToken
                .Select(xPair => new { xPair.Key, Value = SyntaxTriviaAnnotation.From(xPair.Value) })
                .ToDictionary(
                    x => x.Key,
                    x => x.Value);

            return output;
        }
    }
}
