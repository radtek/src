using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousTypef<<OrderNumber>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <OrderNumber>j__TPar <OrderNumber>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousTypef(<OrderNumber>j__TPar OrderNumber)
    {
        this.<OrderNumber>i__Field = OrderNumber;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var typef = value as <>f__AnonymousTypef<<OrderNumber>j__TPar>;
        return ((typef != null) && EqualityComparer<<OrderNumber>j__TPar>.Default.Equals(this.<OrderNumber>i__Field, typef.<OrderNumber>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = 0x419dc0eb;
        return ((-1521134295 * num) + EqualityComparer<<OrderNumber>j__TPar>.Default.GetHashCode(this.<OrderNumber>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ OrderNumber = ");
        builder.Append(this.<OrderNumber>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <OrderNumber>j__TPar OrderNumber
    {
        get
        {
            return this.<OrderNumber>i__Field;
        }
    }
}

