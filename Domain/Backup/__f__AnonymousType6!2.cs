using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType6<<cl>j__TPar, <p>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <cl>j__TPar <cl>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <p>j__TPar <p>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType6(<cl>j__TPar cl, <p>j__TPar p)
    {
        this.<cl>i__Field = cl;
        this.<p>i__Field = p;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType6<<cl>j__TPar, <p>j__TPar>;
        return (((type != null) && EqualityComparer<<cl>j__TPar>.Default.Equals(this.<cl>i__Field, type.<cl>i__Field)) && EqualityComparer<<p>j__TPar>.Default.Equals(this.<p>i__Field, type.<p>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = 0x21b64630;
        num = (-1521134295 * num) + EqualityComparer<<cl>j__TPar>.Default.GetHashCode(this.<cl>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<p>j__TPar>.Default.GetHashCode(this.<p>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ cl = ");
        builder.Append(this.<cl>i__Field);
        builder.Append(", p = ");
        builder.Append(this.<p>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <cl>j__TPar cl
    {
        get
        {
            return this.<cl>i__Field;
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

