using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType1a<<CBSCode>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <CBSCode>j__TPar <CBSCode>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType1a(<CBSCode>j__TPar CBSCode)
    {
        this.<CBSCode>i__Field = CBSCode;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var typea = value as <>f__AnonymousType1a<<CBSCode>j__TPar>;
        return ((typea != null) && EqualityComparer<<CBSCode>j__TPar>.Default.Equals(this.<CBSCode>i__Field, typea.<CBSCode>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = 0x5b7ad438;
        return ((-1521134295 * num) + EqualityComparer<<CBSCode>j__TPar>.Default.GetHashCode(this.<CBSCode>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ CBSCode = ");
        builder.Append(this.<CBSCode>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <CBSCode>j__TPar CBSCode
    {
        get
        {
            return this.<CBSCode>i__Field;
        }
    }
}

