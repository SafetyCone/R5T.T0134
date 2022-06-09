using System;

using Microsoft.CodeAnalysis;

using R5T.T0132;


namespace R5T.T0134
{
	[FunctionalityMarker]
	public interface ISyntaxNodeOperator : IFunctionalityMarker
	{
        public TNode Annotate<TNode>(
            TNode node,
            out ISyntaxNodeAnnotation<TNode> syntaxNodeAnnotation)
            where TNode : SyntaxNode
        {
            var output = Instances.SyntaxNodeOperator_Untyped.Annotate(
                node,
                out var annotation);

            syntaxNodeAnnotation = SyntaxNodeAnnotation.From<TNode>(annotation);

            return output;
        }

        public bool HasAnnotation<TNode>(
            TNode node,
            ISyntaxNodeAnnotation<TNode> annotation)
            where TNode : SyntaxNode
        {
            var output = node.HasAnnotation(annotation.SyntaxAnnotation);
            return output;
        }

        public void VerifyHasAnnotation<TNode>(
            TNode node,
            ISyntaxNodeAnnotation<TNode> annotation)
            where TNode : SyntaxNode
        {
            var hasAnnotation = this.HasAnnotation(
                node,
                annotation);

            if (!hasAnnotation)
            {
                throw new Exception("Has annotation verfication failed: node does not have annotation.");
            }
        }
    }
}