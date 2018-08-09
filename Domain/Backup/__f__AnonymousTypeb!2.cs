using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousTypeb<<p1>j__TPar, <p2>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <p1>j__TPar <p1>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <p2>j__TPar <p2>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousTypeb(<p1>j__TPar p1, <p2>j__TPar p2)
    {
        this.<p1>i__Field = p1;
        this.<p2>i__Field = p2;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var typeb = value as <>f__AnonymousTypeb<<p1>j__TPar, <p2>j__TPar>;
        return (((typeb != null) && EqualityComparer<<p1>j__TPar>.Default.Equals(this.<p1>i__Field, typeb.<p1>i__Field)) && EqualityComparer<<p2>j__TPar>.Default.Equals(this.<p2>i__Field, typeb.<p2>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = -1644984537;
        num = (-1521134295 * num) + EqualityComparer<<p1>j__TPar>.Default.GetHashCode(this.<p1>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<p2>j__TPar>.Default.GetHashCode(this.<p2>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ p1 = ");
        builder.Append(this.<p1>i__Field);
        builder.Append(", p2 = ");
        builder.Append(this.<p2>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <p1>j__TPar p1
    {
        get
        {
            return this.<p1>i__Field;
        }
    }

    public <p2>j__TPar p2
    {
        get
        {
            return this.<p2>i__Field;
        }
    }
}

