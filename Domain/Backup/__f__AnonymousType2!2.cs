using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType2<<mtr>j__TPar, <mt>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <mt>j__TPar <mt>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <mtr>j__TPar <mtr>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType2(<mtr>j__TPar mtr, <mt>j__TPar mt)
    {
        this.<mtr>i__Field = mtr;
        this.<mt>i__Field = mt;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType2<<mtr>j__TPar, <mt>j__TPar>;
        return (((type != null) && EqualityComparer<<mtr>j__TPar>.Default.Equals(this.<mtr>i__Field, type.<mtr>i__Field)) && EqualityComparer<<mt>j__TPar>.Default.Equals(this.<mt>i__Field, type.<mt>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = -1334657358;
        num = (-1521134295 * num) + EqualityComparer<<mtr>j__TPar>.Default.GetHashCode(this.<mtr>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<mt>j__TPar>.Default.GetHashCode(this.<mt>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ mtr = ");
        builder.Append(this.<mtr>i__Field);
        builder.Append(", mt = ");
        builder.Append(this.<mt>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <mt>j__TPar mt
    {
        get
        {
            return this.<mt>i__Field;
        }
    }

    public <mtr>j__TPar mtr
    {
        get
        {
            return this.<mtr>i__Field;
        }
    }
}

