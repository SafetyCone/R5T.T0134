using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.CodeAnalysis;

using R5T.Magyar;

using R5T.T0134;

using Instances = R5T.T0134.Instances; /// <see cref="R5T.T0134.Documentation"/>


namespace System
{
    public static class SyntaxNodeExtensions
    {
        public static AnnotatedNode<TNode> AsAnnotatedNode<TNode>(this TNode node)
            where TNode : SyntaxNode
        {
            var output = AnnotatedNode.From(node);
            return output;
        }

        public static TNode Annotate<TNode>(this TNode node,
            out ISyntaxNodeAnnotation<TNode> syntaxNodeAnnotation)
            where TNode : SyntaxNode
        {
            return Instances.SyntaxNodeOperator.Annotate(node, out syntaxNodeAnnotation);
        }

        public static TParentNode Annotate<TParentNode, TNode>(this TParentNode parentNode,
            TNode node,
            out ISyntaxNodeAnnotation<TNode> nodeAnnotation)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var output = parentNode.AnnotateNode(
                node,
                out nodeAnnotation);

            return output;
        }

        public static TParentNode Annotate<TParentNode>(this TParentNode parentNode,
            SyntaxToken token,
            out ISyntaxTokenAnnotation tokenAnnotation)
            where TParentNode : SyntaxNode
        {
            var output = parentNode.AnnotateToken(
                token,
                out tokenAnnotation);

            return output;
        }

        public static TParentNode Annotate<TParentNode>(this TParentNode parentNode,
            SyntaxTrivia trivia,
            out ISyntaxTriviaAnnotation triviaAnnotation)
            where TParentNode : SyntaxNode
        {
            var output = parentNode.AnnotateTrivia(
                trivia,
                out triviaAnnotation);

            return output;
        }

        /// <summary>
        /// Annotates the node, replaces the existing node with the annotated node in the root node, and returns the root node and node annotation.
        /// </summary>
        public static TParentNode AnnotateNode<TParentNode, TNode>(this TParentNode parentNode,
            TNode node,
            out ISyntaxNodeAnnotation<TNode> nodeAnnotation)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var output = parentNode.AnnotateNode_Untyped(
                node,
                out var untypedAnnotation);

            nodeAnnotation = SyntaxNodeAnnotation.From<TNode>(untypedAnnotation);

            return output;
        }

        public static TParentNode AnnotateNodes<TParentNode, TNode>(this TParentNode parentNode,
            IEnumerable<TNode> nodes,
            out Dictionary<TNode, SyntaxNodeAnnotation<TNode>> annotationsByNode)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
        {
            var outputNode = parentNode.AnnotateNodes_Untyped(
                nodes,
                out var untypedAnnotationsByInputNode);

            annotationsByNode = untypedAnnotationsByInputNode.ToTypedAnnotationsByNode();

            return outputNode;
        }

        public static TParentNode AnnotateNodes<TParentNode, TNode, TTypedSyntaxAnnotation>(this TParentNode node,
            IEnumerable<TNode> nodes,
            Func<SyntaxAnnotation, TTypedSyntaxAnnotation> typedSyntaxAnnotationConstructor,
            out Dictionary<TNode, TTypedSyntaxAnnotation> annotationsByInputNode)
            where TParentNode : SyntaxNode
            where TNode : SyntaxNode
            where TTypedSyntaxAnnotation : ISyntaxNodeAnnotation<TNode>
        {
            var outputNode = node.AnnotateNodes_Untyped(
                nodes,
                out var untypedAnnotationsByInputNode);

            annotationsByInputNode = untypedAnnotationsByInputNode.ToTypedAnnotationsByNode(
                typedSyntaxAnnotationConstructor);

            return outputNode;
        }

        public static TParentNode AnnotateToken<TParentNode>(this TParentNode parentNode,
            SyntaxToken token,
            out ISyntaxTokenAnnotation tokenAnnotation)
            where TParentNode : SyntaxNode
        {
            var output = parentNode.AnnotateToken_Untyped(
                token,
                out var untypedAnnotation);

            tokenAnnotation = SyntaxTokenAnnotation.From(untypedAnnotation);

            return output;
        }

        public static TParentNode AnnotateTokens<TParentNode>(this TParentNode parentNode,
            IEnumerable<SyntaxToken> tokens,
            out Dictionary<SyntaxToken, SyntaxTokenAnnotation> annotationsByToken)
            where TParentNode : SyntaxNode
        {
            var outputNode = parentNode.AnnotateTokens_Untyped(
                tokens,
                out var untypedAnnotationsByInputToken);

            annotationsByToken = untypedAnnotationsByInputToken.ToTypedAnnotationsByToken();

            return outputNode;
        }

        public static TParentNode AnnotateTrivia<TParentNode>(this TParentNode parentNode,
            SyntaxTrivia trivia,
            out ISyntaxTriviaAnnotation triviaAnnotation)
            where TParentNode : SyntaxNode
        {
            var output = parentNode.AnnotateTrivia_Untyped(
                trivia,
                out var untypedAnnotation);

            triviaAnnotation = SyntaxTriviaAnnotation.From(untypedAnnotation);

            return output;
        }

        public static TParentNode AnnotateTrivias<TParentNode>(this TParentNode parentNode,
            IEnumerable<SyntaxTrivia> trivias,
            out Dictionary<SyntaxTrivia, SyntaxTriviaAnnotation> annotationsByTrivia)
            where TParentNode : SyntaxNode
        {
            var outputNode = parentNode.AnnotateTrivias_Untyped(
                trivias,
                out var untypedAnnotationsByInputTrivia);

            annotationsByTrivia = untypedAnnotationsByInputTrivia.ToTypedAnnotationsByTrivia();

            return outputNode;
        }

        public static TNode GetAnnotatedNode<TNode>(this SyntaxNode parentNode,
            ISyntaxNodeAnnotation<TNode> nodeAnnotation)
            where TNode : SyntaxNode
        {
            var output = parentNode.GetAnnotatedNodeOfType<TNode>(nodeAnnotation.SyntaxAnnotation);
            return output;
        }

        public static SyntaxToken GetAnnotatedToken(this SyntaxNode parentNode,
            ISyntaxTokenAnnotation tokenAnnotation)
        {
            var output = parentNode.GetAnnotatedToken(tokenAnnotation.SyntaxAnnotation);
            return output;
        }

        public static bool HasAnnotation<TNode>(this TNode node,
            ISyntaxNodeAnnotation<TNode> annotation)
            where TNode : SyntaxNode
        {
            var output = Instances.SyntaxNodeOperator.HasAnnotation(node, annotation);
            return output;
        }

        public static WasFound<TNode> HasAnnotatedNode<TNode>(this SyntaxNode parentNode,
            ISyntaxNodeAnnotation<TNode> nodeAnnotation)
            where TNode : SyntaxNode
        {
            var output = parentNode.HasAnnotatedNodeOfType<TNode>(nodeAnnotation.SyntaxAnnotation);
            return output;
        }

        public static void VerifyHasAnnotation<TNode>(this TNode node,
            ISyntaxNodeAnnotation<TNode> annotation)
            where TNode : SyntaxNode
        {
            Instances.SyntaxNodeOperator.VerifyHasAnnotation(
                node,
                annotation);
        }
    }
}
