using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType28<<ID>j__TPar, <PrjGuid>j__TPar, <EngineeringType>j__TPar, <TypeName>j__TPar, <EngineeringSubType>j__TPar, <ItemName>j__TPar, <Grade>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <EngineeringSubType>j__TPar <EngineeringSubType>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <EngineeringType>j__TPar <EngineeringType>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <Grade>j__TPar <Grade>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ID>j__TPar <ID>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ItemName>j__TPar <ItemName>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <PrjGuid>j__TPar <PrjGuid>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <TypeName>j__TPar <TypeName>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType28(<ID>j__TPar ID, <PrjGuid>j__TPar PrjGuid, <EngineeringType>j__TPar EngineeringType, <TypeName>j__TPar TypeName, <EngineeringSubType>j__TPar EngineeringSubType, <ItemName>j__TPar ItemName, <Grade>j__TPar Grade)
    {
        this.<ID>i__Field = ID;
        this.<PrjGuid>i__Field = PrjGuid;
        this.<EngineeringType>i__Field = EngineeringType;
        this.<TypeName>i__Field = TypeName;
        this.<EngineeringSubType>i__Field = EngineeringSubType;
        this.<ItemName>i__Field = ItemName;
        this.<Grade>i__Field = Grade;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType28<<ID>j__TPar, <PrjGuid>j__TPar, <EngineeringType>j__TPar, <TypeName>j__TPar, <EngineeringSubType>j__TPar, <ItemName>j__TPar, <Grade>j__TPar>;
        return (((((type != null) && EqualityComparer<<ID>j__TPar>.Default.Equals(this.<ID>i__Field, type.<ID>i__Field)) && (EqualityComparer<<PrjGuid>j__TPar>.Default.Equals(this.<PrjGuid>i__Field, type.<PrjGuid>i__Field) && EqualityComparer<<EngineeringType>j__TPar>.Default.Equals(this.<EngineeringType>i__Field, type.<EngineeringType>i__Field))) && ((EqualityComparer<<TypeName>j__TPar>.Default.Equals(this.<TypeName>i__Field, type.<TypeName>i__Field) && EqualityComparer<<EngineeringSubType>j__TPar>.Default.Equals(this.<EngineeringSubType>i__Field, type.<EngineeringSubType>i__Field)) && EqualityComparer<<ItemName>j__TPar>.Default.Equals(this.<ItemName>i__Field, type.<ItemName>i__Field))) && EqualityComparer<<Grade>j__TPar>.Default.Equals(this.<Grade>i__Field, type.<Grade>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = 0x3da37ca3;
        num = (-1521134295 * num) + EqualityComparer<<ID>j__TPar>.Default.GetHashCode(this.<ID>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<PrjGuid>j__TPar>.Default.GetHashCode(this.<PrjGuid>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<EngineeringType>j__TPar>.Default.GetHashCode(this.<EngineeringType>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<TypeName>j__TPar>.Default.GetHashCode(this.<TypeName>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<EngineeringSubType>j__TPar>.Default.GetHashCode(this.<EngineeringSubType>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<ItemName>j__TPar>.Default.GetHashCode(this.<ItemName>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<Grade>j__TPar>.Default.GetHashCode(this.<Grade>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ ID = ");
        builder.Append(this.<ID>i__Field);
        builder.Append(", PrjGuid = ");
        builder.Append(this.<PrjGuid>i__Field);
        builder.Append(", EngineeringType = ");
        builder.Append(this.<EngineeringType>i__Field);
        builder.Append(", TypeName = ");
        builder.Append(this.<TypeName>i__Field);
        builder.Append(", EngineeringSubType = ");
        builder.Append(this.<EngineeringSubType>i__Field);
        builder.Append(", ItemName = ");
        builder.Append(this.<ItemName>i__Field);
        builder.Append(", Grade = ");
        builder.Append(this.<Grade>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <EngineeringSubType>j__TPar EngineeringSubType
    {
        get
        {
            return this.<EngineeringSubType>i__Field;
        }
    }

    public <EngineeringType>j__TPar EngineeringType
    {
        get
        {
            return this.<EngineeringType>i__Field;
        }
    }

    public <Grade>j__TPar Grade
    {
        get
        {
            return this.<Grade>i__Field;
        }
    }

    public <ID>j__TPar ID
    {
        get
        {
            return this.<ID>i__Field;
        }
    }

    public <ItemName>j__TPar ItemName
    {
        get
        {
            return this.<ItemName>i__Field;
        }
    }

    public <PrjGuid>j__TPar PrjGuid
    {
        get
        {
            return this.<PrjGuid>i__Field;
        }
    }

    public <TypeName>j__TPar TypeName
    {
        get
        {
            return this.<TypeName>i__Field;
        }
    }
}

