using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType1<<Value>j__TPar, <Text>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <Text>j__TPar <Text>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <Value>j__TPar <Value>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType1(<Value>j__TPar Value, <Text>j__TPar Text)
    {
        this.<Value>i__Field = Value;
        this.<Text>i__Field = Text;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType1<<Value>j__TPar, <Text>j__TPar>;
        return (((type != null) && EqualityComparer<<Value>j__TPar>.Default.Equals(this.<Value>i__Field, type.<Value>i__Field)) && EqualityComparer<<Text>j__TPar>.Default.Equals(this.<Text>i__Field, type.<Text>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = 0x6cff705c;
        num = (-1521134295 * num) + EqualityComparer<<Value>j__TPar>.Default.GetHashCode(this.<Value>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<Text>j__TPar>.Default.GetHashCode(this.<Text>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ Value = ");
        builder.Append(this.<Value>i__Field);
        builder.Append(", Text = ");
        builder.Append(this.<Text>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <Text>j__TPar Text
    {
        get
        {
            return this.<Text>i__Field;
        }
    }

    public <Value>j__TPar Value
    {
        get
        {
            return this.<Value>i__Field;
        }
    }
}

