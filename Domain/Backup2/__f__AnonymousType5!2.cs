using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType5<<<>h__TransparentIdentifier22>j__TPar, <mtr>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <<>h__TransparentIdentifier22>j__TPar <<>h__TransparentIdentifier22>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <mtr>j__TPar <mtr>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType5(<<>h__TransparentIdentifier22>j__TPar <>h__TransparentIdentifier22, <mtr>j__TPar mtr)
    {
        this.<<>h__TransparentIdentifier22>i__Field = <>h__TransparentIdentifier22;
        this.<mtr>i__Field = mtr;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType5<<<>h__TransparentIdentifier22>j__TPar, <mtr>j__TPar>;
        return (((type != null) && EqualityComparer<<<>h__TransparentIdentifier22>j__TPar>.Default.Equals(this.<<>h__TransparentIdentifier22>i__Field, type.<<>h__TransparentIdentifier22>i__Field)) && EqualityComparer<<mtr>j__TPar>.Default.Equals(this.<mtr>i__Field, type.<mtr>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = 0x2f0cd7f0;
        num = (-1521134295 * num) + EqualityComparer<<<>h__TransparentIdentifier22>j__TPar>.Default.GetHashCode(this.<<>h__TransparentIdentifier22>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<mtr>j__TPar>.Default.GetHashCode(this.<mtr>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ <>h__TransparentIdentifier22 = ");
        builder.Append(this.<<>h__TransparentIdentifier22>i__Field);
        builder.Append(", mtr = ");
        builder.Append(this.<mtr>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <<>h__TransparentIdentifier22>j__TPar <>h__TransparentIdentifier22
    {
        get
        {
            return this.<<>h__TransparentIdentifier22>i__Field;
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
