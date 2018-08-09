using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType22<<m>j__TPar, <n>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <m>j__TPar <m>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <n>j__TPar <n>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType22(<m>j__TPar m, <n>j__TPar n)
    {
        this.<m>i__Field = m;
        this.<n>i__Field = n;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType22<<m>j__TPar, <n>j__TPar>;
        return (((type != null) && EqualityComparer<<m>j__TPar>.Default.Equals(this.<m>i__Field, type.<m>i__Field)) && EqualityComparer<<n>j__TPar>.Default.Equals(this.<n>i__Field, type.<n>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = 0x1b13698d;
        num = (-1521134295 * num) + EqualityComparer<<m>j__TPar>.Default.GetHashCode(this.<m>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<n>j__TPar>.Default.GetHashCode(this.<n>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ m = ");
        builder.Append(this.<m>i__Field);
        builder.Append(", n = ");
        builder.Append(this.<n>i__Field);
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

    public <n>j__TPar n
    {
        get
        {
            return this.<n>i__Field;
        }
    }
}

