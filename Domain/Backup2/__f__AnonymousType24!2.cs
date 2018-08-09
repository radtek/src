using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType24<<<>h__TransparentIdentifierf>j__TPar, <l>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <<>h__TransparentIdentifierf>j__TPar <<>h__TransparentIdentifierf>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <l>j__TPar <l>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType24(<<>h__TransparentIdentifierf>j__TPar <>h__TransparentIdentifierf, <l>j__TPar l)
    {
        this.<<>h__TransparentIdentifierf>i__Field = <>h__TransparentIdentifierf;
        this.<l>i__Field = l;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType24<<<>h__TransparentIdentifierf>j__TPar, <l>j__TPar>;
        return (((type != null) && EqualityComparer<<<>h__TransparentIdentifierf>j__TPar>.Default.Equals(this.<<>h__TransparentIdentifierf>i__Field, type.<<>h__TransparentIdentifierf>i__Field)) && EqualityComparer<<l>j__TPar>.Default.Equals(this.<l>i__Field, type.<l>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = -1825781099;
        num = (-1521134295 * num) + EqualityComparer<<<>h__TransparentIdentifierf>j__TPar>.Default.GetHashCode(this.<<>h__TransparentIdentifierf>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<l>j__TPar>.Default.GetHashCode(this.<l>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ <>h__TransparentIdentifierf = ");
        builder.Append(this.<<>h__TransparentIdentifierf>i__Field);
        builder.Append(", l = ");
        builder.Append(this.<l>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <<>h__TransparentIdentifierf>j__TPar <>h__TransparentIdentifierf
    {
        get
        {
            return this.<<>h__TransparentIdentifierf>i__Field;
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

