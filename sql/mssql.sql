CREATE TABLE [dbo].[Te_BaseField] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [BoolField] bit  NOT NULL,
  [BoolFieldNull] bit  NULL,
  [SbyteField] smallint  NOT NULL,
  [SbyteFieldNull] smallint  NULL,
  [ByteField] tinyint  NOT NULL,
  [ByteFieldNull] tinyint  NULL,
  [Int16Field] smallint  NOT NULL,
  [Int16FieldNull] smallint  NULL,
  [UInt16Field] int  NOT NULL,
  [UInt16FieldNull] int  NULL,
  [Int32Field] int  NOT NULL,
  [Int32FieldNull] int  NULL,
  [UInt32Field] bigint  NOT NULL,
  [UInt32FieldNull] bigint  NULL,
  [Int64Field] bigint  NOT NULL,
  [Int64FieldNull] bigint  NULL,
  [UInt64Field] decimal(20)  NOT NULL,
  [UInt64FieldNull] decimal(20)  NULL,
  [FloatField] real  NOT NULL,
  [FloatFieldNull] real  NULL,
  [DoubleField] float(53)  NOT NULL,
  [DoubleFieldNull] float(53)  NULL,
  [DecimalField] decimal(10,4)  NOT NULL,
  [DecimalFieldNull] decimal(10,4)  NULL,
  [DateTimeField] datetime  NOT NULL,
  [DateTimeFieldNull] datetime  NULL,
  [VarcharField] varchar(2000) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [VarcharFieldNull] varchar(2000) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [TextField] text COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [TextFieldNull] text COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [BigDataField] varbinary(max)  NOT NULL,
  [BigDataFieldNull] varbinary(max)  NULL,
  [EnumInt32Field] int  NOT NULL,
  [EnumInt32FieldNull] int  NULL,
  [EnumInt64Field] bigint  NOT NULL,
  [EnumInt64FieldNull] bigint  NULL,
  CONSTRAINT [PK__Te_BaseF__3214EC0712F4870F] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
)  