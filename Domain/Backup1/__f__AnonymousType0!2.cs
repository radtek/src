using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType0<<rt>j__TPar, <r>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <r>j__TPar <r>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <rt>j__TPar <rt>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType0(<rt>j__TPar rt, <r>j__TPar r)
    {
        this.<rt>i__Field = rt;
        this.<r>i__Field = r;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType0<<rt>j__TPar, <r>j__TPar>;
        return (((type != null) && EqualityComparer<<rt>j__TPar>.Default.Equals(this.<rt>i__Field, type.<rt>i__Field)) && EqualityComparer<<r>j__TPar>.Default.Equals(this.<r>i__Field, type.<r>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = 0x7be51bc4;
        num = (-1521134295 * num) + EqualityComparer<<rt>j__TPar>.Default.GetHashCode(this.<rt>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<r>j__TPar>.Default.GetHashCode(this.<r>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ rt = ");
        builder.Append(this.<rt>i__Field);
        builder.Append(", r = ");
        builder.Append(this.<r>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <r>j__TPar r
    {
        get
        {
            return this.<r>i__Field;
        }
    }

    public <rt>j__TPar rt
    {
        get
        {
            return this.<rt>i__Field;
        }
    }
}

