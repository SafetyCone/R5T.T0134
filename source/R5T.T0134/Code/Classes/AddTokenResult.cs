using System;

using Microsoft.CodeAnalysis;

using R5T.T0135;


namespace R5T.T0134
{
    /// <summary>
    /// Represents the result of adding a descendant to a node.
    /// Allows the node to which a descendant was added, and an annotation to the descendant was added, to travel together.
    /// </summary>
    public class AddTokenResult<TParentNode> : INodeResultWithAnnotation<TParentNode>
        where TParentNode : SyntaxNode
    {
        #region Static

        public static implicit operator TParentNode(AddTokenResult<TParentNode> result)
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
        public ISyntaxTokenAnnotation DescendantAnnotation { get; }

        TParentNode INodeResultWithAnnotation<TParentNode>.Node => this.ParentNode;
        SyntaxAnnotation INodeResultWithAnnotation<TParentNode>.SyntaxAnnotation => this.DescendantAnnotation.SyntaxAnnotation;


        public AddTokenResult(
            TParentNode parentNode,
            ISyntaxTokenAnnotation descendantAnnotation)
        {
            this.ParentNode = parentNode;
            this.DescendantAnnotation = descendantAnnotation;
        }

        public void Deconstruct(
            out TParentNode parentNode,
            out ISyntaxTokenAnnotation descendantAnnotation)
        {
            parentNode = this.ParentNode;
            descendantAnnotation = this.DescendantAnnotation;
        }
    }


    public static class AddTokenResult
    {
        public static AddTokenResult<TParentNode> From<TParentNode>(
            TParentNode parentNode,
            ISyntaxTokenAnnotation descendantAnnotation)
            where TParentNode : SyntaxNode
        {
            var output = new AddTokenResult<TParentNode>(
                parentNode,
                descendantAnnotation);

            return output;
        }
    }
}
