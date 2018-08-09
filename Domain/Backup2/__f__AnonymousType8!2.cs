using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType8<<t>j__TPar, <p>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <p>j__TPar <p>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <t>j__TPar <t>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType8(<t>j__TPar t, <p>j__TPar p)
    {
        this.<t>i__Field = t;
        this.<p>i__Field = p;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType8<<t>j__TPar, <p>j__TPar>;
        return (((type != null) && EqualityComparer<<t>j__TPar>.Default.Equals(this.<t>i__Field, type.<t>i__Field)) && EqualityComparer<<p>j__TPar>.Default.Equals(this.<p>i__Field, type.<p>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = 0x5156f8a9;
        num = (-1521134295 * num) + EqualityComparer<<t>j__TPar>.Default.GetHashCode(this.<t>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<p>j__TPar>.Default.GetHashCode(this.<p>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ t = ");
        builder.Append(this.<t>i__Field);
        builder.Append(", p = ");
        builder.Append(this.<p>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <p>j__TPar p
    {
        get
        {
            return this.<p>i__Field;
        }
    }

    public <t>j__TPar t
    {
        get
        {
            return this.<t>i__Field;
        }
    }
}

