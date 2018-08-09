using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType1<<ResourceId>j__TPar, <ResourceQuantity>j__TPar, <ResourcePrice>j__TPar, <InputUser>j__TPar, <InputDate>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <InputDate>j__TPar <InputDate>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <InputUser>j__TPar <InputUser>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ResourceId>j__TPar <ResourceId>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ResourcePrice>j__TPar <ResourcePrice>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ResourceQuantity>j__TPar <ResourceQuantity>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType1(<ResourceId>j__TPar ResourceId, <ResourceQuantity>j__TPar ResourceQuantity, <ResourcePrice>j__TPar ResourcePrice, <InputUser>j__TPar InputUser, <InputDate>j__TPar InputDate)
    {
        this.<ResourceId>i__Field = ResourceId;
        this.<ResourceQuantity>i__Field = ResourceQuantity;
        this.<ResourcePrice>i__Field = ResourcePrice;
        this.<InputUser>i__Field = InputUser;
        this.<InputDate>i__Field = InputDate;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType1<<ResourceId>j__TPar, <ResourceQuantity>j__TPar, <ResourcePrice>j__TPar, <InputUser>j__TPar, <InputDate>j__TPar>;
        return (((((type != null) && EqualityComparer<<ResourceId>j__TPar>.Default.Equals(this.<ResourceId>i__Field, type.<ResourceId>i__Field)) && (EqualityComparer<<ResourceQuantity>j__TPar>.Default.Equals(this.<ResourceQuantity>i__Field, type.<ResourceQuantity>i__Field) && EqualityComparer<<ResourcePrice>j__TPar>.Default.Equals(this.<ResourcePrice>i__Field, type.<ResourcePrice>i__Field))) && EqualityComparer<<InputUser>j__TPar>.Default.Equals(this.<InputUser>i__Field, type.<InputUser>i__Field)) && EqualityComparer<<InputDate>j__TPar>.Default.Equals(this.<InputDate>i__Field, type.<InputDate>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = 0x50b58597;
        num = (-1521134295 * num) + EqualityComparer<<ResourceId>j__TPar>.Default.GetHashCode(this.<ResourceId>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<ResourceQuantity>j__TPar>.Default.GetHashCode(this.<ResourceQuantity>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<ResourcePrice>j__TPar>.Default.GetHashCode(this.<ResourcePrice>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<InputUser>j__TPar>.Default.GetHashCode(this.<InputUser>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<InputDate>j__TPar>.Default.GetHashCode(this.<InputDate>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ ResourceId = ");
        builder.Append(this.<ResourceId>i__Field);
        builder.Append(", ResourceQuantity = ");
        builder.Append(this.<ResourceQuantity>i__Field);
        builder.Append(", ResourcePrice = ");
        builder.Append(this.<ResourcePrice>i__Field);
        builder.Append(", InputUser = ");
        builder.Append(this.<InputUser>i__Field);
        builder.Append(", InputDate = ");
        builder.Append(this.<InputDate>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <InputDate>j__TPar InputDate
    {
        get
        {
            return this.<InputDate>i__Field;
        }
    }

    public <InputUser>j__TPar InputUser
    {
        get
        {
            return this.<InputUser>i__Field;
        }
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

