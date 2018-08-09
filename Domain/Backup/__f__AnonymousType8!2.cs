using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType8<<m>j__TPar, <p>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <m>j__TPar <m>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <p>j__TPar <p>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType8(<m>j__TPar m, <p>j__TPar p)
    {
        this.<m>i__Field = m;
        this.<p>i__Field = p;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType8<<m>j__TPar, <p>j__TPar>;
        return (((type != null) && EqualityComparer<<m>j__TPar>.Default.Equals(this.<m>i__Field, type.<m>i__Field)) && EqualityComparer<<p>j__TPar>.Default.Equals(this.<p>i__Field, type.<p>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = -216453624;
        num = (-1521134295 * num) + EqualityComparer<<m>j__TPar>.Default.GetHashCode(this.<m>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<p>j__TPar>.Default.GetHashCode(this.<p>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ m = ");
        builder.Append(this.<m>i__Field);
        builder.Append(", p = ");
        builder.Append(this.<p>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <m>j__TPar m
    {
        get
        {
            return this.<m>i__Field;
        }
    }

    public <p>j__TPar p
    {
        get
        {
            return this.<p>i__Field;
        }
    }
}

