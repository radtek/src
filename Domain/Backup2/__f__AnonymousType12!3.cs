using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType12<<resourceId>j__TPar, <resourcePrice>j__TPar, <resourceQuantity>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <resourceId>j__TPar <resourceId>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <resourcePrice>j__TPar <resourcePrice>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <resourceQuantity>j__TPar <resourceQuantity>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType12(<resourceId>j__TPar resourceId, <resourcePrice>j__TPar resourcePrice, <resourceQuantity>j__TPar resourceQuantity)
    {
        this.<resourceId>i__Field = resourceId;
        this.<resourcePrice>i__Field = resourcePrice;
        this.<resourceQuantity>i__Field = resourceQuantity;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType12<<resourceId>j__TPar, <resourcePrice>j__TPar, <resourceQuantity>j__TPar>;
        return ((((type != null) && EqualityComparer<<resourceId>j__TPar>.Default.Equals(this.<resourceId>i__Field, type.<resourceId>i__Field)) && EqualityComparer<<resourcePrice>j__TPar>.Default.Equals(this.<resourcePrice>i__Field, type.<resourcePrice>i__Field)) && EqualityComparer<<resourceQuantity>j__TPar>.Default.Equals(this.<resourceQuantity>i__Field, type.<resourceQuantity>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = -1989702732;
        num = (-1521134295 * num) + EqualityComparer<<resourceId>j__TPar>.Default.GetHashCode(this.<resourceId>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<resourcePrice>j__TPar>.Default.GetHashCode(this.<resourcePrice>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<resourceQuantity>j__TPar>.Default.GetHashCode(this.<resourceQuantity>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ resourceId = ");
        builder.Append(this.<resourceId>i__Field);
        builder.Append(", resourcePrice = ");
        builder.Append(this.<resourcePrice>i__Field);
        builder.Append(", resourceQuantity = ");
        builder.Append(this.<resourceQuantity>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <resourceId>j__TPar resourceId
    {
        get
        {
            return this.<resourceId>i__Field;
        }
    }

    public <resourcePrice>j__TPar resourcePrice
    {
        get
        {
            return this.<resourcePrice>i__Field;
        }
    }

    public <resourceQuantity>j__TPar resourceQuantity
    {
        get
        {
            return this.<resourceQuantity>i__Field;
        }
    }
}

