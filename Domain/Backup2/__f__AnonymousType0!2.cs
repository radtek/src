using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType0<<PriceTypeName>j__TPar, <UserCodes>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <PriceTypeName>j__TPar <PriceTypeName>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <UserCodes>j__TPar <UserCodes>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType0(<PriceTypeName>j__TPar PriceTypeName, <UserCodes>j__TPar UserCodes)
    {
        this.<PriceTypeName>i__Field = PriceTypeName;
        this.<UserCodes>i__Field = UserCodes;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType0<<PriceTypeName>j__TPar, <UserCodes>j__TPar>;
        return (((type != null) && EqualityComparer<<PriceTypeName>j__TPar>.Default.Equals(this.<PriceTypeName>i__Field, type.<PriceTypeName>i__Field)) && EqualityComparer<<UserCodes>j__TPar>.Default.Equals(this.<UserCodes>i__Field, type.<UserCodes>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = 0x4af6919a;
        num = (-1521134295 * num) + EqualityComparer<<PriceTypeName>j__TPar>.Default.GetHashCode(this.<PriceTypeName>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<UserCodes>j__TPar>.Default.GetHashCode(this.<UserCodes>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ PriceTypeName = ");
        builder.Append(this.<PriceTypeName>i__Field);
        builder.Append(", UserCodes = ");
        builder.Append(this.<UserCodes>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <PriceTypeName>j__TPar PriceTypeName
    {
        get
        {
            return this.<PriceTypeName>i__Field;
        }
    }

    public <UserCodes>j__TPar UserCodes
    {
        get
        {
            return this.<UserCodes>i__Field;
        }
    }
}

