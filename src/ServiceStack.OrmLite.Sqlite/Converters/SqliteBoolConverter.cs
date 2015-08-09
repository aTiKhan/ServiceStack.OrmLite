﻿using System;
using System.Data;

namespace ServiceStack.OrmLite.Sqlite.Converters
{
    public class SqliteBoolConverter : OrmLiteConverter
    {
        public override string ColumnDefinition
        {
            get { return "INTEGER"; }
        }

        public override string ToQuotedString(Type fieldType, object value)
        {
            var boolValue = (bool)value;
            return base.DialectProvider.GetQuotedValue(boolValue ? 1 : 0, typeof(int));
        }

        public override object ToDbValue(FieldDefinition fieldDef, object value)
        {
            return (bool)value ? 1 : 0;
        }

        public override object FromDbValue(FieldDefinition fieldDef, object value)
        {
            var intVal = int.Parse(value.ToString());
            return intVal != 0;
        }
    }
}