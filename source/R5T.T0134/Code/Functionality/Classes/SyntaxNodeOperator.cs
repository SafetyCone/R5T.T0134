using System;


namespace R5T.T0134
{
	public class SyntaxNodeOperator : ISyntaxNodeOperator
	{
		#region Infrastructure

	    public static SyntaxNodeOperator Instance { get; } = new();

	    private SyntaxNodeOperator()
	    {
	    }

	    #endregion
	}
}