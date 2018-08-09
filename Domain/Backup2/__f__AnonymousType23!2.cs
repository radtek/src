using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType23<<<>h__TransparentIdentifierd>j__TPar, <l>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <<>h__TransparentIdentifierd>j__TPar <<>h__TransparentIdentifierd>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <l>j__TPar <l>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType23(<<>h__TransparentIdentifierd>j__TPar <>h__TransparentIdentifierd, <l>j__TPar l)
    {
        this.<<>h__TransparentIdentifierd>i__Field = <>h__TransparentIdentifierd;
        this.<l>i__Field = l;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType23<<<>h__TransparentIdentifierd>j__TPar, <l>j__TPar>;
        return (((type != null) && EqualityComparer<<<>h__TransparentIdentifierd>j__TPar>.Default.Equals(this.<<>h__TransparentIdentifierd>i__Field, type.<<>h__TransparentIdentifierd>i__Field)) && EqualityComparer<<l>j__TPar>.Default.Equals(this.<l>i__Field, type.<l>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = -1258689021;
        num = (-1521134295 * num) + EqualityComparer<<<>h__TransparentIdentifierd>j__TPar>.Default.GetHashCode(this.<<>h__TransparentIdentifierd>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<l>j__TPar>.Default.GetHashCode(this.<l>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ <>h__TransparentIdentifierd = ");
        builder.Append(this.<<>h__TransparentIdentifierd>i__Field);
        builder.Append(", l = ");
        builder.Append(this.<l>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <<>h__TransparentIdentifierd>j__TPar <>h__TransparentIdentifierd
    {
        get
        {
            return this.<<>h__TransparentIdentifierd>i__Field;
        }
    }

    public <l>j__TPar l
    {
        get
        {
            return this.<l>i__Field;
        }
    }
}

