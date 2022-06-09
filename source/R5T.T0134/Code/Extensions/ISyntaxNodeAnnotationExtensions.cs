using System;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;

using R5T.T0134;


namespace System
{
    public static class ISyntaxNodeAnnotationExtensions
    {
        public static TNode GetNode<TNode>(this ISyntaxNodeAnnotation<TNode> annotation,
            SyntaxNode parentNode)
            where TNode : SyntaxNode
        {
            var output = parentNode.GetAnnotatedNode(annotation);
            return output;
        }

        public static TParentNode Modify<TParentNode, TNode>(this ISyntaxNodeAnnotation<TNode> annotation,
            TParentNode parentNode,
            Func<TNode, TNode> modifier)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var node = annotation.GetNode(parentNode);

            var modifiedNode = modifier(node);

            var outputParent = parentNode.ReplaceNode_Better(node, modifiedNode);
            return outputParent;
        }
    }
}
