using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType11<<ConsTaskResId>j__TPar, <ResourceId>j__TPar, <Quantity>j__TPar, <UnitPrice>j__TPar, <AccountingQuantity>j__TPar, <ResourceTypeId>j__TPar, <CBSCode>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <AccountingQuantity>j__TPar <AccountingQuantity>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <CBSCode>j__TPar <CBSCode>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ConsTaskResId>j__TPar <ConsTaskResId>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <Quantity>j__TPar <Quantity>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ResourceId>j__TPar <ResourceId>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ResourceTypeId>j__TPar <ResourceTypeId>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <UnitPrice>j__TPar <UnitPrice>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType11(<ConsTaskResId>j__TPar ConsTaskResId, <ResourceId>j__TPar ResourceId, <Quantity>j__TPar Quantity, <UnitPrice>j__TPar UnitPrice, <AccountingQuantity>j__TPar AccountingQuantity, <ResourceTypeId>j__TPar ResourceTypeId, <CBSCode>j__TPar CBSCode)
    {
        this.<ConsTaskResId>i__Field = ConsTaskResId;
        this.<ResourceId>i__Field = ResourceId;
        this.<Quantity>i__Field = Quantity;
        this.<UnitPrice>i__Field = UnitPrice;
        this.<AccountingQuantity>i__Field = AccountingQuantity;
        this.<ResourceTypeId>i__Field = ResourceTypeId;
        this.<CBSCode>i__Field = CBSCode;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType11<<ConsTaskResId>j__TPar, <ResourceId>j__TPar, <Quantity>j__TPar, <UnitPrice>j__TPar, <AccountingQuantity>j__TPar, <ResourceTypeId>j__TPar, <CBSCode>j__TPar>;
        return (((((type != null) && EqualityComparer<<ConsTaskResId>j__TPar>.Default.Equals(this.<ConsTaskResId>i__Field, type.<ConsTaskResId>i__Field)) && (EqualityComparer<<ResourceId>j__TPar>.Default.Equals(this.<ResourceId>i__Field, type.<ResourceId>i__Field) && EqualityComparer<<Quantity>j__TPar>.Default.Equals(this.<Quantity>i__Field, type.<Quantity>i__Field))) && ((EqualityComparer<<UnitPrice>j__TPar>.Default.Equals(this.<UnitPrice>i__Field, type.<UnitPrice>i__Field) && EqualityComparer<<AccountingQuantity>j__TPar>.Default.Equals(this.<AccountingQuantity>i__Field, type.<AccountingQuantity>i__Field)) && EqualityComparer<<ResourceTypeId>j__TPar>.Default.Equals(this.<ResourceTypeId>i__Field, type.<ResourceTypeId>i__Field))) && EqualityComparer<<CBSCode>j__TPar>.Default.Equals(this.<CBSCode>i__Field, type.<CBSCode>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = 0x7a25b532;
        num = (-1521134295 * num) + EqualityComparer<<ConsTaskResId>j__TPar>.Default.GetHashCode(this.<ConsTaskResId>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<ResourceId>j__TPar>.Default.GetHashCode(this.<ResourceId>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<Quantity>j__TPar>.Default.GetHashCode(this.<Quantity>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<UnitPrice>j__TPar>.Default.GetHashCode(this.<UnitPrice>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<AccountingQuantity>j__TPar>.Default.GetHashCode(this.<AccountingQuantity>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<ResourceTypeId>j__TPar>.Default.GetHashCode(this.<ResourceTypeId>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<CBSCode>j__TPar>.Default.GetHashCode(this.<CBSCode>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ ConsTaskResId = ");
        builder.Append(this.<ConsTaskResId>i__Field);
        builder.Append(", ResourceId = ");
        builder.Append(this.<ResourceId>i__Field);
        builder.Append(", Quantity = ");
        builder.Append(this.<Quantity>i__Field);
        builder.Append(", UnitPrice = ");
        builder.Append(this.<UnitPrice>i__Field);
        builder.Append(", AccountingQuantity = ");
        builder.Append(this.<AccountingQuantity>i__Field);
        builder.Append(", ResourceTypeId = ");
        builder.Append(this.<ResourceTypeId>i__Field);
        builder.Append(", CBSCode = ");
        builder.Append(this.<CBSCode>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <AccountingQuantity>j__TPar AccountingQuantity
    {
        get
        {
            return this.<AccountingQuantity>i__Field;
        }
    }

    public <CBSCode>j__TPar CBSCode
    {
        get
        {
            return this.<CBSCode>i__Field;
        }
    }

    public <ConsTaskResId>j__TPar ConsTaskResId
    {
        get
        {
            return this.<ConsTaskResId>i__Field;
        }
    }

    public <Quantity>j__TPar Quantity
    {
        get
        {
            return this.<Quantity>i__Field;
        }
    }

    public <ResourceId>j__TPar ResourceId
    {
        get
        {
            return this.<ResourceId>i__Field;
        }
    }

    public <ResourceTypeId>j__TPar ResourceTypeId
    {
        get
        {
            return this.<ResourceTypeId>i__Field;
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

