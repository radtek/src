using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class <>f__AnonymousType20<<ItemId>j__TPar, <ExcelColumn>j__TPar, <ExcelRealCoumn>j__TPar, <DbColumn>j__TPar, <TemplateId>j__TPar>
{
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <DbColumn>j__TPar <DbColumn>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ExcelColumn>j__TPar <ExcelColumn>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ExcelRealCoumn>j__TPar <ExcelRealCoumn>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <ItemId>j__TPar <ItemId>i__Field;
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private readonly <TemplateId>j__TPar <TemplateId>i__Field;

    [DebuggerHidden]
    public <>f__AnonymousType20(<ItemId>j__TPar ItemId, <ExcelColumn>j__TPar ExcelColumn, <ExcelRealCoumn>j__TPar ExcelRealCoumn, <DbColumn>j__TPar DbColumn, <TemplateId>j__TPar TemplateId)
    {
        this.<ItemId>i__Field = ItemId;
        this.<ExcelColumn>i__Field = ExcelColumn;
        this.<ExcelRealCoumn>i__Field = ExcelRealCoumn;
        this.<DbColumn>i__Field = DbColumn;
        this.<TemplateId>i__Field = TemplateId;
    }

    [DebuggerHidden]
    public override bool Equals(object value)
    {
        var type = value as <>f__AnonymousType20<<ItemId>j__TPar, <ExcelColumn>j__TPar, <ExcelRealCoumn>j__TPar, <DbColumn>j__TPar, <TemplateId>j__TPar>;
        return (((((type != null) && EqualityComparer<<ItemId>j__TPar>.Default.Equals(this.<ItemId>i__Field, type.<ItemId>i__Field)) && (EqualityComparer<<ExcelColumn>j__TPar>.Default.Equals(this.<ExcelColumn>i__Field, type.<ExcelColumn>i__Field) && EqualityComparer<<ExcelRealCoumn>j__TPar>.Default.Equals(this.<ExcelRealCoumn>i__Field, type.<ExcelRealCoumn>i__Field))) && EqualityComparer<<DbColumn>j__TPar>.Default.Equals(this.<DbColumn>i__Field, type.<DbColumn>i__Field)) && EqualityComparer<<TemplateId>j__TPar>.Default.Equals(this.<TemplateId>i__Field, type.<TemplateId>i__Field));
    }

    [DebuggerHidden]
    public override int GetHashCode()
    {
        int num = -1592064696;
        num = (-1521134295 * num) + EqualityComparer<<ItemId>j__TPar>.Default.GetHashCode(this.<ItemId>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<ExcelColumn>j__TPar>.Default.GetHashCode(this.<ExcelColumn>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<ExcelRealCoumn>j__TPar>.Default.GetHashCode(this.<ExcelRealCoumn>i__Field);
        num = (-1521134295 * num) + EqualityComparer<<DbColumn>j__TPar>.Default.GetHashCode(this.<DbColumn>i__Field);
        return ((-1521134295 * num) + EqualityComparer<<TemplateId>j__TPar>.Default.GetHashCode(this.<TemplateId>i__Field));
    }

    [DebuggerHidden]
    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("{ ItemId = ");
        builder.Append(this.<ItemId>i__Field);
        builder.Append(", ExcelColumn = ");
        builder.Append(this.<ExcelColumn>i__Field);
        builder.Append(", ExcelRealCoumn = ");
        builder.Append(this.<ExcelRealCoumn>i__Field);
        builder.Append(", DbColumn = ");
        builder.Append(this.<DbColumn>i__Field);
        builder.Append(", TemplateId = ");
        builder.Append(this.<TemplateId>i__Field);
        builder.Append(" }");
        return builder.ToString();
    }

    public <DbColumn>j__TPar DbColumn
    {
        get
        {
            return this.<DbColumn>i__Field;
        }
    }

    public <ExcelColumn>j__TPar ExcelColumn
    {
        get
        {
            return this.<ExcelColumn>i__Field;
        }
    }

    public <ExcelRealCoumn>j__TPar ExcelRealCoumn
    {
        get
        {
            return this.<ExcelRealCoumn>i__Field;
        }
    }

    public <ItemId>j__TPar ItemId
    {
        get
        {
            return this.<ItemId>i__Field;
        }
    }

    public <TemplateId>j__TPar TemplateId
    {
        get
        {
            return this.<TemplateId>i__Field;
        }
    }
}

