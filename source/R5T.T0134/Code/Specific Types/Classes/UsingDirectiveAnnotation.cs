﻿using System;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace R5T.T0134
{
    public class UsingDirectiveAnnotation : SyntaxNodeAnnotation<UsingDirectiveSyntax>
    {
        #region Static

        public static UsingDirectiveAnnotation From(SyntaxAnnotation annotation)
        {
            var output = new UsingDirectiveAnnotation(annotation);
            return output;
        }

        #endregion


        public UsingDirectiveAnnotation(SyntaxAnnotation annotation)
            : base(annotation)
        {
        }
    }
}
