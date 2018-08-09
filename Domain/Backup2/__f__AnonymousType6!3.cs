using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType6<<ResourceQuantity>j__TPar, <ResourcePrice>j__TPar, <ResourceId>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ResourceId>j__TPar <ResourceId>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ResourcePrice>j__TPar <ResourcePrice>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ResourceQuantity>j__TPar <ResourceQuantity>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType6(<ResourceQuantity>j__TPar ResourceQuantity, <ResourcePrice>j__TPar ResourcePrice, <ResourceId>j__TPar ResourceId)
    {
        this.<ResourceQuantity>i__Field = ResourceQuantity;
        this.<ResourcePrice>i__Field = ResourcePrice;
        this.<ResourceId>i__Field = ResourceId;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType6<<ResourceQuantity>j__TPar, <ResourcePrice>j__TPar, <ResourceId>j__TPar>;
        return ((((type != null) && EqualityComparer<<ResourceQuantity>j__TPar>.Default.Equals(this.<ResourceQuantity>i__Field, type.<ResourceQuantity>i__Field)) && EqualityComparer<<ResourcePrice>j__TPar>.Default.Equals(this.<ResourcePrice>i__Field, type.<ResourcePrice>i__Field)) && EqualityComparer<<ResourceId>j__TPar>.Default.Equals(this.<ResourceId>i__Field, type.<ResourceId>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = -72573536;
        num = (-1521134295 * num) + EqualityComparer<<ResourceQuantity>j__TPar>.Default.GetHashCode(this.<ResourceQuantity>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<ResourcePrice>j__TPar>.Default.GetHashCode(this.<ResourcePrice>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<ResourceId>j__TPar>.Default.GetHashCode(this.<ResourceId>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ ResourceQuantity = ");
        builder.Append(this.<ResourceQuantity>i__Field);
        builder.Append(", ResourcePrice = ");
        builder.Append(this.<ResourcePrice>i__Field);
        builder.Append(", ResourceId = ");
        builder.Append(this.<ResourceId>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <ResourceId>j__TPar ResourceId
    {
        get
        {
            return this.<ResourceId>i__Field;
        }
    }

    public <ResourcePrice>j__TPar ResourcePrice
    {
        get
        {
            return this.<ResourcePrice>i__Field;
        }
    }

    public <ResourceQuantity>j__TPar ResourceQuantity
    {
        get
        {
            return this.<ResourceQuantity>i__Field;
        }
    }
}

