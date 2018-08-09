using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType9<<m>j__TPar, <y>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <m>j__TPar <m>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <y>j__TPar <y>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType9(<m>j__TPar m, <y>j__TPar y)
    {
        this.<m>i__Field = m;
        this.<y>i__Field = y;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType9<<m>j__TPar, <y>j__TPar>;
        return (((type != null) && EqualityComparer<<m>j__TPar>.Default.Equals(this.<m>i__Field, type.<m>i__Field)) && EqualityComparer<<y>j__TPar>.Default.Equals(this.<y>i__Field, type.<y>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = -2022637894;
        num = (-1521134295 * num) + EqualityComparer<<m>j__TPar>.Default.GetHashCode(this.<m>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<y>j__TPar>.Default.GetHashCode(this.<y>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ m = ");
        builder.Append(this.<m>i__Field);
        builder.Append(", y = ");
        builder.Append(this.<y>i__Field);
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

    public <y>j__TPar y
    {
        get
        {
            return this.<y>i__Field;
        }
    }
}

