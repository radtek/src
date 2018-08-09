using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType10<<State>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <State>j__TPar <State>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType10(<State>j__TPar State)
    {
        this.<State>i__Field = State;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType10<<State>j__TPar>;
        return ((type != null) && EqualityComparer<<State>j__TPar>.Default.Equals(this.<State>i__Field, type.<State>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = -95102158;
        return ((-1521134295 * num) + EqualityComparer<<State>j__TPar>.Default.GetHashCode(this.<State>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ State = ");
        builder.Append(this.<State>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <State>j__TPar State
    {
        get
        {
            return this.<State>i__Field;
        }
    }
}

