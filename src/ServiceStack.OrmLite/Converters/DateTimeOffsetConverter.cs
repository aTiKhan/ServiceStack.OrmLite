﻿using System;
using System.Data;
using System.Globalization;

namespace ServiceStack.OrmLite.Converters
{
    public class DateTimeOffsetConverter : OrmLiteConverter
    {
        public override string ColumnDefinition
        {
            get { return "DATETIMEOFFSET"; }
        }

        public override DbType DbType
        {
            get { return DbType.DateTimeOffset; }
        }

        //From OrmLiteDialectProviderBase:
        public override object FromDbValue(FieldDefinition fieldDef, object value)
        {
            var strValue = value as string;
            if (strValue != null)
            {
                var moment = DateTimeOffset.Parse(strValue, null, DateTimeStyles.RoundtripKind);
                return moment;
            }
            if (value is DateTime)
            {
                return new DateTimeOffset((DateTime)value);
            }
            var convertedValue = DialectProvider.StringSerializer.DeserializeFromString(value.ToString(), fieldDef.FieldType);
            return convertedValue;
        }
    }
}