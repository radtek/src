using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType1<<taskRes>j__TPar, <task>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <task>j__TPar <task>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <taskRes>j__TPar <taskRes>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType1(<taskRes>j__TPar taskRes, <task>j__TPar task)
    {
        this.<taskRes>i__Field = taskRes;
        this.<task>i__Field = task;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType1<<taskRes>j__TPar, <task>j__TPar>;
        return (((type != null) && EqualityComparer<<taskRes>j__TPar>.Default.Equals(this.<taskRes>i__Field, type.<taskRes>i__Field)) && EqualityComparer<<task>j__TPar>.Default.Equals(this.<task>i__Field, type.<task>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = -850829351;
        num = (-1521134295 * num) + EqualityComparer<<taskRes>j__TPar>.Default.GetHashCode(this.<taskRes>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<task>j__TPar>.Default.GetHashCode(this.<task>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ taskRes = ");
        builder.Append(this.<taskRes>i__Field);
        builder.Append(", task = ");
        builder.Append(this.<task>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <task>j__TPar task
    {
        get
        {
            return this.<task>i__Field;
        }
    }

    public <taskRes>j__TPar taskRes
    {
        get
        {
            return this.<taskRes>i__Field;
        }
    }
}

