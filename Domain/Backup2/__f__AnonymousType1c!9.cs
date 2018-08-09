using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType1c<<Id>j__TPar, <ResourceId>j__TPar, <TaskId>j__TPar, <ResourceCode>j__TPar, <ResourceName>j__TPar, <UnitPrice>j__TPar, <Quantity>j__TPar, <Amount>j__TPar, <PrjId>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <Amount>j__TPar <Amount>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <Id>j__TPar <Id>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <PrjId>j__TPar <PrjId>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <Quantity>j__TPar <Quantity>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ResourceCode>j__TPar <ResourceCode>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ResourceId>j__TPar <ResourceId>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ResourceName>j__TPar <ResourceName>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <TaskId>j__TPar <TaskId>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <UnitPrice>j__TPar <UnitPrice>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType1c(<Id>j__TPar Id, <ResourceId>j__TPar ResourceId, <TaskId>j__TPar TaskId, <ResourceCode>j__TPar ResourceCode, <ResourceName>j__TPar ResourceName, <UnitPrice>j__TPar UnitPrice, <Quantity>j__TPar Quantity, <Amount>j__TPar Amount, <PrjId>j__TPar PrjId)
    {
        this.<Id>i__Field = Id;
        this.<ResourceId>i__Field = ResourceId;
        this.<TaskId>i__Field = TaskId;
        this.<ResourceCode>i__Field = ResourceCode;
        this.<ResourceName>i__Field = ResourceName;
        this.<UnitPrice>i__Field = UnitPrice;
        this.<Quantity>i__Field = Quantity;
        this.<Amount>i__Field = Amount;
        this.<PrjId>i__Field = PrjId;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var typec = value as <>f__AnonymousType1c<<Id>j__TPar, <ResourceId>j__TPar, <TaskId>j__TPar, <ResourceCode>j__TPar, <ResourceName>j__TPar, <UnitPrice>j__TPar, <Quantity>j__TPar, <Amount>j__TPar, <PrjId>j__TPar>;
        return ((((((typec != null) && EqualityComparer<<Id>j__TPar>.Default.Equals(this.<Id>i__Field, typec.<Id>i__Field)) && (EqualityComparer<<ResourceId>j__TPar>.Default.Equals(this.<ResourceId>i__Field, typec.<ResourceId>i__Field) && EqualityComparer<<TaskId>j__TPar>.Default.Equals(this.<TaskId>i__Field, typec.<TaskId>i__Field))) && ((EqualityComparer<<ResourceCode>j__TPar>.Default.Equals(this.<ResourceCode>i__Field, typec.<ResourceCode>i__Field) && EqualityComparer<<ResourceName>j__TPar>.Default.Equals(this.<ResourceName>i__Field, typec.<ResourceName>i__Field)) && (EqualityComparer<<UnitPrice>j__TPar>.Default.Equals(this.<UnitPrice>i__Field, typec.<UnitPrice>i__Field) && EqualityComparer<<Quantity>j__TPar>.Default.Equals(this.<Quantity>i__Field, typec.<Quantity>i__Field)))) && EqualityComparer<<Amount>j__TPar>.Default.Equals(this.<Amount>i__Field, typec.<Amount>i__Field)) && EqualityComparer<<PrjId>j__TPar>.Default.Equals(this.<PrjId>i__Field, typec.<PrjId>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = -287717715;
        num = (-1521134295 * num) + EqualityComparer<<Id>j__TPar>.Default.GetHashCode(this.<Id>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<ResourceId>j__TPar>.Default.GetHashCode(this.<ResourceId>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<TaskId>j__TPar>.Default.GetHashCode(this.<TaskId>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<ResourceCode>j__TPar>.Default.GetHashCode(this.<ResourceCode>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<ResourceName>j__TPar>.Default.GetHashCode(this.<ResourceName>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<UnitPrice>j__TPar>.Default.GetHashCode(this.<UnitPrice>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<Quantity>j__TPar>.Default.GetHashCode(this.<Quantity>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<Amount>j__TPar>.Default.GetHashCode(this.<Amount>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<PrjId>j__TPar>.Default.GetHashCode(this.<PrjId>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ Id = ");
        builder.Append(this.<Id>i__Field);
        builder.Append(", ResourceId = ");
        builder.Append(this.<ResourceId>i__Field);
        builder.Append(", TaskId = ");
        builder.Append(this.<TaskId>i__Field);
        builder.Append(", ResourceCode = ");
        builder.Append(this.<ResourceCode>i__Field);
        builder.Append(", ResourceName = ");
        builder.Append(this.<ResourceName>i__Field);
        builder.Append(", UnitPrice = ");
        builder.Append(this.<UnitPrice>i__Field);
        builder.Append(", Quantity = ");
        builder.Append(this.<Quantity>i__Field);
        builder.Append(", Amount = ");
        builder.Append(this.<Amount>i__Field);
        builder.Append(", PrjId = ");
        builder.Append(this.<PrjId>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <Amount>j__TPar Amount
    {
        get
        {
            return this.<Amount>i__Field;
        }
    }

    public <Id>j__TPar Id
    {
        get
        {
            return this.<Id>i__Field;
        }
    }

    public <PrjId>j__TPar PrjId
    {
        get
        {
            return this.<PrjId>i__Field;
        }
    }

    public <Quantity>j__TPar Quantity
    {
        get
        {
            return this.<Quantity>i__Field;
        }
    }

    public <ResourceCode>j__TPar ResourceCode
    {
        get
        {
            return this.<ResourceCode>i__Field;
        }
    }

    public <ResourceId>j__TPar ResourceId
    {
        get
        {
            return this.<ResourceId>i__Field;
        }
    }

    public <ResourceName>j__TPar ResourceName
    {
        get
        {
            return this.<ResourceName>i__Field;
        }
    }

    public <TaskId>j__TPar TaskId
    {
        get
        {
            return this.<TaskId>i__Field;
        }
    }

    public <UnitPrice>j__TPar UnitPrice
    {
        get
        {
            return this.<UnitPrice>i__Field;
        }
    }
}

