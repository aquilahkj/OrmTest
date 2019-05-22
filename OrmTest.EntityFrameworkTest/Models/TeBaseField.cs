using System;
using System.Collections.Generic;

namespace OrmTest.EntityFrameworkTest.Models
{
    public partial class TeBaseField
    {
        public int Id { get; set; }
        public bool BoolField { get; set; }
        public bool? BoolFieldNull { get; set; }
        public short SbyteField { get; set; }
        public short? SbyteFieldNull { get; set; }
        public byte ByteField { get; set; }
        public byte? ByteFieldNull { get; set; }
        public short Int16Field { get; set; }
        public short? Int16FieldNull { get; set; }
        public int Uint16Field { get; set; }
        public int? Uint16FieldNull { get; set; }
        public int Int32Field { get; set; }
        public int? Int32FieldNull { get; set; }
        public long Uint32Field { get; set; }
        public long? Uint32FieldNull { get; set; }
        public long Int64Field { get; set; }
        public long? Int64FieldNull { get; set; }
        public decimal Uint64Field { get; set; }
        public decimal? Uint64FieldNull { get; set; }
        public float FloatField { get; set; }
        public float? FloatFieldNull { get; set; }
        public double DoubleField { get; set; }
        public double? DoubleFieldNull { get; set; }
        public decimal DecimalField { get; set; }
        public decimal? DecimalFieldNull { get; set; }
        public DateTime DateTimeField { get; set; }
        public DateTime? DateTimeFieldNull { get; set; }
        public string VarcharField { get; set; }
        public string VarcharFieldNull { get; set; }
        public string TextField { get; set; }
        public string TextFieldNull { get; set; }
        public byte[] BigDataField { get; set; }
        public byte[] BigDataFieldNull { get; set; }
        public int EnumInt32Field { get; set; }
        public int? EnumInt32FieldNull { get; set; }
        public long EnumInt64Field { get; set; }
        public long? EnumInt64FieldNull { get; set; }
    }
}
