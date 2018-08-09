using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType1b<<id>j__TPar, <resId>j__TPar, <taskId>j__TPar, <resCode>j__TPar, <resName>j__TPar, <unitPrice>j__TPar, <quantity>j__TPar, <amount>j__TPar, <prjId>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <amount>j__TPar <amount>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <id>j__TPar <id>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <prjId>j__TPar <prjId>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <quantity>j__TPar <quantity>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <resCode>j__TPar <resCode>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <resId>j__TPar <resId>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <resName>j__TPar <resName>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <taskId>j__TPar <taskId>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <unitPrice>j__TPar <unitPrice>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType1b(<id>j__TPar id, <resId>j__TPar resId, <taskId>j__TPar taskId, <resCode>j__TPar resCode, <resName>j__TPar resName, <unitPrice>j__TPar unitPrice, <quantity>j__TPar quantity, <amount>j__TPar amount, <prjId>j__TPar prjId)
    {
        this.<id>i__Field = id;
        this.<resId>i__Field = resId;
        this.<taskId>i__Field = taskId;
        this.<resCode>i__Field = resCode;
        this.<resName>i__Field = resName;
        this.<unitPrice>i__Field = unitPrice;
        this.<quantity>i__Field = quantity;
        this.<amount>i__Field = amount;
        this.<prjId>i__Field = prjId;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var typeb = value as <>f__AnonymousType1b<<id>j__TPar, <resId>j__TPar, <taskId>j__TPar, <resCode>j__TPar, <resName>j__TPar, <unitPrice>j__TPar, <quantity>j__TPar, <amount>j__TPar, <prjId>j__TPar>;
        return ((((((typeb != null) && EqualityComparer<<id>j__TPar>.Default.Equals(this.<id>i__Field, typeb.<id>i__Field)) && (EqualityComparer<<resId>j__TPar>.Default.Equals(this.<resId>i__Field, typeb.<resId>i__Field) && EqualityComparer<<taskId>j__TPar>.Default.Equals(this.<taskId>i__Field, typeb.<taskId>i__Field))) && ((EqualityComparer<<resCode>j__TPar>.Default.Equals(this.<resCode>i__Field, typeb.<resCode>i__Field) && EqualityComparer<<resName>j__TPar>.Default.Equals(this.<resName>i__Field, typeb.<resName>i__Field)) && (EqualityComparer<<unitPrice>j__TPar>.Default.Equals(this.<unitPrice>i__Field, typeb.<unitPrice>i__Field) && EqualityComparer<<quantity>j__TPar>.Default.Equals(this.<quantity>i__Field, typeb.<quantity>i__Field)))) && EqualityComparer<<amount>j__TPar>.Default.Equals(this.<amount>i__Field, typeb.<amount>i__Field)) && EqualityComparer<<prjId>j__TPar>.Default.Equals(this.<prjId>i__Field, typeb.<prjId>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = -576548175;
        num = (-1521134295 * num) + EqualityComparer<<id>j__TPar>.Default.GetHashCode(this.<id>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<resId>j__TPar>.Default.GetHashCode(this.<resId>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<taskId>j__TPar>.Default.GetHashCode(this.<taskId>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<resCode>j__TPar>.Default.GetHashCode(this.<resCode>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<resName>j__TPar>.Default.GetHashCode(this.<resName>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<unitPrice>j__TPar>.Default.GetHashCode(this.<unitPrice>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<quantity>j__TPar>.Default.GetHashCode(this.<quantity>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<amount>j__TPar>.Default.GetHashCode(this.<amount>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<prjId>j__TPar>.Default.GetHashCode(this.<prjId>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ id = ");
        builder.Append(this.<id>i__Field);
        builder.Append(", resId = ");
        builder.Append(this.<resId>i__Field);
        builder.Append(", taskId = ");
        builder.Append(this.<taskId>i__Field);
        builder.Append(", resCode = ");
        builder.Append(this.<resCode>i__Field);
        builder.Append(", resName = ");
        builder.Append(this.<resName>i__Field);
        builder.Append(", unitPrice = ");
        builder.Append(this.<unitPrice>i__Field);
        builder.Append(", quantity = ");
        builder.Append(this.<quantity>i__Field);
        builder.Append(", amount = ");
        builder.Append(this.<amount>i__Field);
        builder.Append(", prjId = ");
        builder.Append(this.<prjId>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <amount>j__TPar amount
    {
        get
        {
            return this.<amount>i__Field;
        }
    }

    public <id>j__TPar id
    {
        get
        {
            return this.<id>i__Field;
        }
    }

    public <prjId>j__TPar prjId
    {
        get
        {
            return this.<prjId>i__Field;
        }
    }

    public <quantity>j__TPar quantity
    {
        get
        {
            return this.<quantity>i__Field;
        }
    }

    public <resCode>j__TPar resCode
    {
        get
        {
            return this.<resCode>i__Field;
        }
    }

    public <resId>j__TPar resId
    {
        get
        {
            return this.<resId>i__Field;
        }
    }

    public <resName>j__TPar resName
    {
        get
        {
            return this.<resName>i__Field;
        }
    }

    public <taskId>j__TPar taskId
    {
        get
        {
            return this.<taskId>i__Field;
        }
    }

    public <unitPrice>j__TPar unitPrice
    {
        get
        {
            return this.<unitPrice>i__Field;
        }
    }
}

