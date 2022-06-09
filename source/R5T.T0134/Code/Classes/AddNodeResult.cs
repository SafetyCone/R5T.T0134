using System;

using Microsoft.CodeAnalysis;

using R5T.T0135;


namespace R5T.T0134
{
    /// <summary>
    /// Represents the result of adding a descendant to a node.
    /// Allows the node to which a descendant was added, and an annotation to the descendant was added, to travel together.
    /// </summary>
    public class AddNodeResult<TParentNode, TNode> : INodeResultWithAnnotation<TParentNode>
        where TParentNode : SyntaxNode
        where TNode : SyntaxNode
    {
        #region Static

        public static implicit operator TParentNode(AddNodeResult<TParentNode, TNode> result)
        {
            return result.ParentNode;
        }

        // Cannot define conversion operators for interfaces, so implicit conversion to ISyntaxNodeAnnotation<TNode> is out.
        // And the conversion operator for SyntaxNodeAnnotation<TNode> is useless, since C# will not request the implicit conversion to SyntaxNodeAnnotation<TNode> if an ISyntaxNodeAnnotation<TNode> instance is requested.

        #endregion


        /// <summary>
        /// The parent node to which a descendant was added.
        /// </summary>
        public TParentNode ParentNode { get; }
        /// <summary>
        /// An annotation to the descendant that was added.
        /// </summary>
        public ISyntaxNodeAnnotation<TNode> DescendantAnnotation { get; }

        TParentNode INodeResultWithAnnotation<TParentNode>.Node => this.ParentNode;
        SyntaxAnnotation INodeResultWithAnnotation<TParentNode>.SyntaxAnnotation => this.DescendantAnnotation.SyntaxAnnotation;


        public AddNodeResult(
            TParentNode parentNode,
            ISyntaxNodeAnnotation<TNode> descendantAnnotation)
        {
            this.ParentNode = parentNode;
            this.DescendantAnnotation = descendantAnnotation;
        }

        public void Deconstruct(
            out TParentNode parentNode,
            out ISyntaxNodeAnnotation<TNode> descendantAnnotation)
        {
            parentNode = this.ParentNode;
            descendantAnnotation = this.DescendantAnnotation;
        }
    }


    public static class AddNodeResult
    {
        public static AddNodeResult<TParentNode, TNode> From<TParentNode, TNode>(
            TParentNode parentNode,
            ISyntaxNodeAnnotation<TNode> descendantAnnotation)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var output = new AddNodeResult<TParentNode, TNode>(
                parentNode,
                descendantAnnotation);

            return output;
        }
    }
}
