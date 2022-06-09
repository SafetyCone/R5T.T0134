using System;

using Microsoft.CodeAnalysis;


namespace R5T.T0134
{
    public static class AnnotatedNodeExtensions
    {
        /// <summary>
        /// An annotated node is valid if the annotated node's node has the annotated node's annotation.
        /// </summary>
        public static bool IsValid<TNode>(this AnnotatedNode<TNode> annotatedNode)
            where TNode : SyntaxNode
        {
            var output = annotatedNode.Node.HasAnnotation(annotatedNode.Annotation);
            return output;
        }

        /// <summary>
        /// Tests if the node is valid, and if not, throws an exception.
        /// </summary>
        public static void Verify<TNode>(this AnnotatedNode<TNode> annotatedNode)
            where TNode : SyntaxNode
        {
            var isValid = annotatedNode.IsValid();
            if(!isValid)
            {
                throw new Exception("Invalid annotate node: node did not have annotation.");
            }
        }
    }
}
