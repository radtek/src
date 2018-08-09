using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType21<<AttributeId>j__TPar, <AttributeName>j__TPar, <InputUser>j__TPar, <InputDate>j__TPar, <ResourceTypeId>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <AttributeId>j__TPar <AttributeId>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <AttributeName>j__TPar <AttributeName>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <InputDate>j__TPar <InputDate>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <InputUser>j__TPar <InputUser>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ResourceTypeId>j__TPar <ResourceTypeId>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType21(<AttributeId>j__TPar AttributeId, <AttributeName>j__TPar AttributeName, <InputUser>j__TPar InputUser, <InputDate>j__TPar InputDate, <ResourceTypeId>j__TPar ResourceTypeId)
    {
        this.<AttributeId>i__Field = AttributeId;
        this.<AttributeName>i__Field = AttributeName;
        this.<InputUser>i__Field = InputUser;
        this.<InputDate>i__Field = InputDate;
        this.<ResourceTypeId>i__Field = ResourceTypeId;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType21<<AttributeId>j__TPar, <AttributeName>j__TPar, <InputUser>j__TPar, <InputDate>j__TPar, <ResourceTypeId>j__TPar>;
        return (((((type != null) && EqualityComparer<<AttributeId>j__TPar>.Default.Equals(this.<AttributeId>i__Field, type.<AttributeId>i__Field)) && (EqualityComparer<<AttributeName>j__TPar>.Default.Equals(this.<AttributeName>i__Field, type.<AttributeName>i__Field) && EqualityComparer<<InputUser>j__TPar>.Default.Equals(this.<InputUser>i__Field, type.<InputUser>i__Field))) && EqualityComparer<<InputDate>j__TPar>.Default.Equals(this.<InputDate>i__Field, type.<InputDate>i__Field)) && EqualityComparer<<ResourceTypeId>j__TPar>.Default.Equals(this.<ResourceTypeId>i__Field, type.<ResourceTypeId>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = 0x7a84620f;
        num = (-1521134295 * num) + EqualityComparer<<AttributeId>j__TPar>.Default.GetHashCode(this.<AttributeId>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<AttributeName>j__TPar>.Default.GetHashCode(this.<AttributeName>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<InputUser>j__TPar>.Default.GetHashCode(this.<InputUser>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<InputDate>j__TPar>.Default.GetHashCode(this.<InputDate>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<ResourceTypeId>j__TPar>.Default.GetHashCode(this.<ResourceTypeId>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ AttributeId = ");
        builder.Append(this.<AttributeId>i__Field);
        builder.Append(", AttributeName = ");
        builder.Append(this.<AttributeName>i__Field);
        builder.Append(", InputUser = ");
        builder.Append(this.<InputUser>i__Field);
        builder.Append(", InputDate = ");
        builder.Append(this.<InputDate>i__Field);
        builder.Append(", ResourceTypeId = ");
        builder.Append(this.<ResourceTypeId>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <AttributeId>j__TPar AttributeId
    {
        get
        {
            return this.<AttributeId>i__Field;
        }
    }

    public <AttributeName>j__TPar AttributeName
    {
        get
        {
            return this.<AttributeName>i__Field;
        }
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

    public <ResourceTypeId>j__TPar ResourceTypeId
    {
        get
        {
            return this.<ResourceTypeId>i__Field;
        }
    }
}

