namespace FishHoghoghi.FishDataSetTableAdapters
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [Serializable, DesignerCategory("code"), ToolboxItem(true), XmlSchemaProvider("GetTypedDataSetSchema"), XmlRoot("FishDataSet"), HelpKeyword("vs.data.DataSet")]
    public class FishDataSet : DataSet
    {
        private MKView_FishHamkaranDataTable tableMKView_FishHamkaran;
        private LoginLogDataTable tableLoginLog;
        private basic_informationDataTable tablebasic_information;
        private MKView_ContractHamkaranDataTable tableMKView_ContractHamkaran;
        private SchemaSerializationMode _schemaSerializationMode;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public FishDataSet()
        {
            _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            BeginInit();
            InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            EndInit();
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        protected FishDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
        {
            _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            if (IsBinarySerialized(info, context))
            {
                InitVars(false);
                CollectionChangeEventHandler handler2 = new CollectionChangeEventHandler(SchemaChanged);
                Tables.CollectionChanged += handler2;
                Relations.CollectionChanged += handler2;
            }
            else
            {
                string s = (string)info.GetValue("XmlSchema", typeof(string));
                if (DetermineSchemaSerializationMode(info, context) == SchemaSerializationMode.IncludeSchema)
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                    if (dataSet.Tables["MKView_FishHamkaran"] != null)
                    {
                        base.Tables.Add(new MKView_FishHamkaranDataTable(dataSet.Tables["MKView_FishHamkaran"]));
                    }
                    if (dataSet.Tables["LoginLog"] != null)
                    {
                        base.Tables.Add(new LoginLogDataTable(dataSet.Tables["LoginLog"]));
                    }
                    if (dataSet.Tables["basic_information"] != null)
                    {
                        base.Tables.Add(new basic_informationDataTable(dataSet.Tables["basic_information"]));
                    }
                    if (dataSet.Tables["MKView_ContractHamkaran"] != null)
                    {
                        base.Tables.Add(new MKView_ContractHamkaranDataTable(dataSet.Tables["MKView_ContractHamkaran"]));
                    }
                    DataSetName = dataSet.DataSetName;
                    Prefix = dataSet.Prefix;
                    Namespace = dataSet.Namespace;
                    Locale = dataSet.Locale;
                    CaseSensitive = dataSet.CaseSensitive;
                    EnforceConstraints = dataSet.EnforceConstraints;
                    Merge(dataSet, false, MissingSchemaAction.Add);
                    InitVars();
                }
                else
                {
                    ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                }
                GetSerializationData(info, context);
                CollectionChangeEventHandler handler = new CollectionChangeEventHandler(SchemaChanged);
                base.Tables.CollectionChanged += handler;
                Relations.CollectionChanged += handler;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public override DataSet Clone()
        {
            FishDataSet set = (FishDataSet)base.Clone();
            set.InitVars();
            set.SchemaSerializationMode = SchemaSerializationMode;
            return set;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream w = new MemoryStream();
            WriteXmlSchema(new XmlTextWriter(w, null));
            w.Position = 0L;
            return XmlSchema.Read(new XmlTextReader(w), null);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
        {
            FishDataSet set = new FishDataSet();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny
            {
                Namespace = set.Namespace
            };
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = set.GetSchemaSerializable();
            if (xs.Contains(schemaSerializable.TargetNamespace))
            {
                MemoryStream stream = new MemoryStream();
                MemoryStream stream2 = new MemoryStream();
                try
                {
                    XmlSchema current = null;
                    schemaSerializable.Write(stream);
                    IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (XmlSchema)enumerator.Current;
                        stream2.SetLength(0L);
                        current.Write(stream2);
                        if (stream.Length == stream2.Length)
                        {
                            stream.Position = 0L;
                            stream2.Position = 0L;
                            while (stream.Position != stream.Length && stream.ReadByte() == stream2.ReadByte())
                            {
                            }
                            if (stream.Position == stream.Length)
                            {
                                return type;
                            }
                        }
                    }
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    if (stream2 != null)
                    {
                        stream2.Close();
                    }
                }
            }
            xs.Add(schemaSerializable);
            return type;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private void InitClass()
        {
            DataSetName = "FishDataSet";
            Prefix = "";
            Namespace = "http://tempuri.org/DataSet1.xsd";
            EnforceConstraints = true;
            SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            tableMKView_FishHamkaran = new MKView_FishHamkaranDataTable();
            base.Tables.Add(tableMKView_FishHamkaran);
            tableLoginLog = new LoginLogDataTable();
            base.Tables.Add(tableLoginLog);
            tablebasic_information = new basic_informationDataTable();
            base.Tables.Add(tablebasic_information);
            tableMKView_ContractHamkaran = new MKView_ContractHamkaranDataTable();
            base.Tables.Add(tableMKView_ContractHamkaran);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        protected override void InitializeDerivedDataSet()
        {
            BeginInit();
            InitClass();
            EndInit();
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        internal void InitVars()
        {
            InitVars(true);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        internal void InitVars(bool initTable)
        {
            tableMKView_FishHamkaran = (MKView_FishHamkaranDataTable)base.Tables["MKView_FishHamkaran"];
            if (initTable && tableMKView_FishHamkaran != null)
            {
                tableMKView_FishHamkaran.InitVars();
            }
            tableLoginLog = (LoginLogDataTable)base.Tables["LoginLog"];
            if (initTable && tableLoginLog != null)
            {
                tableLoginLog.InitVars();
            }
            tablebasic_information = (basic_informationDataTable)base.Tables["basic_information"];
            if (initTable && tablebasic_information != null)
            {
                tablebasic_information.InitVars();
            }
            tableMKView_ContractHamkaran = (MKView_ContractHamkaranDataTable)base.Tables["MKView_ContractHamkaran"];
            if (initTable && tableMKView_ContractHamkaran != null)
            {
                tableMKView_ContractHamkaran.InitVars();
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
            {
                Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["MKView_FishHamkaran"] != null)
                {
                    base.Tables.Add(new MKView_FishHamkaranDataTable(dataSet.Tables["MKView_FishHamkaran"]));
                }
                if (dataSet.Tables["LoginLog"] != null)
                {
                    base.Tables.Add(new LoginLogDataTable(dataSet.Tables["LoginLog"]));
                }
                if (dataSet.Tables["basic_information"] != null)
                {
                    base.Tables.Add(new basic_informationDataTable(dataSet.Tables["basic_information"]));
                }
                if (dataSet.Tables["MKView_ContractHamkaran"] != null)
                {
                    base.Tables.Add(new MKView_ContractHamkaranDataTable(dataSet.Tables["MKView_ContractHamkaran"]));
                }
                DataSetName = dataSet.DataSetName;
                Prefix = dataSet.Prefix;
                Namespace = dataSet.Namespace;
                Locale = dataSet.Locale;
                CaseSensitive = dataSet.CaseSensitive;
                EnforceConstraints = dataSet.EnforceConstraints;
                Merge(dataSet, false, MissingSchemaAction.Add);
                InitVars();
            }
            else
            {
                ReadXml(reader);
                InitVars();
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                InitVars();
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private bool ShouldSerializebasic_information() =>
            false;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private bool ShouldSerializeLoginLog() =>
            false;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private bool ShouldSerializeMKView_ContractHamkaran() =>
            false;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private bool ShouldSerializeMKView_FishHamkaran() =>
            false;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        protected override bool ShouldSerializeRelations() =>
            false;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        protected override bool ShouldSerializeTables() =>
            false;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MKView_FishHamkaranDataTable MKView_FishHamkaran =>
            tableMKView_FishHamkaran;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public LoginLogDataTable LoginLog =>
            tableLoginLog;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public basic_informationDataTable basic_information =>
            tablebasic_information;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MKView_ContractHamkaranDataTable MKView_ContractHamkaran =>
            tableMKView_ContractHamkaran;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override SchemaSerializationMode SchemaSerializationMode
        {
            get =>
                _schemaSerializationMode;
            set =>
                _schemaSerializationMode = value;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataTableCollection Tables =>
            base.Tables;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataRelationCollection Relations =>
            base.Relations;

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class basic_informationDataTable : TypedTableBase<basic_informationRow>
        {
            private DataColumn columnid;
            private DataColumn columncompany_name;
            private DataColumn columnceo_name;
            private DataColumn columnregister_number;
            private DataColumn columnsupport_phone_number;
            private DataColumn columnhome_subsidy;
            private DataColumn columnmariage_base;
            private DataColumn columnbon;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event basic_informationRowChangeEventHandler basic_informationRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event basic_informationRowChangeEventHandler basic_informationRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event basic_informationRowChangeEventHandler basic_informationRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event basic_informationRowChangeEventHandler basic_informationRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public basic_informationDataTable()
            {
                TableName = "basic_information";
                BeginInit();
                InitClass();
                EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            internal basic_informationDataTable(DataTable table)
            {
                TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    Namespace = table.Namespace;
                }
                Prefix = table.Prefix;
                MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected basic_informationDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Addbasic_informationRow(basic_informationRow row)
            {
                Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public basic_informationRow Addbasic_informationRow(string company_name, string ceo_name, string register_number, string support_phone_number, int home_subsidy, int mariage_base, int bon)
            {
                basic_informationRow row = (basic_informationRow)NewRow();
                object[] objArray1 = new object[8];
                objArray1[1] = company_name;
                objArray1[2] = ceo_name;
                objArray1[3] = register_number;
                objArray1[4] = support_phone_number;
                objArray1[5] = home_subsidy;
                objArray1[6] = mariage_base;
                objArray1[7] = bon;
                object[] objArray = objArray1;
                row.ItemArray = objArray;
                Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public override DataTable Clone()
            {
                basic_informationDataTable table = (basic_informationDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override DataTable CreateInstance() =>
                new basic_informationDataTable();

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public basic_informationRow FindByid(int id)
            {
                object[] keys = new object[] { id };
                return (basic_informationRow)Rows.Find(keys);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override Type GetRowType() =>
                typeof(basic_informationRow);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                FishDataSet set = new FishDataSet();
                XmlSchemaAny item = new XmlSchemaAny
                {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny
                {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute
                {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "basic_informationDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = set.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema)enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while (stream.Position != stream.Length && stream.ReadByte() == stream2.ReadByte())
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            private void InitClass()
            {
                columnid = new DataColumn("id", typeof(int), null, MappingType.Element);
                Columns.Add(columnid);
                columncompany_name = new DataColumn("company_name", typeof(string), null, MappingType.Element);
                Columns.Add(columncompany_name);
                columnceo_name = new DataColumn("ceo_name", typeof(string), null, MappingType.Element);
                Columns.Add(columnceo_name);
                columnregister_number = new DataColumn("register_number", typeof(string), null, MappingType.Element);
                Columns.Add(columnregister_number);
                columnsupport_phone_number = new DataColumn("support_phone_number", typeof(string), null, MappingType.Element);
                Columns.Add(columnsupport_phone_number);
                columnhome_subsidy = new DataColumn("home_subsidy", typeof(int), null, MappingType.Element);
                Columns.Add(columnhome_subsidy);
                columnmariage_base = new DataColumn("mariage_base", typeof(int), null, MappingType.Element);
                Columns.Add(columnmariage_base);
                columnbon = new DataColumn("bon", typeof(int), null, MappingType.Element);
                Columns.Add(columnbon);
                DataColumn[] columns = new DataColumn[] { columnid };
                Constraints.Add(new UniqueConstraint("Constraint1", columns, true));
                columnid.AutoIncrement = true;
                columnid.AutoIncrementSeed = -1L;
                columnid.AutoIncrementStep = -1L;
                columnid.AllowDBNull = false;
                columnid.ReadOnly = true;
                columnid.Unique = true;
                columncompany_name.MaxLength = 0xff;
                columnceo_name.MaxLength = 0xff;
                columnregister_number.MaxLength = 0xff;
                columnsupport_phone_number.MaxLength = 0xff;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            internal void InitVars()
            {
                columnid = Columns["id"];
                columncompany_name = Columns["company_name"];
                columnceo_name = Columns["ceo_name"];
                columnregister_number = Columns["register_number"];
                columnsupport_phone_number = Columns["support_phone_number"];
                columnhome_subsidy = Columns["home_subsidy"];
                columnmariage_base = Columns["mariage_base"];
                columnbon = Columns["bon"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public basic_informationRow Newbasic_informationRow() =>
                (basic_informationRow)NewRow();

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) =>
                new basic_informationRow(builder);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (basic_informationRowChanged != null)
                {
                    basic_informationRowChanged(this, new basic_informationRowChangeEvent((basic_informationRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (basic_informationRowChanging != null)
                {
                    basic_informationRowChanging(this, new basic_informationRowChangeEvent((basic_informationRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (basic_informationRowDeleted != null)
                {
                    basic_informationRowDeleted(this, new basic_informationRowChangeEvent((basic_informationRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (basic_informationRowDeleting != null)
                {
                    basic_informationRowDeleting(this, new basic_informationRowChangeEvent((basic_informationRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Removebasic_informationRow(basic_informationRow row)
            {
                Rows.Remove(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn idColumn =>
                columnid;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn company_nameColumn =>
                columncompany_name;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn ceo_nameColumn =>
                columnceo_name;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn register_numberColumn =>
                columnregister_number;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn support_phone_numberColumn =>
                columnsupport_phone_number;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn home_subsidyColumn =>
                columnhome_subsidy;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn mariage_baseColumn =>
                columnmariage_base;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn bonColumn =>
                columnbon;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), Browsable(false)]
            public int Count =>
                Rows.Count;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public basic_informationRow this[int index] =>
                (basic_informationRow)Rows[index];
        }

        public class basic_informationRow : DataRow
        {
            private basic_informationDataTable tablebasic_information;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            internal basic_informationRow(DataRowBuilder rb) : base(rb)
            {
                tablebasic_information = (basic_informationDataTable)Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool IsbonNull() =>
                IsNull(tablebasic_information.bonColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isceo_nameNull() =>
                IsNull(tablebasic_information.ceo_nameColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Iscompany_nameNull() =>
                IsNull(tablebasic_information.company_nameColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Ishome_subsidyNull() =>
                IsNull(tablebasic_information.home_subsidyColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Ismariage_baseNull() =>
                IsNull(tablebasic_information.mariage_baseColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isregister_numberNull() =>
                IsNull(tablebasic_information.register_numberColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Issupport_phone_numberNull() =>
                IsNull(tablebasic_information.support_phone_numberColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void SetbonNull()
            {
                base[tablebasic_information.bonColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setceo_nameNull()
            {
                base[tablebasic_information.ceo_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setcompany_nameNull()
            {
                base[tablebasic_information.company_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Sethome_subsidyNull()
            {
                base[tablebasic_information.home_subsidyColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setmariage_baseNull()
            {
                base[tablebasic_information.mariage_baseColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setregister_numberNull()
            {
                base[tablebasic_information.register_numberColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setsupport_phone_numberNull()
            {
                base[tablebasic_information.support_phone_numberColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public int id
            {
                get =>
                    (int)base[tablebasic_information.idColumn];
                set =>
                    base[tablebasic_information.idColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string company_name
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tablebasic_information.company_nameColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'company_name' in table 'basic_information' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tablebasic_information.company_nameColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string ceo_name
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tablebasic_information.ceo_nameColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ceo_name' in table 'basic_information' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tablebasic_information.ceo_nameColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string register_number
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tablebasic_information.register_numberColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'register_number' in table 'basic_information' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tablebasic_information.register_numberColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string support_phone_number
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tablebasic_information.support_phone_numberColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'support_phone_number' in table 'basic_information' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tablebasic_information.support_phone_numberColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public int home_subsidy
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int)base[tablebasic_information.home_subsidyColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'home_subsidy' in table 'basic_information' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tablebasic_information.home_subsidyColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public int mariage_base
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int)base[tablebasic_information.mariage_baseColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'mariage_base' in table 'basic_information' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tablebasic_information.mariage_baseColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public int bon
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int)base[tablebasic_information.bonColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'bon' in table 'basic_information' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tablebasic_information.bonColumn] = value;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public class basic_informationRowChangeEvent : EventArgs
        {
            private basic_informationRow eventRow;
            private DataRowAction eventAction;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public basic_informationRowChangeEvent(basic_informationRow row, DataRowAction action)
            {
                eventRow = row;
                eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public basic_informationRow Row =>
                eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataRowAction Action =>
                eventAction;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public delegate void basic_informationRowChangeEventHandler(object sender, basic_informationRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class LoginLogDataTable : TypedTableBase<LoginLogRow>
        {
            private DataColumn columnid;
            private DataColumn columnusername;
            private DataColumn columnlogin_at;
            private DataColumn columnmac_address;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event LoginLogRowChangeEventHandler LoginLogRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event LoginLogRowChangeEventHandler LoginLogRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event LoginLogRowChangeEventHandler LoginLogRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event LoginLogRowChangeEventHandler LoginLogRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public LoginLogDataTable()
            {
                TableName = "LoginLog";
                BeginInit();
                InitClass();
                EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            internal LoginLogDataTable(DataTable table)
            {
                TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    Namespace = table.Namespace;
                }
                Prefix = table.Prefix;
                MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected LoginLogDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void AddLoginLogRow(LoginLogRow row)
            {
                Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public LoginLogRow AddLoginLogRow(string username, string login_at, string mac_address)
            {
                LoginLogRow row = (LoginLogRow)NewRow();
                object[] objArray1 = new object[4];
                objArray1[1] = username;
                objArray1[2] = login_at;
                objArray1[3] = mac_address;
                object[] objArray = objArray1;
                row.ItemArray = objArray;
                Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public override DataTable Clone()
            {
                LoginLogDataTable table = (LoginLogDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override DataTable CreateInstance() =>
                new LoginLogDataTable();

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public LoginLogRow FindByid(int id)
            {
                object[] keys = new object[] { id };
                return (LoginLogRow)Rows.Find(keys);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override Type GetRowType() =>
                typeof(LoginLogRow);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                FishDataSet set = new FishDataSet();
                XmlSchemaAny item = new XmlSchemaAny
                {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny
                {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute
                {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "LoginLogDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = set.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema)enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while (stream.Position != stream.Length && stream.ReadByte() == stream2.ReadByte())
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            private void InitClass()
            {
                columnid = new DataColumn("id", typeof(int), null, MappingType.Element);
                Columns.Add(columnid);
                columnusername = new DataColumn("username", typeof(string), null, MappingType.Element);
                Columns.Add(columnusername);
                columnlogin_at = new DataColumn("login_at", typeof(string), null, MappingType.Element);
                Columns.Add(columnlogin_at);
                columnmac_address = new DataColumn("mac_address", typeof(string), null, MappingType.Element);
                Columns.Add(columnmac_address);
                DataColumn[] columns = new DataColumn[] { columnid };
                Constraints.Add(new UniqueConstraint("Constraint1", columns, true));
                columnid.AutoIncrement = true;
                columnid.AutoIncrementSeed = -1L;
                columnid.AutoIncrementStep = -1L;
                columnid.AllowDBNull = false;
                columnid.ReadOnly = true;
                columnid.Unique = true;
                columnusername.MaxLength = 20;
                columnlogin_at.MaxLength = 20;
                columnmac_address.MaxLength = 50;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            internal void InitVars()
            {
                columnid = Columns["id"];
                columnusername = Columns["username"];
                columnlogin_at = Columns["login_at"];
                columnmac_address = Columns["mac_address"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public LoginLogRow NewLoginLogRow() =>
                (LoginLogRow)NewRow();

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) =>
                new LoginLogRow(builder);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (LoginLogRowChanged != null)
                {
                    LoginLogRowChanged(this, new LoginLogRowChangeEvent((LoginLogRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (LoginLogRowChanging != null)
                {
                    LoginLogRowChanging(this, new LoginLogRowChangeEvent((LoginLogRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (LoginLogRowDeleted != null)
                {
                    LoginLogRowDeleted(this, new LoginLogRowChangeEvent((LoginLogRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (LoginLogRowDeleting != null)
                {
                    LoginLogRowDeleting(this, new LoginLogRowChangeEvent((LoginLogRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void RemoveLoginLogRow(LoginLogRow row)
            {
                Rows.Remove(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn idColumn =>
                columnid;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn usernameColumn =>
                columnusername;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn login_atColumn =>
                columnlogin_at;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn mac_addressColumn =>
                columnmac_address;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), Browsable(false)]
            public int Count =>
                Rows.Count;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public LoginLogRow this[int index] =>
                (LoginLogRow)Rows[index];
        }

        public class LoginLogRow : DataRow
        {
            private LoginLogDataTable tableLoginLog;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            internal LoginLogRow(DataRowBuilder rb) : base(rb)
            {
                tableLoginLog = (LoginLogDataTable)Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Islogin_atNull() =>
                IsNull(tableLoginLog.login_atColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Ismac_addressNull() =>
                IsNull(tableLoginLog.mac_addressColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool IsusernameNull() =>
                IsNull(tableLoginLog.usernameColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setlogin_atNull()
            {
                base[tableLoginLog.login_atColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setmac_addressNull()
            {
                base[tableLoginLog.mac_addressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void SetusernameNull()
            {
                base[tableLoginLog.usernameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public int id
            {
                get =>
                    (int)base[tableLoginLog.idColumn];
                set =>
                    base[tableLoginLog.idColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string username
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableLoginLog.usernameColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'username' in table 'LoginLog' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableLoginLog.usernameColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string login_at
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableLoginLog.login_atColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'login_at' in table 'LoginLog' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableLoginLog.login_atColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string mac_address
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableLoginLog.mac_addressColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'mac_address' in table 'LoginLog' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableLoginLog.mac_addressColumn] = value;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public class LoginLogRowChangeEvent : EventArgs
        {
            private LoginLogRow eventRow;
            private DataRowAction eventAction;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public LoginLogRowChangeEvent(LoginLogRow row, DataRowAction action)
            {
                eventRow = row;
                eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public LoginLogRow Row =>
                eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataRowAction Action =>
                eventAction;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public delegate void LoginLogRowChangeEventHandler(object sender, LoginLogRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class MKView_ContractHamkaranDataTable : TypedTableBase<MKView_ContractHamkaranRow>
        {
            private DataColumn columnکد_پرسنلی;
            private DataColumn columnنام;
            private DataColumn columnنام_خانوادگی;
            private DataColumn columnنام_پدر;
            private DataColumn columnپروژه;
            private DataColumn columnکد_پروژه;
            private DataColumn columnشغل;
            private DataColumn columnکد_ملی;
            private DataColumn columnشماره_شناسنامه;
            private DataColumn columnمحل_صدور;
            private DataColumn columnآخرین_مدرک_و_رشته_تحصیلی;
            private DataColumn columnوضعیت_سربازی;
            private DataColumn columnتاریخ_تولد;
            private DataColumn columnتاریخ_شروع_قرارداد;
            private DataColumn columnتاریخ_پایان_قرارداد;
            private DataColumn columnمدت_قرارداد;
            private DataColumn columnحقوق_پایه;
            private DataColumn columnحق_مسکن;
            private DataColumn columnبن_کارگری;
            private DataColumn columnحق_اولاد;
            private DataColumn columnپایه_سنوات;
            private DataColumn columnEmployeeStatuteID;
            private DataColumn columnتعداد_اولاد;
            private DataColumn columnکد_گروه_شغل;
            private DataColumn columnنام_واحد_یا_سازمان_محل_خدمت;
            private DataColumn columnمدیریت_واحد_یا_سازمان_محل_خدمت;
            private DataColumn columnنشانی_واحد_یا_سازمان_محل_خدمت;
            private DataColumn columnساعت_شروع_کار;
            private DataColumn columnساعت_پایان_کار;
            private DataColumn columncompany_name;
            private DataColumn columnceo_name;
            private DataColumn columnregister_number;
            private DataColumn columnaddress;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event MKView_ContractHamkaranRowChangeEventHandler MKView_ContractHamkaranRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event MKView_ContractHamkaranRowChangeEventHandler MKView_ContractHamkaranRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event MKView_ContractHamkaranRowChangeEventHandler MKView_ContractHamkaranRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event MKView_ContractHamkaranRowChangeEventHandler MKView_ContractHamkaranRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public MKView_ContractHamkaranDataTable()
            {
                TableName = "MKView_ContractHamkaran";
                BeginInit();
                InitClass();
                EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            internal MKView_ContractHamkaranDataTable(DataTable table)
            {
                TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    Namespace = table.Namespace;
                }
                Prefix = table.Prefix;
                MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected MKView_ContractHamkaranDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void AddMKView_ContractHamkaranRow(MKView_ContractHamkaranRow row)
            {
                Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public MKView_ContractHamkaranRow AddMKView_ContractHamkaranRow(string کد_پرسنلی, string نام, string نام_خانوادگی, string نام_پدر, string پروژه, long کد_پروژه, string شغل, string کد_ملی, string شماره_شناسنامه, string محل_صدور, string آخرین_مدرک_و_رشته_تحصیلی, string وضعیت_سربازی, DateTime تاریخ_تولد, DateTime تاریخ_شروع_قرارداد, DateTime تاریخ_پایان_قرارداد, string مدت_قرارداد, decimal حقوق_پایه, decimal حق_مسکن, decimal بن_کارگری, decimal حق_اولاد, decimal پایه_سنوات, long EmployeeStatuteID, int تعداد_اولاد, string کد_گروه_شغل, string نام_واحد_یا_سازمان_محل_خدمت, string مدیریت_واحد_یا_سازمان_محل_خدمت, string نشانی_واحد_یا_سازمان_محل_خدمت, string ساعت_شروع_کار, string ساعت_پایان_کار, string company_name, string ceo_name, string register_number, string address)
            {
                MKView_ContractHamkaranRow row = (MKView_ContractHamkaranRow)NewRow();
                object[] objArray = new object[] {
                    کد_پرسنلی, نام, نام_خانوادگی, نام_پدر, پروژه, کد_پروژه, شغل, کد_ملی, شماره_شناسنامه, محل_صدور, آخرین_مدرک_و_رشته_تحصیلی, وضعیت_سربازی, تاریخ_تولد, تاریخ_شروع_قرارداد, تاریخ_پایان_قرارداد, مدت_قرارداد,
                    حقوق_پایه, حق_مسکن, بن_کارگری, حق_اولاد, پایه_سنوات, EmployeeStatuteID, تعداد_اولاد, کد_گروه_شغل, نام_واحد_یا_سازمان_محل_خدمت, مدیریت_واحد_یا_سازمان_محل_خدمت, نشانی_واحد_یا_سازمان_محل_خدمت, ساعت_شروع_کار, ساعت_پایان_کار, company_name, ceo_name, register_number,
                    address
                };
                row.ItemArray = objArray;
                Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public override DataTable Clone()
            {
                MKView_ContractHamkaranDataTable table = (MKView_ContractHamkaranDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override DataTable CreateInstance() =>
                new MKView_ContractHamkaranDataTable();

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public MKView_ContractHamkaranRow FindByکد_پروژهEmployeeStatuteID(long کد_پروژه, long EmployeeStatuteID)
            {
                object[] keys = new object[] { کد_پروژه, EmployeeStatuteID };
                return (MKView_ContractHamkaranRow)Rows.Find(keys);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override Type GetRowType() =>
                typeof(MKView_ContractHamkaranRow);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                FishDataSet set = new FishDataSet();
                XmlSchemaAny item = new XmlSchemaAny
                {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny
                {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute
                {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "MKView_ContractHamkaranDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = set.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema)enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while (stream.Position != stream.Length && stream.ReadByte() == stream2.ReadByte())
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            private void InitClass()
            {
                columnکد_پرسنلی = new DataColumn("کد پرسنلی", typeof(string), null, MappingType.Element);
                Columns.Add(columnکد_پرسنلی);
                columnنام = new DataColumn("نام", typeof(string), null, MappingType.Element);
                Columns.Add(columnنام);
                columnنام_خانوادگی = new DataColumn("نام خانوادگی", typeof(string), null, MappingType.Element);
                Columns.Add(columnنام_خانوادگی);
                columnنام_پدر = new DataColumn("نام پدر", typeof(string), null, MappingType.Element);
                Columns.Add(columnنام_پدر);
                columnپروژه = new DataColumn("پروژه", typeof(string), null, MappingType.Element);
                Columns.Add(columnپروژه);
                columnکد_پروژه = new DataColumn("کد پروژه", typeof(long), null, MappingType.Element);
                Columns.Add(columnکد_پروژه);
                columnشغل = new DataColumn("شغل", typeof(string), null, MappingType.Element);
                Columns.Add(columnشغل);
                columnکد_ملی = new DataColumn("کد ملی", typeof(string), null, MappingType.Element);
                Columns.Add(columnکد_ملی);
                columnشماره_شناسنامه = new DataColumn("شماره شناسنامه", typeof(string), null, MappingType.Element);
                Columns.Add(columnشماره_شناسنامه);
                columnمحل_صدور = new DataColumn("محل صدور", typeof(string), null, MappingType.Element);
                Columns.Add(columnمحل_صدور);
                columnآخرین_مدرک_و_رشته_تحصیلی = new DataColumn("آخرین مدرک و رشته تحصیلی", typeof(string), null, MappingType.Element);
                Columns.Add(columnآخرین_مدرک_و_رشته_تحصیلی);
                columnوضعیت_سربازی = new DataColumn("وضعیت سربازی", typeof(string), null, MappingType.Element);
                Columns.Add(columnوضعیت_سربازی);
                columnتاریخ_تولد = new DataColumn("تاریخ تولد", typeof(DateTime), null, MappingType.Element);
                Columns.Add(columnتاریخ_تولد);
                columnتاریخ_شروع_قرارداد = new DataColumn("تاریخ شروع قرارداد", typeof(DateTime), null, MappingType.Element);
                Columns.Add(columnتاریخ_شروع_قرارداد);
                columnتاریخ_پایان_قرارداد = new DataColumn("تاریخ پایان قرارداد", typeof(DateTime), null, MappingType.Element);
                Columns.Add(columnتاریخ_پایان_قرارداد);
                columnمدت_قرارداد = new DataColumn("مدت قرارداد", typeof(string), null, MappingType.Element);
                Columns.Add(columnمدت_قرارداد);
                columnحقوق_پایه = new DataColumn("حقوق پایه", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحقوق_پایه);
                columnحق_مسکن = new DataColumn("حق مسکن", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحق_مسکن);
                columnبن_کارگری = new DataColumn("بن کارگری", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnبن_کارگری);
                columnحق_اولاد = new DataColumn("حق اولاد", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحق_اولاد);
                columnپایه_سنوات = new DataColumn("پایه سنوات", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnپایه_سنوات);
                columnEmployeeStatuteID = new DataColumn("EmployeeStatuteID", typeof(long), null, MappingType.Element);
                Columns.Add(columnEmployeeStatuteID);
                columnتعداد_اولاد = new DataColumn("تعداد اولاد", typeof(int), null, MappingType.Element);
                Columns.Add(columnتعداد_اولاد);
                columnکد_گروه_شغل = new DataColumn("کد گروه شغل", typeof(string), null, MappingType.Element);
                Columns.Add(columnکد_گروه_شغل);
                columnنام_واحد_یا_سازمان_محل_خدمت = new DataColumn("نام واحد یا سازمان محل خدمت", typeof(string), null, MappingType.Element);
                Columns.Add(columnنام_واحد_یا_سازمان_محل_خدمت);
                columnمدیریت_واحد_یا_سازمان_محل_خدمت = new DataColumn("مدیریت واحد یا سازمان محل خدمت", typeof(string), null, MappingType.Element);
                Columns.Add(columnمدیریت_واحد_یا_سازمان_محل_خدمت);
                columnنشانی_واحد_یا_سازمان_محل_خدمت = new DataColumn("نشانی واحد یا سازمان محل خدمت", typeof(string), null, MappingType.Element);
                Columns.Add(columnنشانی_واحد_یا_سازمان_محل_خدمت);
                columnساعت_شروع_کار = new DataColumn("ساعت شروع کار", typeof(string), null, MappingType.Element);
                Columns.Add(columnساعت_شروع_کار);
                columnساعت_پایان_کار = new DataColumn("ساعت پایان کار", typeof(string), null, MappingType.Element);
                Columns.Add(columnساعت_پایان_کار);
                columncompany_name = new DataColumn("company_name", typeof(string), null, MappingType.Element);
                Columns.Add(columncompany_name);
                columnceo_name = new DataColumn("ceo_name", typeof(string), null, MappingType.Element);
                Columns.Add(columnceo_name);
                columnregister_number = new DataColumn("register_number", typeof(string), null, MappingType.Element);
                Columns.Add(columnregister_number);
                columnaddress = new DataColumn("address", typeof(string), null, MappingType.Element);
                Columns.Add(columnaddress);
                DataColumn[] columns = new DataColumn[] { columnکد_پروژه, columnEmployeeStatuteID };
                Constraints.Add(new UniqueConstraint("Constraint1", columns, true));
                columnکد_پرسنلی.AllowDBNull = false;
                columnکد_پرسنلی.MaxLength = 100;
                columnنام.MaxLength = 50;
                columnنام_خانوادگی.MaxLength = 50;
                columnنام_پدر.MaxLength = 50;
                columnپروژه.AllowDBNull = false;
                columnپروژه.MaxLength = 400;
                columnکد_پروژه.AllowDBNull = false;
                columnشغل.MaxLength = 400;
                columnکد_ملی.MaxLength = 20;
                columnشماره_شناسنامه.MaxLength = 20;
                columnمحل_صدور.ReadOnly = true;
                columnمحل_صدور.MaxLength = 1;
                columnآخرین_مدرک_و_رشته_تحصیلی.ReadOnly = true;
                columnآخرین_مدرک_و_رشته_تحصیلی.MaxLength = 1;
                columnوضعیت_سربازی.ReadOnly = true;
                columnوضعیت_سربازی.MaxLength = 9;
                columnتاریخ_شروع_قرارداد.ReadOnly = true;
                columnتاریخ_پایان_قرارداد.ReadOnly = true;
                columnمدت_قرارداد.ReadOnly = true;
                columnمدت_قرارداد.MaxLength = 1;
                columnحقوق_پایه.ReadOnly = true;
                columnحق_مسکن.ReadOnly = true;
                columnبن_کارگری.ReadOnly = true;
                columnحق_اولاد.ReadOnly = true;
                columnپایه_سنوات.ReadOnly = true;
                columnEmployeeStatuteID.AllowDBNull = false;
                columnتعداد_اولاد.ReadOnly = true;
                columnکد_گروه_شغل.MaxLength = 0xff;
                columnنام_واحد_یا_سازمان_محل_خدمت.MaxLength = 0xff;
                columnمدیریت_واحد_یا_سازمان_محل_خدمت.MaxLength = 0xff;
                columnنشانی_واحد_یا_سازمان_محل_خدمت.MaxLength = 0xff;
                columnساعت_شروع_کار.MaxLength = 0xff;
                columnساعت_پایان_کار.MaxLength = 0xff;
                columncompany_name.MaxLength = 0xff;
                columnceo_name.MaxLength = 0xff;
                columnregister_number.MaxLength = 0xff;
                columnaddress.MaxLength = 0xff;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            internal void InitVars()
            {
                columnکد_پرسنلی = Columns["کد پرسنلی"];
                columnنام = Columns["نام"];
                columnنام_خانوادگی = Columns["نام خانوادگی"];
                columnنام_پدر = Columns["نام پدر"];
                columnپروژه = Columns["پروژه"];
                columnکد_پروژه = Columns["کد پروژه"];
                columnشغل = Columns["شغل"];
                columnکد_ملی = Columns["کد ملی"];
                columnشماره_شناسنامه = Columns["شماره شناسنامه"];
                columnمحل_صدور = Columns["محل صدور"];
                columnآخرین_مدرک_و_رشته_تحصیلی = Columns["آخرین مدرک و رشته تحصیلی"];
                columnوضعیت_سربازی = Columns["وضعیت سربازی"];
                columnتاریخ_تولد = Columns["تاریخ تولد"];
                columnتاریخ_شروع_قرارداد = Columns["تاریخ شروع قرارداد"];
                columnتاریخ_پایان_قرارداد = Columns["تاریخ پایان قرارداد"];
                columnمدت_قرارداد = Columns["مدت قرارداد"];
                columnحقوق_پایه = Columns["حقوق پایه"];
                columnحق_مسکن = Columns["حق مسکن"];
                columnبن_کارگری = Columns["بن کارگری"];
                columnحق_اولاد = Columns["حق اولاد"];
                columnپایه_سنوات = Columns["پایه سنوات"];
                columnEmployeeStatuteID = Columns["EmployeeStatuteID"];
                columnتعداد_اولاد = Columns["تعداد اولاد"];
                columnکد_گروه_شغل = Columns["کد گروه شغل"];
                columnنام_واحد_یا_سازمان_محل_خدمت = Columns["نام واحد یا سازمان محل خدمت"];
                columnمدیریت_واحد_یا_سازمان_محل_خدمت = Columns["مدیریت واحد یا سازمان محل خدمت"];
                columnنشانی_واحد_یا_سازمان_محل_خدمت = Columns["نشانی واحد یا سازمان محل خدمت"];
                columnساعت_شروع_کار = Columns["ساعت شروع کار"];
                columnساعت_پایان_کار = Columns["ساعت پایان کار"];
                columncompany_name = Columns["company_name"];
                columnceo_name = Columns["ceo_name"];
                columnregister_number = Columns["register_number"];
                columnaddress = Columns["address"];
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public MKView_ContractHamkaranRow NewMKView_ContractHamkaranRow() =>
                (MKView_ContractHamkaranRow)NewRow();

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) =>
                new MKView_ContractHamkaranRow(builder);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (MKView_ContractHamkaranRowChanged != null)
                {
                    MKView_ContractHamkaranRowChanged(this, new MKView_ContractHamkaranRowChangeEvent((MKView_ContractHamkaranRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (MKView_ContractHamkaranRowChanging != null)
                {
                    MKView_ContractHamkaranRowChanging(this, new MKView_ContractHamkaranRowChangeEvent((MKView_ContractHamkaranRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (MKView_ContractHamkaranRowDeleted != null)
                {
                    MKView_ContractHamkaranRowDeleted(this, new MKView_ContractHamkaranRowChangeEvent((MKView_ContractHamkaranRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (MKView_ContractHamkaranRowDeleting != null)
                {
                    MKView_ContractHamkaranRowDeleting(this, new MKView_ContractHamkaranRowChangeEvent((MKView_ContractHamkaranRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void RemoveMKView_ContractHamkaranRow(MKView_ContractHamkaranRow row)
            {
                Rows.Remove(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کد_پرسنلیColumn =>
                columnکد_پرسنلی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn نامColumn =>
                columnنام;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn نام_خانوادگیColumn =>
                columnنام_خانوادگی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn نام_پدرColumn =>
                columnنام_پدر;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn پروژهColumn =>
                columnپروژه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کد_پروژهColumn =>
                columnکد_پروژه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn شغلColumn =>
                columnشغل;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کد_ملیColumn =>
                columnکد_ملی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn شماره_شناسنامهColumn =>
                columnشماره_شناسنامه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn محل_صدورColumn =>
                columnمحل_صدور;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn آخرین_مدرک_و_رشته_تحصیلیColumn =>
                columnآخرین_مدرک_و_رشته_تحصیلی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn وضعیت_سربازیColumn =>
                columnوضعیت_سربازی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn تاریخ_تولدColumn =>
                columnتاریخ_تولد;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn تاریخ_شروع_قراردادColumn =>
                columnتاریخ_شروع_قرارداد;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn تاریخ_پایان_قراردادColumn =>
                columnتاریخ_پایان_قرارداد;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn مدت_قراردادColumn =>
                columnمدت_قرارداد;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حقوق_پایهColumn =>
                columnحقوق_پایه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حق_مسکنColumn =>
                columnحق_مسکن;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn بن_کارگریColumn =>
                columnبن_کارگری;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حق_اولادColumn =>
                columnحق_اولاد;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn پایه_سنواتColumn =>
                columnپایه_سنوات;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn EmployeeStatuteIDColumn =>
                columnEmployeeStatuteID;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn تعداد_اولادColumn =>
                columnتعداد_اولاد;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کد_گروه_شغلColumn =>
                columnکد_گروه_شغل;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn نام_واحد_یا_سازمان_محل_خدمتColumn =>
                columnنام_واحد_یا_سازمان_محل_خدمت;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn مدیریت_واحد_یا_سازمان_محل_خدمتColumn =>
                columnمدیریت_واحد_یا_سازمان_محل_خدمت;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn نشانی_واحد_یا_سازمان_محل_خدمتColumn =>
                columnنشانی_واحد_یا_سازمان_محل_خدمت;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn ساعت_شروع_کارColumn =>
                columnساعت_شروع_کار;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn ساعت_پایان_کارColumn =>
                columnساعت_پایان_کار;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn company_nameColumn =>
                columncompany_name;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn ceo_nameColumn =>
                columnceo_name;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn register_numberColumn =>
                columnregister_number;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn addressColumn =>
                columnaddress;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), Browsable(false)]
            public int Count =>
                Rows.Count;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public MKView_ContractHamkaranRow this[int index] =>
                (MKView_ContractHamkaranRow)Rows[index];
        }

        public class MKView_ContractHamkaranRow : DataRow
        {
            private MKView_ContractHamkaranDataTable tableMKView_ContractHamkaran;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            internal MKView_ContractHamkaranRow(DataRowBuilder rb) : base(rb)
            {
                tableMKView_ContractHamkaran = (MKView_ContractHamkaranDataTable)Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool IsaddressNull() =>
                IsNull(tableMKView_ContractHamkaran.addressColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isceo_nameNull() =>
                IsNull(tableMKView_ContractHamkaran.ceo_nameColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Iscompany_nameNull() =>
                IsNull(tableMKView_ContractHamkaran.company_nameColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isregister_numberNull() =>
                IsNull(tableMKView_ContractHamkaran.register_numberColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isآخرین_مدرک_و_رشته_تحصیلیNull() =>
                IsNull(tableMKView_ContractHamkaran.آخرین_مدرک_و_رشته_تحصیلیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isبن_کارگریNull() =>
                IsNull(tableMKView_ContractHamkaran.بن_کارگریColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isپایه_سنواتNull() =>
                IsNull(tableMKView_ContractHamkaran.پایه_سنواتColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isتاریخ_پایان_قراردادNull() =>
                IsNull(tableMKView_ContractHamkaran.تاریخ_پایان_قراردادColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isتاریخ_تولدNull() =>
                IsNull(tableMKView_ContractHamkaran.تاریخ_تولدColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isتاریخ_شروع_قراردادNull() =>
                IsNull(tableMKView_ContractHamkaran.تاریخ_شروع_قراردادColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isتعداد_اولادNull() =>
                IsNull(tableMKView_ContractHamkaran.تعداد_اولادColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isحق_اولادNull() =>
                IsNull(tableMKView_ContractHamkaran.حق_اولادColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isحق_مسکنNull() =>
                IsNull(tableMKView_ContractHamkaran.حق_مسکنColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isحقوق_پایهNull() =>
                IsNull(tableMKView_ContractHamkaran.حقوق_پایهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isساعت_پایان_کارNull() =>
                IsNull(tableMKView_ContractHamkaran.ساعت_پایان_کارColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isساعت_شروع_کارNull() =>
                IsNull(tableMKView_ContractHamkaran.ساعت_شروع_کارColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool IsشغلNull() =>
                IsNull(tableMKView_ContractHamkaran.شغلColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isشماره_شناسنامهNull() =>
                IsNull(tableMKView_ContractHamkaran.شماره_شناسنامهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isکد_گروه_شغلNull() =>
                IsNull(tableMKView_ContractHamkaran.کد_گروه_شغلColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isکد_ملیNull() =>
                IsNull(tableMKView_ContractHamkaran.کد_ملیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isمحل_صدورNull() =>
                IsNull(tableMKView_ContractHamkaran.محل_صدورColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isمدت_قراردادNull() =>
                IsNull(tableMKView_ContractHamkaran.مدت_قراردادColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isمدیریت_واحد_یا_سازمان_محل_خدمتNull() =>
                IsNull(tableMKView_ContractHamkaran.مدیریت_واحد_یا_سازمان_محل_خدمتColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isنام_پدرNull() =>
                IsNull(tableMKView_ContractHamkaran.نام_پدرColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isنام_خانوادگیNull() =>
                IsNull(tableMKView_ContractHamkaran.نام_خانوادگیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isنام_واحد_یا_سازمان_محل_خدمتNull() =>
                IsNull(tableMKView_ContractHamkaran.نام_واحد_یا_سازمان_محل_خدمتColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool IsنامNull() =>
                IsNull(tableMKView_ContractHamkaran.نامColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isنشانی_واحد_یا_سازمان_محل_خدمتNull() =>
                IsNull(tableMKView_ContractHamkaran.نشانی_واحد_یا_سازمان_محل_خدمتColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Isوضعیت_سربازیNull() =>
                IsNull(tableMKView_ContractHamkaran.وضعیت_سربازیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void SetaddressNull()
            {
                base[tableMKView_ContractHamkaran.addressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setceo_nameNull()
            {
                base[tableMKView_ContractHamkaran.ceo_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setcompany_nameNull()
            {
                base[tableMKView_ContractHamkaran.company_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setregister_numberNull()
            {
                base[tableMKView_ContractHamkaran.register_numberColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setآخرین_مدرک_و_رشته_تحصیلیNull()
            {
                base[tableMKView_ContractHamkaran.آخرین_مدرک_و_رشته_تحصیلیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setبن_کارگریNull()
            {
                base[tableMKView_ContractHamkaran.بن_کارگریColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setپایه_سنواتNull()
            {
                base[tableMKView_ContractHamkaran.پایه_سنواتColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setتاریخ_پایان_قراردادNull()
            {
                base[tableMKView_ContractHamkaran.تاریخ_پایان_قراردادColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setتاریخ_تولدNull()
            {
                base[tableMKView_ContractHamkaran.تاریخ_تولدColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setتاریخ_شروع_قراردادNull()
            {
                base[tableMKView_ContractHamkaran.تاریخ_شروع_قراردادColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setتعداد_اولادNull()
            {
                base[tableMKView_ContractHamkaran.تعداد_اولادColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setحق_اولادNull()
            {
                base[tableMKView_ContractHamkaran.حق_اولادColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setحق_مسکنNull()
            {
                base[tableMKView_ContractHamkaran.حق_مسکنColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setحقوق_پایهNull()
            {
                base[tableMKView_ContractHamkaran.حقوق_پایهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setساعت_پایان_کارNull()
            {
                base[tableMKView_ContractHamkaran.ساعت_پایان_کارColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setساعت_شروع_کارNull()
            {
                base[tableMKView_ContractHamkaran.ساعت_شروع_کارColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void SetشغلNull()
            {
                base[tableMKView_ContractHamkaran.شغلColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setشماره_شناسنامهNull()
            {
                base[tableMKView_ContractHamkaran.شماره_شناسنامهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setکد_گروه_شغلNull()
            {
                base[tableMKView_ContractHamkaran.کد_گروه_شغلColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setکد_ملیNull()
            {
                base[tableMKView_ContractHamkaran.کد_ملیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setمحل_صدورNull()
            {
                base[tableMKView_ContractHamkaran.محل_صدورColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setمدت_قراردادNull()
            {
                base[tableMKView_ContractHamkaran.مدت_قراردادColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setمدیریت_واحد_یا_سازمان_محل_خدمتNull()
            {
                base[tableMKView_ContractHamkaran.مدیریت_واحد_یا_سازمان_محل_خدمتColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setنام_پدرNull()
            {
                base[tableMKView_ContractHamkaran.نام_پدرColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setنام_خانوادگیNull()
            {
                base[tableMKView_ContractHamkaran.نام_خانوادگیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setنام_واحد_یا_سازمان_محل_خدمتNull()
            {
                base[tableMKView_ContractHamkaran.نام_واحد_یا_سازمان_محل_خدمتColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void SetنامNull()
            {
                base[tableMKView_ContractHamkaran.نامColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setنشانی_واحد_یا_سازمان_محل_خدمتNull()
            {
                base[tableMKView_ContractHamkaran.نشانی_واحد_یا_سازمان_محل_خدمتColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Setوضعیت_سربازیNull()
            {
                base[tableMKView_ContractHamkaran.وضعیت_سربازیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string کد_پرسنلی
            {
                get =>
                    (string)base[tableMKView_ContractHamkaran.کد_پرسنلیColumn];
                set =>
                    base[tableMKView_ContractHamkaran.کد_پرسنلیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string نام
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.نامColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'نام' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.نامColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string نام_خانوادگی
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.نام_خانوادگیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'نام خانوادگی' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.نام_خانوادگیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string نام_پدر
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.نام_پدرColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'نام پدر' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.نام_پدرColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string پروژه
            {
                get =>
                    (string)base[tableMKView_ContractHamkaran.پروژهColumn];
                set =>
                    base[tableMKView_ContractHamkaran.پروژهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public long کد_پروژه
            {
                get =>
                    (long)base[tableMKView_ContractHamkaran.کد_پروژهColumn];
                set =>
                    base[tableMKView_ContractHamkaran.کد_پروژهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string شغل
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.شغلColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'شغل' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.شغلColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string کد_ملی
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.کد_ملیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کد ملی' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.کد_ملیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string شماره_شناسنامه
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.شماره_شناسنامهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'شماره شناسنامه' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.شماره_شناسنامهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string محل_صدور
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.محل_صدورColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'محل صدور' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.محل_صدورColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string آخرین_مدرک_و_رشته_تحصیلی
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.آخرین_مدرک_و_رشته_تحصیلیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'آخرین مدرک و رشته تحصیلی' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.آخرین_مدرک_و_رشته_تحصیلیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string وضعیت_سربازی
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.وضعیت_سربازیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'وضعیت سربازی' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.وضعیت_سربازیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DateTime تاریخ_تولد
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime)base[tableMKView_ContractHamkaran.تاریخ_تولدColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'تاریخ تولد' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return time;
                }
                set =>
                    base[tableMKView_ContractHamkaran.تاریخ_تولدColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DateTime تاریخ_شروع_قرارداد
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime)base[tableMKView_ContractHamkaran.تاریخ_شروع_قراردادColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'تاریخ شروع قرارداد' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return time;
                }
                set =>
                    base[tableMKView_ContractHamkaran.تاریخ_شروع_قراردادColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DateTime تاریخ_پایان_قرارداد
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime)base[tableMKView_ContractHamkaran.تاریخ_پایان_قراردادColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'تاریخ پایان قرارداد' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return time;
                }
                set =>
                    base[tableMKView_ContractHamkaran.تاریخ_پایان_قراردادColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string مدت_قرارداد
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.مدت_قراردادColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'مدت قرارداد' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.مدت_قراردادColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حقوق_پایه
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_ContractHamkaran.حقوق_پایهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'حقوق پایه' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_ContractHamkaran.حقوق_پایهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حق_مسکن
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_ContractHamkaran.حق_مسکنColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'حق مسکن' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_ContractHamkaran.حق_مسکنColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal بن_کارگری
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_ContractHamkaran.بن_کارگریColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'بن کارگری' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_ContractHamkaran.بن_کارگریColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حق_اولاد
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_ContractHamkaran.حق_اولادColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'حق اولاد' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_ContractHamkaran.حق_اولادColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal پایه_سنوات
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_ContractHamkaran.پایه_سنواتColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'پایه سنوات' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_ContractHamkaran.پایه_سنواتColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public long EmployeeStatuteID
            {
                get =>
                    (long)base[tableMKView_ContractHamkaran.EmployeeStatuteIDColumn];
                set =>
                    base[tableMKView_ContractHamkaran.EmployeeStatuteIDColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public int تعداد_اولاد
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int)base[tableMKView_ContractHamkaran.تعداد_اولادColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'تعداد اولاد' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_ContractHamkaran.تعداد_اولادColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string کد_گروه_شغل
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.کد_گروه_شغلColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کد گروه شغل' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.کد_گروه_شغلColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string نام_واحد_یا_سازمان_محل_خدمت
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.نام_واحد_یا_سازمان_محل_خدمتColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'نام واحد یا سازمان محل خدمت' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.نام_واحد_یا_سازمان_محل_خدمتColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string مدیریت_واحد_یا_سازمان_محل_خدمت
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.مدیریت_واحد_یا_سازمان_محل_خدمتColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'مدیریت واحد یا سازمان محل خدمت' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.مدیریت_واحد_یا_سازمان_محل_خدمتColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string نشانی_واحد_یا_سازمان_محل_خدمت
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.نشانی_واحد_یا_سازمان_محل_خدمتColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'نشانی واحد یا سازمان محل خدمت' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.نشانی_واحد_یا_سازمان_محل_خدمتColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string ساعت_شروع_کار
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.ساعت_شروع_کارColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ساعت شروع کار' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.ساعت_شروع_کارColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string ساعت_پایان_کار
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.ساعت_پایان_کارColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ساعت پایان کار' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.ساعت_پایان_کارColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string company_name
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.company_nameColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'company_name' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.company_nameColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string ceo_name
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.ceo_nameColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ceo_name' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.ceo_nameColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string register_number
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.register_numberColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'register_number' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.register_numberColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string address
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_ContractHamkaran.addressColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'address' in table 'MKView_ContractHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_ContractHamkaran.addressColumn] = value;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public class MKView_ContractHamkaranRowChangeEvent : EventArgs
        {
            private MKView_ContractHamkaranRow eventRow;
            private DataRowAction eventAction;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public MKView_ContractHamkaranRowChangeEvent(MKView_ContractHamkaranRow row, DataRowAction action)
            {
                eventRow = row;
                eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public MKView_ContractHamkaranRow Row =>
                eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataRowAction Action =>
                eventAction;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public delegate void MKView_ContractHamkaranRowChangeEventHandler(object sender, MKView_ContractHamkaranRowChangeEvent e);

        [Serializable, XmlSchemaProvider("GetTypedTableSchema")]
        public class MKView_FishHamkaranDataTable : TypedTableBase<MKView_FishHamkaranRow>
        {
            private DataColumn columnکارکرد_عادی;
            private DataColumn columnکارکرد_اضافه_کاری;
            private DataColumn columnکارکرد_تعطیل_کاری;
            private DataColumn columnجمعه_کاری;
            private DataColumn columnکارکرد_شبکاری;
            private DataColumn columnکارکرد_شب_کاری_1;
            private DataColumn columnکارکرد_مرخصی_استحقاقی;
            private DataColumn columnکارکرد_کارانه;
            private DataColumn columnکارکرد_کارانه2;
            private DataColumn columnکارکرد_ساعتی;
            private DataColumn columnپایه_سنوات;
            private DataColumn columnحقوق_پایه;
            private DataColumn columnحق_اولاد;
            private DataColumn columnحق_اولاد_معوق;
            private DataColumn columnحق_مسکن;
            private DataColumn columnبن_کارگری;
            private DataColumn columnحق_خواربار;
            private DataColumn columnاضافه_کاری;
            private DataColumn columnتعطیل_کاری;
            private DataColumn columnشبکاری;
            private DataColumn columnحق_شیر;
            private DataColumn columnشیفت;
            private DataColumn columnشیفت_ساعتی;
            private DataColumn columnمبلغ_تناژ;
            private DataColumn columnتنخواه;
            private DataColumn columnحق_سوخت;
            private DataColumn columnماموریت;
            private DataColumn columnفوق_العاده_ماموریت;
            private DataColumn columnفوق_العاده_سرپرستی;
            private DataColumn columnکارانه;
            private DataColumn columnکارانه_ثابت;
            private DataColumn columnکارانه_ثابت2;
            private DataColumn columnسایر_مزایا;
            private DataColumn columnمزایای_معوقه;
            private DataColumn columnکارانه_معوق;
            private DataColumn columnفوق_العاده_شغل;
            private DataColumn columnپاداش_پرسنل;
            private DataColumn columnایاب_و_ذهاب;
            private DataColumn columnمعوقه_حقوق;
            private DataColumn columnبن_رمضان;
            private DataColumn columnهزینه_جارو;
            private DataColumn columnپایه_سنوات_معوق;
            private DataColumn columnسایر_مزایای_استیجاری;
            private DataColumn columnبدهکاران_کارکنان;
            private DataColumn columnبیمه_تامین_اجتماعی_سهم_کارگر;
            private DataColumn columnبیمه_تکمیلی_سهم_کارمند;
            private DataColumn columnسایر_کسور;
            private DataColumn columnخسارت_کارکنان;
            private DataColumn columnکارکنان_بدهکار;
            private DataColumn columnمساعده;
            private DataColumn columnتعهدات_دولتی_کارمند;
            private DataColumn columnجمع_اقساط_وام;
            private DataColumn columnتعاونی_مصرف_کارکنان;
            private DataColumn columnمالیات_حقوق;
            private DataColumn columnجمع_مزایا;
            private DataColumn columnجمع_کسور;
            private DataColumn columnخالص_پرداختی;
            private DataColumn columnشماره_حساب;
            private DataColumn columnنام;
            private DataColumn columnنام_خانوادگی;
            private DataColumn columnکد_پرسنلی;
            private DataColumn columnنام_پدر;
            private DataColumn columnکد_ملی;
            private DataColumn columnشماره_شناسنامه;
            private DataColumn columnتاریخ_تولد;
            private DataColumn columnنام_شعبه;
            private DataColumn columnسال;
            private DataColumn columnماه;
            private DataColumn columnشماره_بیمه;
            private DataColumn columnکارکرد_موثر;
            private DataColumn columnپاداش;
            private DataColumn columnتعداد_اولاد;
            private DataColumn columnمالیات;
            private DataColumn columnبیمه_تامین_اجتماعی_سهم_کارمند;
            private DataColumn columnدستمزد_روزانه;
            private DataColumn columnفوق_العاده_جذب;
            private DataColumn columnفوق_العاده_کارایی;
            private DataColumn columnمعوقه_دستی;
            private DataColumn columnبیمه_تامین_اجتماعی_سهم_کارفرما;
            private DataColumn columnبیمه_بیکاری;
            private DataColumn columnبیمه_تکمیلی_سهم_کارفرما;
            private DataColumn columnمعوقه_دستی_با_مالیات;
            private DataColumn columnفوق_العاده_خلاقیت;
            private DataColumn columnفوق_العاده_پست;
            private DataColumn columnحق_ایاب_و_ذهاب;
            private DataColumn columnفوق_العاده_منزلت_شغلی;
            private DataColumn columnماموریت_عادی;
            private DataColumn columnماموریت_روز_تعلیل;
            private DataColumn columnماموریت_حومه;
            private DataColumn columnحق_غذای_ماموریت_حومه;
            private DataColumn columnاحضار_به_کار_پایین_تر_از_5_س;
            private DataColumn columnاحضار_به_کار_بین_5_تا_10_س;
            private DataColumn columnاحضار_به_کار_بالاتر_از_10_س;
            private DataColumn columnهزینه_موبایل;
            private DataColumn columnکسر_کار;
            private DataColumn columnحقوق_گروه_مشاور;
            private DataColumn columnحقوق_گروه_ساعتی;
            private DataColumn columnغیبت_ماهانه;
            private DataColumn columnاحضار_به_کار_پایین_تر_از_5س;
            private DataColumn columnاحضار_به_کار_بین_5_تا_10س;
            private DataColumn columnسایر2;
            private DataColumn columnروند_حقوق;
            private DataColumn columnکارکرد_شب_کاری;
            private DataColumn columnسایر3;
            private DataColumn columnسایر1;
            private DataColumn columnنوبت_کاری_10;
            private DataColumn columnماموریت_عادی_نهایی;
            private DataColumn columnماموریت_تعلیل_نهایی;
            private DataColumn columnکارکرد_ماموریت_حومه_نهایی;
            private DataColumn columnفوق_العاده_در_دسترسی_نهایی;
            private DataColumn columnبیمه_تکمیلی_سازمانی_کارمند;
            private DataColumn columnتعطیل_کاری_دستور_کار;
            private DataColumn columnکارانه_2;
            private DataColumn columnحق_ناهار;
            private DataColumn columnخالص_حقوق;
            private DataColumn columnگروه_شغلی;
            private DataColumn columnمزد_ماهانه;
            //private DataColumn columnکارکرد_شبکاری_روز;
            private DataColumn columnNightWorking;
            private DataColumn columnHolidayWorking;
            private DataColumn columnکارکرد_تعطیل_کاری_روز;
            private DataColumn columnبیمه_تکمیلی;
            private DataColumn columnقسط_وام_مسکن;
            private DataColumn columnمزد_روزانه;
            private DataColumn columnتعهدات_دولتی;
            private DataColumn columnدستمزد_ماهانه;
            private DataColumn columnقابل_پرداخت;
            

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event MKView_FishHamkaranRowChangeEventHandler MKView_FishHamkaranRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event MKView_FishHamkaranRowChangeEventHandler MKView_FishHamkaranRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event MKView_FishHamkaranRowChangeEventHandler MKView_FishHamkaranRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            [field: CompilerGenerated, DebuggerBrowsable(0)]
            public event MKView_FishHamkaranRowChangeEventHandler MKView_FishHamkaranRowDeleting;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public MKView_FishHamkaranDataTable()
            {
                TableName = "MKView_FishHamkaran";
                BeginInit();
                InitClass();
                EndInit();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            internal MKView_FishHamkaranDataTable(DataTable table)
            {
                TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    Namespace = table.Namespace;
                }
                Prefix = table.Prefix;
                MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected MKView_FishHamkaranDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                InitVars();
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void AddMKView_FishHamkaranRow(MKView_FishHamkaranRow row)
            {
                Rows.Add(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public MKView_FishHamkaranRow AddMKView_FishHamkaranRow(string کد_پرسنلی, string نام, string نام_خانوادگی, string نام_پدر, string کد_ملی, string شماره_شناسنامه, DateTime تاریخ_تولد, string نام_شعبه, string شماره_حساب, string سال, string ماه, string شماره_بیمه, decimal کارکرد_موثر, decimal حقوق_پایه, decimal اضافه_کاری, decimal حق_مسکن, decimal حق_خواربار, decimal حق_اولاد, decimal تعطیل_کاری, decimal بن_کارگری, decimal پاداش, decimal پاداش_پرسنل, decimal حق_شیر, decimal تعداد_اولاد, decimal جمع_مزایا, decimal شب_کاری, decimal مالیات, decimal بیمه_تامین_اجتماعی_سهم_کارمند, decimal بیمه_تکمیلی_سهم_کارمند, decimal جمع_اقساط_وام, decimal دستمزد_روزانه, decimal فوق_العاده_جذب, decimal مساعده, decimal فوق_العاده_کارایی, decimal جمع_کسور, decimal خالص_پرداختی, decimal معوقه_دستی_, decimal بیمه_تامین_اجتماعی_سهم_کارفرما, decimal بیمه_بیکاری_, decimal بیمه_تکمیلی_سهم_کارفرما, decimal معوقه_دستی_با_مالیات, decimal فوق_العاده_خلاقیت, decimal فوق_العاده_شغل, decimal فوق_العاده_پست_, decimal حق_ایاب_و_ذهاب, decimal فوق_العاده_منزلت_شغلی, decimal ماموریت_عادی, decimal ماموریت_روز_تعلیل, decimal ماموریت_حومه, decimal حق_غذای_ماموریت_حومه, decimal احضار_به_کار_پایین_تر_از_5_س, decimal احضار_به_کار_بین_5_تا_10_س, decimal احضار_به_کار_بالاتر_از_10_س, decimal هزینه_موبایل, decimal کسر_کار, decimal حقوق_گروه_مشاور, decimal حقوق_گروه_ساعتی, decimal غیبت_ماهانه, decimal کارکرد_اضافه_کاری, decimal کارکرد_تعطیل_کاری, decimal کارکرد_شبکاری, decimal کارکرد_شب_کاری_1, decimal کارکرد_شب_کاری, decimal سایر3, decimal سایر1, decimal _نوبت_کاری_10__, decimal ماموریت_عادی_نهایی, decimal ماموریت_تعلیل_نهایی, decimal کارکرد_ماموریت_حومه_نهایی, decimal فوق_العاده_در_دسترسی_نهایی, decimal احضار_به_کار_پایین_تر_از_5س, decimal احضار_به_کار_بین_5_تا_10س, decimal سایر_کسور, decimal سایر2, decimal روند_حقوق, decimal سایر_مزایا, decimal خسارت_کارکنان, decimal پایه_سنوات)
            {
                MKView_FishHamkaranRow row = (MKView_FishHamkaranRow)NewRow();
                object[] objArray = new object[] {
                    کد_پرسنلی, نام, نام_خانوادگی, نام_پدر, کد_ملی, شماره_شناسنامه, تاریخ_تولد, نام_شعبه, شماره_حساب, سال, ماه, شماره_بیمه, کارکرد_موثر, حقوق_پایه, اضافه_کاری, حق_مسکن,
                    حق_خواربار, حق_اولاد, تعطیل_کاری, بن_کارگری, پاداش, پاداش_پرسنل, حق_شیر, تعداد_اولاد, جمع_مزایا, شب_کاری, مالیات, بیمه_تامین_اجتماعی_سهم_کارمند, بیمه_تکمیلی_سهم_کارمند, جمع_اقساط_وام, دستمزد_روزانه, فوق_العاده_جذب,
                    مساعده, فوق_العاده_کارایی, جمع_کسور, خالص_پرداختی, معوقه_دستی_, بیمه_تامین_اجتماعی_سهم_کارفرما, بیمه_بیکاری_, بیمه_تکمیلی_سهم_کارفرما, معوقه_دستی_با_مالیات, فوق_العاده_خلاقیت, فوق_العاده_شغل, فوق_العاده_پست_, حق_ایاب_و_ذهاب, فوق_العاده_منزلت_شغلی, ماموریت_عادی, ماموریت_روز_تعلیل,
                    ماموریت_حومه, حق_غذای_ماموریت_حومه, احضار_به_کار_پایین_تر_از_5_س, احضار_به_کار_بین_5_تا_10_س, احضار_به_کار_بالاتر_از_10_س, هزینه_موبایل, کسر_کار, حقوق_گروه_مشاور, حقوق_گروه_ساعتی, غیبت_ماهانه, کارکرد_اضافه_کاری, کارکرد_تعطیل_کاری, کارکرد_شبکاری, کارکرد_شب_کاری_1, کارکرد_شب_کاری, سایر3,
                    سایر1, _نوبت_کاری_10__, ماموریت_عادی_نهایی, ماموریت_تعلیل_نهایی, کارکرد_ماموریت_حومه_نهایی, فوق_العاده_در_دسترسی_نهایی, احضار_به_کار_پایین_تر_از_5س, احضار_به_کار_بین_5_تا_10س, سایر_کسور, سایر2, روند_حقوق, سایر_مزایا, خسارت_کارکنان, پایه_سنوات
                };
                row.ItemArray = objArray;
                Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public override DataTable Clone()
            {
                MKView_FishHamkaranDataTable table = (MKView_FishHamkaranDataTable)base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override DataTable CreateInstance() =>
                new MKView_FishHamkaranDataTable();

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override Type GetRowType() =>
                typeof(MKView_FishHamkaranRow);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                FishDataSet set = new FishDataSet();
                XmlSchemaAny item = new XmlSchemaAny
                {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = 0M,
                    MaxOccurs = 79228162514264337593543950335M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny
                {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = 1M,
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute
                {
                    Name = "namespace",
                    FixedValue = set.Namespace
                };
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute
                {
                    Name = "tableTypeName",
                    FixedValue = "MKView_FishHamkaranDataTable"
                };
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = set.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema)enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length == stream2.Length)
                            {
                                stream.Position = 0L;
                                stream2.Position = 0L;
                                while (stream.Position != stream.Length && stream.ReadByte() == stream2.ReadByte())
                                {
                                }
                                if (stream.Position == stream.Length)
                                {
                                    return type;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            private void InitClass()
            {
                columnکارکرد_عادی = new DataColumn("کارکرد عادی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارکرد_عادی);

                columnکارکرد_اضافه_کاری = new DataColumn("کارکرد اضافه کاری", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارکرد_اضافه_کاری);

                columnکارکرد_تعطیل_کاری = new DataColumn("کارکرد تعطیل کاری", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارکرد_تعطیل_کاری);

                columnجمعه_کاری = new DataColumn("جمعه کاری", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnجمعه_کاری);

                columnکارکرد_شبکاری = new DataColumn("کارکرد شبکاری", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارکرد_شبکاری);

                columnکارکرد_شب_کاری_1 = new DataColumn("کارکرد شب کاری 1", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارکرد_شب_کاری_1);

                columnکارکرد_مرخصی_استحقاقی = new DataColumn("کارکرد مرخصی استحقاقی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارکرد_مرخصی_استحقاقی);

                columnکارکرد_کارانه = new DataColumn("کارکرد کارانه", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارکرد_کارانه);

                columnکارکرد_کارانه2 = new DataColumn("کارکرد کارانه2", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارکرد_کارانه2);

                columnکارکرد_ساعتی = new DataColumn("کارکرد ساعتی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارکرد_ساعتی);

                columnپایه_سنوات = new DataColumn("پایه سنوات", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnپایه_سنوات);

                columnحقوق_پایه = new DataColumn("حقوق پایه", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحقوق_پایه);

                columnحق_اولاد = new DataColumn("حق اولاد", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحق_اولاد);

                columnحق_اولاد_معوق = new DataColumn("حق اولاد معوق", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحق_اولاد_معوق);

                columnحق_مسکن = new DataColumn("حق مسکن", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحق_مسکن);

                columnبن_کارگری = new DataColumn("بن کارگری", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnبن_کارگری);

                columnحق_خواربار = new DataColumn("حق خواربار", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحق_خواربار);

                columnاضافه_کاری = new DataColumn("اضافه کاری", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnاضافه_کاری);

                columnتعطیل_کاری = new DataColumn("تعطیل کاری", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnتعطیل_کاری);

                columnشبکاری = new DataColumn("شب کاری", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnشبکاری);

                columnحق_شیر = new DataColumn("حق شیر", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحق_شیر);

                columnشیفت = new DataColumn("شیفت", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnشیفت);

                columnشیفت_ساعتی = new DataColumn("شیفت ساعتی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnشیفت_ساعتی);

                columnمبلغ_تناژ = new DataColumn("مبلغ تناژ", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnمبلغ_تناژ);

                columnتنخواه = new DataColumn("تنخواه", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnتنخواه);

                columnحق_سوخت = new DataColumn("حق سوخت", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحق_سوخت);

                columnماموریت = new DataColumn("ماموریت", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnماموریت);

                columnفوق_العاده_ماموریت = new DataColumn("فوق العاده ماموریت", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnفوق_العاده_ماموریت);

                columnفوق_العاده_سرپرستی = new DataColumn("فوق العاده سرپرستی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnفوق_العاده_سرپرستی);

                columnکارانه = new DataColumn("کارانه", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارانه);

                columnکارانه_ثابت = new DataColumn("کارانه ثابت", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارانه_ثابت);

                columnکارانه_ثابت2 = new DataColumn("کارانه ثابت2", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارانه_ثابت2);

                columnسایر_مزایا = new DataColumn("سایر مزایا", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnسایر_مزایا);

                columnمزایای_معوقه = new DataColumn("مزایای معوقه", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnمزایای_معوقه);

                columnکارانه_معوق = new DataColumn("کارانه معوق", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارانه_معوق);

                columnفوق_العاده_شغل = new DataColumn("فوق العاده شغل", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnفوق_العاده_شغل);

                columnپاداش_پرسنل = new DataColumn("پاداش پرسنل", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnپاداش_پرسنل);

                columnایاب_و_ذهاب = new DataColumn("ایاب و ذهاب", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnایاب_و_ذهاب);

                columnمعوقه_حقوق = new DataColumn("معوقه حقوق", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnمعوقه_حقوق);

                columnبن_رمضان = new DataColumn("بن رمضان", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnبن_رمضان);

                columnهزینه_جارو = new DataColumn("هزینه جارو", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnهزینه_جارو);

                columnپایه_سنوات_معوق = new DataColumn("پایه سنوات معوق", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnپایه_سنوات_معوق);

                columnسایر_مزایای_استیجاری = new DataColumn("سایر مزایای استیجاری", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnسایر_مزایای_استیجاری);

                columnبدهکاران_کارکنان = new DataColumn("بدهکاران کارکنان", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnبدهکاران_کارکنان);

                columnبیمه_تامین_اجتماعی_سهم_کارگر = new DataColumn("بیمه تامین اجتماعی سهم کارگر", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnبیمه_تامین_اجتماعی_سهم_کارگر);

                columnبیمه_تکمیلی_سهم_کارمند = new DataColumn("بیمه تکمیلی سهم کارمند", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnبیمه_تکمیلی_سهم_کارمند);

                columnسایر_کسور = new DataColumn("سایر کسور", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnسایر_کسور);

                columnخسارت_کارکنان = new DataColumn("خسارت کارکنان", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnخسارت_کارکنان);

                columnکارکنان_بدهکار = new DataColumn("کارکنان بدهکار", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارکنان_بدهکار);

                columnمساعده = new DataColumn("مساعده", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnمساعده);

                columnتعهدات_دولتی_کارمند = new DataColumn("تعهدات دولتی کارمند", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnتعهدات_دولتی_کارمند);

                columnجمع_اقساط_وام = new DataColumn("جمع اقساط وام", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnجمع_اقساط_وام);

                columnتعاونی_مصرف_کارکنان = new DataColumn("تعاونی مصرف کارکنان", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnتعاونی_مصرف_کارکنان);

                columnمالیات_حقوق = new DataColumn("مالیات حقوق", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnمالیات_حقوق);

                columnجمع_مزایا = new DataColumn("جمع مزایا", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnجمع_مزایا);

                columnجمع_کسور = new DataColumn("جمع کسور", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnجمع_کسور);

                columnخالص_پرداختی = new DataColumn("خالص پرداختی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnخالص_پرداختی);

                columnشماره_حساب = new DataColumn("شماره حساب", typeof(string), null, MappingType.Element);
                Columns.Add(columnشماره_حساب);

                columnنام = new DataColumn("نام", typeof(string), null, MappingType.Element);
                Columns.Add(columnنام);

                columnنام_خانوادگی = new DataColumn("نام خانوادگی", typeof(string), null, MappingType.Element);
                Columns.Add(columnنام_خانوادگی);

                columnکد_پرسنلی = new DataColumn("کد پرسنلی", typeof(string), null, MappingType.Element);
                Columns.Add(columnکد_پرسنلی);

                columnنام_پدر = new DataColumn("نام پدر", typeof(string), null, MappingType.Element);
                Columns.Add(columnنام_پدر);

                columnکد_ملی = new DataColumn("کد ملی", typeof(string), null, MappingType.Element);
                Columns.Add(columnکد_ملی);

                columnشماره_شناسنامه = new DataColumn("شماره شناسنامه", typeof(string), null, MappingType.Element);
                Columns.Add(columnشماره_شناسنامه);

                columnتاریخ_تولد = new DataColumn("تاریخ تولد", typeof(DateTime), null, MappingType.Element);
                Columns.Add(columnتاریخ_تولد);

                columnنام_شعبه = new DataColumn("نام شعبه", typeof(string), null, MappingType.Element);
                Columns.Add(columnنام_شعبه);

                columnسال = new DataColumn("سال", typeof(string), null, MappingType.Element);
                Columns.Add(columnسال);

                columnماه = new DataColumn("ماه", typeof(string), null, MappingType.Element);
                Columns.Add(columnماه);

                columnشماره_بیمه = new DataColumn("شماره بیمه", typeof(string), null, MappingType.Element);
                Columns.Add(columnشماره_بیمه);

                columnکارکرد_موثر = new DataColumn("کارکرد موثر", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارکرد_موثر);

                columnپاداش = new DataColumn("پاداش", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnپاداش);

                columnتعداد_اولاد = new DataColumn("تعداد اولاد", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnتعداد_اولاد);

                columnمالیات = new DataColumn("مالیات", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnمالیات);

                columnبیمه_تامین_اجتماعی_سهم_کارمند = new DataColumn("بیمه تامین اجتماعی سهم کارمند", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnبیمه_تامین_اجتماعی_سهم_کارمند);

                columnدستمزد_روزانه = new DataColumn("دستمزد روزانه", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnدستمزد_روزانه);

                columnفوق_العاده_جذب = new DataColumn("فوق العاده جذب", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnفوق_العاده_جذب);

                columnفوق_العاده_کارایی = new DataColumn("فوق العاده کارایی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnفوق_العاده_کارایی);

                columnمعوقه_دستی = new DataColumn("معوقه دستی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnمعوقه_دستی);

                columnبیمه_تامین_اجتماعی_سهم_کارفرما = new DataColumn("بیمه تامین اجتماعی سهم کارفرما", typeof(string), null, MappingType.Element);
                Columns.Add(columnبیمه_تامین_اجتماعی_سهم_کارفرما);

                columnبیمه_بیکاری = new DataColumn("بیمه بیکاری", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnبیمه_بیکاری);

                columnبیمه_تکمیلی_سهم_کارفرما = new DataColumn("بیمه تکمیلی سهم کارفرما", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnبیمه_تکمیلی_سهم_کارفرما);

                columnمعوقه_دستی_با_مالیات = new DataColumn("معوقه دستی با مالیات", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnمعوقه_دستی_با_مالیات);

                columnفوق_العاده_خلاقیت = new DataColumn("فوق العاده خلاقیت", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnفوق_العاده_خلاقیت);

                columnفوق_العاده_پست = new DataColumn("فوق العاده پست", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnفوق_العاده_پست);

                columnحق_ایاب_و_ذهاب = new DataColumn("حق ایاب و ذهاب", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحق_ایاب_و_ذهاب);

                columnفوق_العاده_منزلت_شغلی = new DataColumn("فوق العاده منزلت شغلی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnفوق_العاده_منزلت_شغلی);

                columnماموریت_عادی = new DataColumn("ماموریت عادی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnماموریت_عادی);

                columnماموریت_روز_تعلیل = new DataColumn("ماموریت روز تعلیل", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnماموریت_روز_تعلیل);

                columnماموریت_حومه = new DataColumn("ماموریت حومه", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnماموریت_حومه);

                columnحق_غذای_ماموریت_حومه = new DataColumn("حق غذای ماموریت حومه", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحق_غذای_ماموریت_حومه);

                columnاحضار_به_کار_پایین_تر_از_5_س = new DataColumn("احضار به کار پایین تر از 5 س", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnاحضار_به_کار_پایین_تر_از_5_س);

                columnاحضار_به_کار_بین_5_تا_10_س = new DataColumn("احضار به کار بین 5 تا 10 س", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnاحضار_به_کار_بین_5_تا_10_س);

                columnاحضار_به_کار_بالاتر_از_10_س = new DataColumn("احضار به کار بالاتر از 10 س", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnاحضار_به_کار_بالاتر_از_10_س);

                columnهزینه_موبایل = new DataColumn("هزینه موبایل", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnهزینه_موبایل);

                columnکسر_کار = new DataColumn("کسر کار", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکسر_کار);

                columnحقوق_گروه_مشاور = new DataColumn("حقوق گروه مشاور", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحقوق_گروه_مشاور);

                columnحقوق_گروه_ساعتی = new DataColumn("حقوق گروه ساعتی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحقوق_گروه_ساعتی);

                columnغیبت_ماهانه = new DataColumn("غیبت ماهانه", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnغیبت_ماهانه);

                columnاحضار_به_کار_پایین_تر_از_5س = new DataColumn("احضار به کار پایین تر از 5س", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnاحضار_به_کار_پایین_تر_از_5س);

                columnاحضار_به_کار_بین_5_تا_10س = new DataColumn("احضار به کار بین 5 تا 10س", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnاحضار_به_کار_بین_5_تا_10س);

                columnسایر2 = new DataColumn("سایر2", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnسایر2);

                columnروند_حقوق = new DataColumn("روند حقوق", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnروند_حقوق);

                columnکارکرد_شب_کاری = new DataColumn("کارکرد شب کاری", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارکرد_شب_کاری);

                columnسایر3 = new DataColumn("سایر3", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnسایر3);

                columnسایر1 = new DataColumn("سایر1", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnسایر1);

                columnنوبت_کاری_10 = new DataColumn("نوبت کاری 10", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnنوبت_کاری_10);

                columnماموریت_عادی_نهایی = new DataColumn("ماموریت عادی نهایی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnماموریت_عادی_نهایی);

                columnماموریت_تعلیل_نهایی = new DataColumn("ماموریت تعلیل نهایی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnماموریت_تعلیل_نهایی);

                columnکارکرد_ماموریت_حومه_نهایی = new DataColumn("کارکرد ماموریت حومه نهایی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارکرد_ماموریت_حومه_نهایی);

                columnفوق_العاده_در_دسترسی_نهایی = new DataColumn("فوق العاده در دسترسی نهایی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnفوق_العاده_در_دسترسی_نهایی);

                columnبیمه_تکمیلی_سازمانی_کارمند = new DataColumn("بیمه تکمیلی سازمانی کارمند", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnبیمه_تکمیلی_سازمانی_کارمند);

                columnتعطیل_کاری_دستور_کار = new DataColumn("تعطیل کاری دستور کار", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnتعطیل_کاری_دستور_کار);

                columnکارانه_2 = new DataColumn("کارانه 2", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnکارانه_2);

                columnحق_ناهار = new DataColumn("حق ناهار", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnحق_ناهار);

                columnخالص_حقوق = new DataColumn("خالص حقوق", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnخالص_حقوق);

                columnگروه_شغلی = new DataColumn("گروه شغلی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnگروه_شغلی);

                columnمزد_ماهانه = new DataColumn("مزد ماهانه", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnمزد_ماهانه);

                columnNightWorking = new DataColumn("NightWorking", typeof(decimal),null, MappingType.Element);
                Columns.Add(columnNightWorking);

                columnHolidayWorking = new DataColumn("HolidayWorking", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnHolidayWorking);

                columnبیمه_تکمیلی = new DataColumn("بیمه تکمیلی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnبیمه_تکمیلی);

                columnقسط_وام_مسکن = new DataColumn("قسط وام مسکن", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnقسط_وام_مسکن);

                columnمزد_روزانه = new DataColumn("مزد روزانه", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnمزد_روزانه);

                columnتعهدات_دولتی = new DataColumn("تعهدات دولتی", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnتعهدات_دولتی);

                columnدستمزد_ماهانه = new DataColumn("دستمزد ماهانه", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnدستمزد_ماهانه);

                columnقابل_پرداخت = new DataColumn("قابل پرداخت", typeof(decimal), null, MappingType.Element);
                Columns.Add(columnقابل_پرداخت);

                columnکد_پرسنلی.AllowDBNull = false;
                columnکد_پرسنلی.MaxLength = 100;
                columnنام.MaxLength = 50;
                columnنام_خانوادگی.MaxLength = 50;
                columnنام_پدر.MaxLength = 50;
                columnکد_ملی.MaxLength = 20;
                columnشماره_شناسنامه.MaxLength = 20;
                columnنام_شعبه.MaxLength = 0x80;
                columnشماره_حساب.MaxLength = 50;
                columnسال.ReadOnly = true;
                columnسال.MaxLength = 4;
                columnماه.ReadOnly = true;
                columnماه.MaxLength = 2;
                columnشماره_بیمه.MaxLength = 200;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            internal void InitVars()
            {
                columnکارکرد_عادی = Columns["کارکرد عادی"];
                columnکارکرد_اضافه_کاری = Columns["کارکرد اضافه کاری"];
                columnکارکرد_تعطیل_کاری = Columns["کارکرد تعطیل کاری"];
                columnجمعه_کاری = Columns["جمعه کاری"];
                columnکارکرد_شبکاری = Columns["کارکرد شبکاری"];
                columnکارکرد_شب_کاری_1 = Columns["کارکرد شب کاری 1"];
                columnکارکرد_مرخصی_استحقاقی = Columns["کارکرد مرخصی استحقاقی"];
                columnکارکرد_کارانه = Columns["کارکرد کارانه"];
                columnکارکرد_کارانه2 = Columns["کارکرد کارانه2"];
                columnکارکرد_ساعتی = Columns["کارکرد ساعتی"];
                columnپایه_سنوات = Columns["پایه سنوات"];
                columnحقوق_پایه = Columns["حقوق پایه"];
                columnحق_اولاد = Columns["حق اولاد"];
                columnحق_اولاد_معوق = Columns["حق اولاد معوق"];
                columnحق_مسکن = Columns["حق مسکن"];
                columnبن_کارگری = Columns["بن کارگری"];
                columnحق_خواربار = Columns["حق خواربار"];
                columnاضافه_کاری = Columns["اضافه کاری"];
                columnتعطیل_کاری = Columns["تعطیل کاری"];
                columnشبکاری = Columns["شب کاری"];
                columnحق_شیر = Columns["حق شیر"];
                columnشیفت = Columns["شیفت"];
                columnشیفت_ساعتی = Columns["شیفت ساعتی"];
                columnمبلغ_تناژ = Columns["مبلغ تناژ"];
                columnتنخواه = Columns["تنخواه"];
                columnحق_سوخت = Columns["حق سوخت"];
                columnماموریت = Columns["ماموریت"];
                columnفوق_العاده_ماموریت = Columns["فوق العاده ماموریت"];
                columnفوق_العاده_سرپرستی = Columns["فوق العاده سرپرستی"];
                columnکارانه = Columns["کارانه"];
                columnکارانه_ثابت = Columns["کارانه ثابت"];
                columnکارانه_ثابت2 = Columns["کارانه ثابت2"];
                columnسایر_مزایا = Columns["سایر مزایا"];
                columnمزایای_معوقه = Columns["مزایای معوقه"];
                columnکارانه_معوق = Columns["کارانه معوق"];
                columnفوق_العاده_شغل = Columns["فوق العاده شغل"];
                columnپاداش_پرسنل = Columns["پاداش پرسنل"];
                columnایاب_و_ذهاب = Columns["ایاب و ذهاب"];
                columnمعوقه_حقوق = Columns["معوقه حقوق"];
                columnبن_رمضان = Columns["بن رمضان"];
                columnهزینه_جارو = Columns["هزینه جارو"];
                columnپایه_سنوات_معوق = Columns["پایه سنوات معوق"];
                columnسایر_مزایای_استیجاری = Columns["سایر مزایای استیجاری"];
                columnبدهکاران_کارکنان = Columns["بدهکاران کارکنان"];
                columnبیمه_تامین_اجتماعی_سهم_کارگر = Columns["بیمه تامین اجتماعی سهم کارگر"];
                columnبیمه_تکمیلی_سهم_کارمند = Columns["بیمه تکمیلی سهم کارمند"];
                columnسایر_کسور = Columns["سایر کسور"];
                columnخسارت_کارکنان = Columns["خسارت کارکنان"];
                columnکارکنان_بدهکار = Columns["کارکنان بدهکار"];
                columnمساعده = Columns["مساعده"];
                columnتعهدات_دولتی_کارمند = Columns["تعهدات دولتی کارمند"];
                columnجمع_اقساط_وام = Columns["جمع اقساط وام"];
                columnتعاونی_مصرف_کارکنان = Columns["تعاونی مصرف کارکنان"];
                columnمالیات_حقوق = Columns["مالیات حقوق"];
                columnجمع_مزایا = Columns["جمع مزایا"];
                columnجمع_کسور = Columns["جمع کسور"];
                columnخالص_پرداختی = Columns["خالص پرداختی"];
                columnشماره_حساب = Columns["شماره حساب"];
                columnنام = Columns["نام"];
                columnنام_خانوادگی = Columns["نام خانوادگی"];
                columnکد_پرسنلی = Columns["کد پرسنلی"];
                columnنام_پدر = Columns["نام پدر"];
                columnکد_ملی = Columns["کد ملی"];
                columnشماره_شناسنامه = Columns["شماره شناسنامه"];
                columnتاریخ_تولد = Columns["تاریخ تولد"];
                columnنام_شعبه = Columns["نام شعبه"];
                columnسال = Columns["سال"];
                columnماه = Columns["ماه"];
                columnشماره_بیمه = Columns["شماره بیمه"];
                columnکارکرد_موثر = Columns["کارکرد موثر"];
                columnپاداش = Columns["پاداش"];
                columnتعداد_اولاد = Columns["تعداد اولاد"];
                columnمالیات = Columns["مالیات"];
                columnبیمه_تامین_اجتماعی_سهم_کارمند = Columns["بیمه تامین اجتماعی سهم کارمند"];
                columnدستمزد_روزانه = Columns["دستمزد روزانه"];
                columnفوق_العاده_جذب = Columns["فوق العاده جذب"];
                columnفوق_العاده_کارایی = Columns["فوق العاده کارایی"];
                columnمعوقه_دستی = Columns["معوقه دستی"];
                columnبیمه_تامین_اجتماعی_سهم_کارفرما = Columns["بیمه تامین اجتماعی سهم کارفرما"];
                columnبیمه_بیکاری = Columns["بیمه بیکاری"];
                columnبیمه_تکمیلی_سهم_کارفرما = Columns["بیمه تکمیلی سهم کارفرما"];
                columnمعوقه_دستی_با_مالیات = Columns["معوقه دستی با مالیات"];
                columnفوق_العاده_خلاقیت = Columns["فوق العاده خلاقیت"];
                columnفوق_العاده_پست = Columns["فوق العاده پست"];
                columnحق_ایاب_و_ذهاب = Columns["حق ایاب و ذهاب"];
                columnفوق_العاده_منزلت_شغلی = Columns["فوق العاده منزلت شغلی"];
                columnماموریت_عادی = Columns["ماموریت عادی"];
                columnماموریت_روز_تعلیل = Columns["ماموریت روز تعلیل"];
                columnماموریت_حومه = Columns["ماموریت حومه"];
                columnحق_غذای_ماموریت_حومه = Columns["حق غذای ماموریت حومه"];
                columnاحضار_به_کار_پایین_تر_از_5_س = Columns["احضار به کار پایین تر از 5 س"];
                columnاحضار_به_کار_بین_5_تا_10_س = Columns["احضار به کار بین 5 تا 10 س"];
                columnاحضار_به_کار_بالاتر_از_10_س = Columns["احضار به کار بالاتر از 10 س"];
                columnهزینه_موبایل = Columns["هزینه موبایل"];
                columnکسر_کار = Columns["کسر کار"];
                columnحقوق_گروه_مشاور = Columns["حقوق گروه مشاور"];
                columnحقوق_گروه_ساعتی = Columns["حقوق گروه ساعتی"];
                columnغیبت_ماهانه = Columns["غیبت ماهانه"];
                columnاحضار_به_کار_پایین_تر_از_5س = Columns["احضار به کار پایین تر از 5س"];
                columnاحضار_به_کار_بین_5_تا_10س = Columns["احضار به کار بین 5 تا 10س"];
                columnسایر2 = Columns["سایر2"];
                columnروند_حقوق = Columns["روند حقوق"];
                columnکارکرد_شب_کاری = Columns["کارکرد شب کاری"];
                columnسایر3 = Columns["سایر3"];
                columnسایر1 = Columns["سایر1"];
                columnنوبت_کاری_10 = Columns["نوبت کاری 10"];
                columnماموریت_عادی_نهایی = Columns["ماموریت عادی نهایی"];
                columnماموریت_تعلیل_نهایی = Columns["ماموریت تعلیل نهایی"];
                columnکارکرد_ماموریت_حومه_نهایی = Columns["کارکرد ماموریت حومه نهایی"];
                columnفوق_العاده_در_دسترسی_نهایی = Columns["فوق العاده در دسترسی نهایی"];
                columnبیمه_تکمیلی_سازمانی_کارمند = Columns["بیمه تکمیلی سازمانی کارمند"];
                columnتعطیل_کاری_دستور_کار = Columns["تعطیل کاری دستور کار"];
                columnکارانه_2 = Columns["کارانه 2"];
                columnحق_ناهار = Columns["حق ناهار"];
                columnخالص_حقوق = Columns["خالص حقوق"];
                columnگروه_شغلی = Columns["گروه شغلی"];
                columnمزد_ماهانه = Columns["مزد ماهانه"];
                columnNightWorking = Columns["NightWorking"];
                columnکارکرد_تعطیل_کاری_روز = Columns["کارکرد تعطیل کاری روز"];
                columnبیمه_تکمیلی = Columns["بیمه تکمیلی"];
                columnقسط_وام_مسکن = Columns["قسط وام مسکن"];
                columnمزد_روزانه = Columns["مزد روزانه"];
                columnتعهدات_دولتی = Columns["تعهدات دولتی"];
                columnدستمزد_ماهانه = Columns["دستمزد ماهانه"];
                columnقابل_پرداخت = Columns["قابل پرداخت"];


            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public MKView_FishHamkaranRow NewMKView_FishHamkaranRow() =>
                (MKView_FishHamkaranRow)NewRow();

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) =>
                new MKView_FishHamkaranRow(builder);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (MKView_FishHamkaranRowChanged != null)
                {
                    MKView_FishHamkaranRowChanged(this, new MKView_FishHamkaranRowChangeEvent((MKView_FishHamkaranRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (MKView_FishHamkaranRowChanging != null)
                {
                    MKView_FishHamkaranRowChanging(this, new MKView_FishHamkaranRowChangeEvent((MKView_FishHamkaranRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (MKView_FishHamkaranRowDeleted != null)
                {
                    MKView_FishHamkaranRowDeleted(this, new MKView_FishHamkaranRowChangeEvent((MKView_FishHamkaranRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (MKView_FishHamkaranRowDeleting != null)
                {
                    MKView_FishHamkaranRowDeleting(this, new MKView_FishHamkaranRowChangeEvent((MKView_FishHamkaranRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void RemoveMKView_FishHamkaranRow(MKView_FishHamkaranRow row)
            {
                Rows.Remove(row);
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارکرد_عادیColumn => columnکارکرد_عادی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارکرد_اضافه_کاریColumn => columnکارکرد_اضافه_کاری;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارکرد_تعطیل_کاریColumn => columnکارکرد_تعطیل_کاری;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn جمعه_کاریColumn => columnجمعه_کاری;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارکرد_شبکاریColumn => columnکارکرد_شبکاری;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارکرد_شب_کاری_1Column => columnکارکرد_شب_کاری_1;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارکرد_مرخصی_استحقاقیColumn => columnکارکرد_مرخصی_استحقاقی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارکرد_کارانهColumn => columnکارکرد_کارانه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارکرد_کارانه2Column => columnکارکرد_کارانه2;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارکرد_ساعتیColumn => columnکارکرد_ساعتی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn پایه_سنواتColumn => columnپایه_سنوات;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حقوق_پایهColumn => columnحقوق_پایه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حق_اولادColumn => columnحق_اولاد;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حق_اولاد_معوقColumn => columnحق_اولاد_معوق;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حق_مسکنColumn => columnحق_مسکن;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn بن_کارگریColumn => columnبن_کارگری;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حق_خواربارColumn => columnحق_خواربار;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn اضافه_کاریColumn => columnاضافه_کاری;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn تعطیل_کاریColumn => columnتعطیل_کاری;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn شب_کاریColumn => columnشبکاری;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حق_شیرColumn => columnحق_شیر;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn شیفتColumn => columnشیفت;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn شیفت_ساعتیColumn => columnشیفت_ساعتی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn مبلغ_تناژColumn => columnمبلغ_تناژ;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn تنخواهColumn => columnتنخواه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حق_سوختColumn => columnحق_سوخت;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn ماموریتColumn => columnماموریت;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn فوق_العاده_ماموریتColumn => columnفوق_العاده_ماموریت;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn فوق_العاده_سرپرستیColumn => columnفوق_العاده_سرپرستی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارانهColumn => columnکارانه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارانه_ثابتColumn => columnکارانه_ثابت;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارانه_ثابت2Column => columnکارانه_ثابت2;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn سایر_مزایاColumn => columnسایر_مزایا;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn مزایای_معوقهColumn => columnمزایای_معوقه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارانه_معوقColumn => columnکارانه_معوق;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn فوق_العاده_شغلColumn => columnفوق_العاده_شغل;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn پاداش_پرسنلColumn => columnپاداش_پرسنل;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn ایاب_و_ذهابColumn => columnایاب_و_ذهاب;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn معوقه_حقوقColumn => columnمعوقه_حقوق;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn بن_رمضانColumn => columnبن_رمضان;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn هزینه_جاروColumn => columnهزینه_جارو;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn پایه_سنوات_معوقColumn => columnپایه_سنوات_معوق;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn سایر_مزایای_استیجاریColumn => columnسایر_مزایای_استیجاری;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn بدهکاران_کارکنانColumn => columnبدهکاران_کارکنان;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn بیمه_تامین_اجتماعی_سهم_کارگرColumn => columnبیمه_تامین_اجتماعی_سهم_کارگر;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn بیمه_تکمیلی_سهم_کارمندColumn => columnبیمه_تکمیلی_سهم_کارمند;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn سایر_کسورColumn => columnسایر_کسور;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn خسارت_کارکنانColumn => columnخسارت_کارکنان;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارکنان_بدهکارColumn => columnکارکنان_بدهکار;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn مساعدهColumn => columnمساعده;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn تعهدات_دولتی_کارمندColumn => columnتعهدات_دولتی_کارمند;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn جمع_اقساط_وامColumn => columnجمع_اقساط_وام;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn تعاونی_مصرف_کارکنانColumn => columnتعاونی_مصرف_کارکنان;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn مالیات_حقوقColumn => columnمالیات_حقوق;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn جمع_مزایاColumn => columnجمع_مزایا;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn جمع_کسورColumn => columnجمع_کسور;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn خالص_پرداختیColumn => columnخالص_پرداختی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn شماره_حسابColumn => columnشماره_حساب;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn نامColumn => columnنام;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn نام_خانوادگیColumn => columnنام_خانوادگی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کد_پرسنلیColumn => columnکد_پرسنلی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn نام_پدرColumn => columnنام_پدر;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کد_ملیColumn => columnکد_ملی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn شماره_شناسنامهColumn => columnشماره_شناسنامه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn تاریخ_تولدColumn => columnتاریخ_تولد;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn نام_شعبهColumn => columnنام_شعبه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn سالColumn => columnسال;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn ماهColumn => columnماه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn شماره_بیمهColumn => columnشماره_بیمه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارکرد_موثرColumn => columnکارکرد_موثر;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn پاداشColumn => columnپاداش;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn تعداد_اولادColumn => columnتعداد_اولاد;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn مالیاتColumn => columnمالیات;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn بیمه_تامین_اجتماعی_سهم_کارمندColumn => columnبیمه_تامین_اجتماعی_سهم_کارمند;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn دستمزد_روزانهColumn => columnدستمزد_روزانه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn فوق_العاده_جذبColumn => columnفوق_العاده_جذب;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn فوق_العاده_کاراییColumn => columnفوق_العاده_کارایی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn معوقه_دستیColumn => columnمعوقه_دستی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn بیمه_تامین_اجتماعی_سهم_کارفرماColumn => columnبیمه_تامین_اجتماعی_سهم_کارفرما;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn بیمه_بیکاریColumn => columnبیمه_بیکاری;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn بیمه_تکمیلی_سهم_کارفرماColumn => columnبیمه_تکمیلی_سهم_کارفرما;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn معوقه_دستی_با_مالیاتColumn => columnمعوقه_دستی_با_مالیات;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn فوق_العاده_خلاقیتColumn => columnفوق_العاده_خلاقیت;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn فوق_العاده_پستColumn => columnفوق_العاده_پست;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حق_ایاب_و_ذهابColumn => columnحق_ایاب_و_ذهاب;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn فوق_العاده_منزلت_شغلیColumn => columnفوق_العاده_منزلت_شغلی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn ماموریت_عادیColumn => columnماموریت_عادی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn ماموریت_روز_تعلیلColumn => columnماموریت_روز_تعلیل;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn ماموریت_حومهColumn => columnماموریت_حومه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حق_غذای_ماموریت_حومهColumn => columnحق_غذای_ماموریت_حومه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn احضار_به_کار_پایین_تر_از_5_سColumn => columnاحضار_به_کار_پایین_تر_از_5_س;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn احضار_به_کار_بین_5_تا_10_سColumn => columnاحضار_به_کار_بین_5_تا_10_س;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn احضار_به_کار_بالاتر_از_10_سColumn => columnاحضار_به_کار_بالاتر_از_10_س;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn هزینه_موبایلColumn => columnهزینه_موبایل;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کسر_کارColumn => columnکسر_کار;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حقوق_گروه_مشاورColumn => columnحقوق_گروه_مشاور;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حقوق_گروه_ساعتیColumn => columnحقوق_گروه_ساعتی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn غیبت_ماهانهColumn => columnغیبت_ماهانه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn احضار_به_کار_پایین_تر_از_5سColumn => columnاحضار_به_کار_پایین_تر_از_5س;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn احضار_به_کار_بین_5_تا_10سColumn => columnاحضار_به_کار_بین_5_تا_10س;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn سایر2Column => columnسایر2;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn روند_حقوقColumn => columnروند_حقوق;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارکرد_شب_کاریColumn => columnکارکرد_شب_کاری;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn سایر3Column => columnسایر3;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn سایر1Column => columnسایر1;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn نوبت_کاری_10Column => columnنوبت_کاری_10;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn ماموریت_عادی_نهاییColumn => columnماموریت_عادی_نهایی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn ماموریت_تعلیل_نهاییColumn => columnماموریت_تعلیل_نهایی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارکرد_ماموریت_حومه_نهاییColumn => columnکارکرد_ماموریت_حومه_نهایی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn فوق_العاده_در_دسترسی_نهاییColumn => columnفوق_العاده_در_دسترسی_نهایی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn بیمه_تکمیلی_سازمانی_کارمندColumn => columnبیمه_تکمیلی_سازمانی_کارمند;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn تعطیل_کاری_دستور_کارColumn => columnتعطیل_کاری_دستور_کار;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn کارانه_2Column => columnکارانه_2;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn حق_ناهارColumn => columnحق_ناهار;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn خالص_حقوقColumn => columnخالص_حقوق;
            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn گروه_شغلیColumn => columnگروه_شغلی;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn مزد_ماهانهColumn => columnمزد_ماهانه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn NightWorkingColumn => columnNightWorking;


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn HolydayWorkingColumn => columnHolidayWorking;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn بیمه_تکمیلیColumn => columnبیمه_تکمیلی;


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn قسط_وام_مسکنColumn => columnقسط_وام_مسکن;


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn مزد_روزانه_Column => columnمزد_روزانه;


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn تعهدات_دولتیColumn => columnتعهدات_دولتی;


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn دستمزد_ماهانهColumn => columnدستمزد_ماهانه;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataColumn قابل_پرداختColumn => columnقابل_پرداخت;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), Browsable(false)]
            public int Count =>
                Rows.Count;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public MKView_FishHamkaranRow this[int index] =>
                (MKView_FishHamkaranRow)Rows[index];
        }

        public class MKView_FishHamkaranRow : DataRow
        {
            private MKView_FishHamkaranDataTable tableMKView_FishHamkaran;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            internal MKView_FishHamkaranRow(DataRowBuilder rb) : base(rb)
            {
                tableMKView_FishHamkaran = (MKView_FishHamkaranDataTable)Table;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکرد_عادی__Null() => IsNull(tableMKView_FishHamkaran.کارکرد_عادیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکرد_اضافه_کاری__Null() => IsNull(tableMKView_FishHamkaran.کارکرد_اضافه_کاریColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکرد_تعطیل_کاری__Null() => IsNull(tableMKView_FishHamkaran.کارکرد_تعطیل_کاریColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_جمعه_کاری__Null() => IsNull(tableMKView_FishHamkaran.جمعه_کاریColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکرد_شبکاری__Null() => IsNull(tableMKView_FishHamkaran.کارکرد_شبکاریColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکرد_شب_کاری_1__Null() => IsNull(tableMKView_FishHamkaran.کارکرد_شب_کاری_1Column);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکرد_مرخصی_استحقاقی__Null() => IsNull(tableMKView_FishHamkaran.کارکرد_مرخصی_استحقاقیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکرد_کارانه__Null() => IsNull(tableMKView_FishHamkaran.کارکرد_کارانهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکرد_کارانه2__Null() => IsNull(tableMKView_FishHamkaran.کارکرد_کارانه2Column);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکرد_ساعتی__Null() => IsNull(tableMKView_FishHamkaran.کارکرد_ساعتیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_پایه_سنوات__Null() => IsNull(tableMKView_FishHamkaran.پایه_سنواتColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_حقوق_پایه__Null() => IsNull(tableMKView_FishHamkaran.حقوق_پایهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_حق_اولاد__Null() => IsNull(tableMKView_FishHamkaran.حق_اولادColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_حق_اولاد_معوق__Null() => IsNull(tableMKView_FishHamkaran.حق_اولاد_معوقColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_حق_مسکن__Null() => IsNull(tableMKView_FishHamkaran.حق_مسکنColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_بن_کارگری__Null() => IsNull(tableMKView_FishHamkaran.بن_کارگریColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_حق_خواربار__Null() => IsNull(tableMKView_FishHamkaran.حق_خواربارColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_اضافه_کاری__Null() => IsNull(tableMKView_FishHamkaran.اضافه_کاریColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_تعطیل_کاری__Null() => IsNull(tableMKView_FishHamkaran.تعطیل_کاریColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_شب_کاری__Null() => IsNull(tableMKView_FishHamkaran.شب_کاریColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_حق_شیر__Null() => IsNull(tableMKView_FishHamkaran.حق_شیرColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_شیفت__Null() => IsNull(tableMKView_FishHamkaran.شیفتColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_شیفت_ساعتی__Null() => IsNull(tableMKView_FishHamkaran.شیفت_ساعتیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_مبلغ_تناژ__Null() => IsNull(tableMKView_FishHamkaran.مبلغ_تناژColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_تنخواه__Null() => IsNull(tableMKView_FishHamkaran.تنخواهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_حق_سوخت__Null() => IsNull(tableMKView_FishHamkaran.حق_سوختColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_ماموریت__Null() => IsNull(tableMKView_FishHamkaran.ماموریتColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_فوق_العاده_ماموریت__Null() => IsNull(tableMKView_FishHamkaran.فوق_العاده_ماموریتColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_فوق_العاده_سرپرستی__Null() => IsNull(tableMKView_FishHamkaran.فوق_العاده_سرپرستیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارانه__Null() => IsNull(tableMKView_FishHamkaran.کارانهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارانه_ثابت__Null() => IsNull(tableMKView_FishHamkaran.کارانه_ثابتColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارانه_ثابت2__Null() => IsNull(tableMKView_FishHamkaran.کارانه_ثابت2Column);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_سایر_مزایا__Null() => IsNull(tableMKView_FishHamkaran.سایر_مزایاColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_مزایای_معوقه__Null() => IsNull(tableMKView_FishHamkaran.مزایای_معوقهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارانه_معوق__Null() => IsNull(tableMKView_FishHamkaran.کارانه_معوقColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_فوق_العاده_شغل__Null() => IsNull(tableMKView_FishHamkaran.فوق_العاده_شغلColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_پاداش_پرسنل__Null() => IsNull(tableMKView_FishHamkaran.پاداش_پرسنلColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_ایاب_و_ذهاب__Null() => IsNull(tableMKView_FishHamkaran.ایاب_و_ذهابColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_معوقه_حقوق__Null() => IsNull(tableMKView_FishHamkaran.معوقه_حقوقColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_بن_رمضان__Null() => IsNull(tableMKView_FishHamkaran.بن_رمضانColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_هزینه_جارو__Null() => IsNull(tableMKView_FishHamkaran.هزینه_جاروColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_پایه_سنوات_معوق__Null() => IsNull(tableMKView_FishHamkaran.پایه_سنوات_معوقColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_سایر_مزایای_استیجاری__Null() => IsNull(tableMKView_FishHamkaran.سایر_مزایای_استیجاریColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_بدهکاران_کارکنان__Null() => IsNull(tableMKView_FishHamkaran.بدهکاران_کارکنانColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_بیمه_تامین_اجتماعی_سهم_کارگر__Null() => IsNull(tableMKView_FishHamkaran.بیمه_تامین_اجتماعی_سهم_کارگرColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_بیمه_تکمیلی_سهم_کارمند__Null() => IsNull(tableMKView_FishHamkaran.بیمه_تکمیلی_سهم_کارمندColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_سایر_کسور__Null() => IsNull(tableMKView_FishHamkaran.سایر_کسورColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_خسارت_کارکنان__Null() => IsNull(tableMKView_FishHamkaran.خسارت_کارکنانColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکنان_بدهکار__Null() => IsNull(tableMKView_FishHamkaran.کارکنان_بدهکارColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_مساعده__Null() => IsNull(tableMKView_FishHamkaran.مساعدهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_تعهدات_دولتی_کارمند__Null() => IsNull(tableMKView_FishHamkaran.تعهدات_دولتی_کارمندColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_جمع_اقساط_وام__Null() => IsNull(tableMKView_FishHamkaran.جمع_اقساط_وامColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_تعاونی_مصرف_کارکنان__Null() => IsNull(tableMKView_FishHamkaran.تعاونی_مصرف_کارکنانColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_مالیات_حقوق__Null() => IsNull(tableMKView_FishHamkaran.مالیات_حقوقColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_جمع_مزایا__Null() => IsNull(tableMKView_FishHamkaran.جمع_مزایاColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_جمع_کسور__Null() => IsNull(tableMKView_FishHamkaran.جمع_کسورColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_خالص_پرداختی__Null() => IsNull(tableMKView_FishHamkaran.خالص_پرداختیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_شماره_حساب__Null() => IsNull(tableMKView_FishHamkaran.شماره_حسابColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_نام__Null() => IsNull(tableMKView_FishHamkaran.نامColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_نام_خانوادگی__Null() => IsNull(tableMKView_FishHamkaran.نام_خانوادگیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کد_پرسنلی__Null() => IsNull(tableMKView_FishHamkaran.کد_پرسنلیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_نام_پدر__Null() => IsNull(tableMKView_FishHamkaran.نام_پدرColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کد_ملی__Null() => IsNull(tableMKView_FishHamkaran.کد_ملیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_شماره_شناسنامه__Null() => IsNull(tableMKView_FishHamkaran.شماره_شناسنامهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_تاریخ_تولد__Null() => IsNull(tableMKView_FishHamkaran.تاریخ_تولدColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_نام_شعبه__Null() => IsNull(tableMKView_FishHamkaran.نام_شعبهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_سال__Null() => IsNull(tableMKView_FishHamkaran.سالColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_ماه__Null() => IsNull(tableMKView_FishHamkaran.ماهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_شماره_بیمه__Null() => IsNull(tableMKView_FishHamkaran.شماره_بیمهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکرد_موثر__Null() => IsNull(tableMKView_FishHamkaran.کارکرد_موثرColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_پاداش__Null() => IsNull(tableMKView_FishHamkaran.پاداشColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_تعداد_اولاد__Null() => IsNull(tableMKView_FishHamkaran.تعداد_اولادColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_مالیات__Null() => IsNull(tableMKView_FishHamkaran.مالیاتColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_بیمه_تامین_اجتماعی_سهم_کارمند__Null() => IsNull(tableMKView_FishHamkaran.بیمه_تامین_اجتماعی_سهم_کارمندColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_دستمزد_روزانه__Null() => IsNull(tableMKView_FishHamkaran.دستمزد_روزانهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_فوق_العاده_جذب__Null() => IsNull(tableMKView_FishHamkaran.فوق_العاده_جذبColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_فوق_العاده_کارایی__Null() => IsNull(tableMKView_FishHamkaran.فوق_العاده_کاراییColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_معوقه_دستی__Null() => IsNull(tableMKView_FishHamkaran.معوقه_دستیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_بیمه_تامین_اجتماعی_سهم_کارفرما__Null() => IsNull(tableMKView_FishHamkaran.بیمه_تامین_اجتماعی_سهم_کارفرماColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_بیمه_بیکاری__Null() => IsNull(tableMKView_FishHamkaran.بیمه_بیکاریColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_بیمه_تکمیلی_سهم_کارفرما__Null() => IsNull(tableMKView_FishHamkaran.بیمه_تکمیلی_سهم_کارفرماColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_معوقه_دستی_با_مالیات__Null() => IsNull(tableMKView_FishHamkaran.معوقه_دستی_با_مالیاتColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_فوق_العاده_خلاقیت__Null() => IsNull(tableMKView_FishHamkaran.فوق_العاده_خلاقیتColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_فوق_العاده_پست__Null() => IsNull(tableMKView_FishHamkaran.فوق_العاده_پستColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_حق_ایاب_و_ذهاب__Null() => IsNull(tableMKView_FishHamkaran.حق_ایاب_و_ذهابColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_فوق_العاده_منزلت_شغلی__Null() => IsNull(tableMKView_FishHamkaran.فوق_العاده_منزلت_شغلیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_ماموریت_عادی__Null() => IsNull(tableMKView_FishHamkaran.ماموریت_عادیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_ماموریت_روز_تعلیل__Null() => IsNull(tableMKView_FishHamkaran.ماموریت_روز_تعلیلColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_ماموریت_حومه__Null() => IsNull(tableMKView_FishHamkaran.ماموریت_حومهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_حق_غذای_ماموریت_حومه__Null() => IsNull(tableMKView_FishHamkaran.حق_غذای_ماموریت_حومهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_احضار_به_کار_پایین_تر_از_5_س__Null() => IsNull(tableMKView_FishHamkaran.احضار_به_کار_پایین_تر_از_5_سColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_احضار_به_کار_بین_5_تا_10_س__Null() => IsNull(tableMKView_FishHamkaran.احضار_به_کار_بین_5_تا_10_سColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_احضار_به_کار_بالاتر_از_10_س__Null() => IsNull(tableMKView_FishHamkaran.احضار_به_کار_بالاتر_از_10_سColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_هزینه_موبایل__Null() => IsNull(tableMKView_FishHamkaran.هزینه_موبایلColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کسر_کار__Null() => IsNull(tableMKView_FishHamkaran.کسر_کارColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_حقوق_گروه_مشاور__Null() => IsNull(tableMKView_FishHamkaran.حقوق_گروه_مشاورColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_حقوق_گروه_ساعتی__Null() => IsNull(tableMKView_FishHamkaran.حقوق_گروه_ساعتیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_غیبت_ماهانه__Null() => IsNull(tableMKView_FishHamkaran.غیبت_ماهانهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_احضار_به_کار_پایین_تر_از_5س__Null() => IsNull(tableMKView_FishHamkaran.احضار_به_کار_پایین_تر_از_5سColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_احضار_به_کار_بین_5_تا_10س__Null() => IsNull(tableMKView_FishHamkaran.احضار_به_کار_بین_5_تا_10سColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_سایر2__Null() => IsNull(tableMKView_FishHamkaran.سایر2Column);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_روند_حقوق__Null() => IsNull(tableMKView_FishHamkaran.روند_حقوقColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکرد_شب_کاری__Null() => IsNull(tableMKView_FishHamkaran.کارکرد_شب_کاریColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_سایر3__Null() => IsNull(tableMKView_FishHamkaran.سایر3Column);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_سایر1__Null() => IsNull(tableMKView_FishHamkaran.سایر1Column);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_نوبت_کاری_10__Null() => IsNull(tableMKView_FishHamkaran.نوبت_کاری_10Column);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_ماموریت_عادی_نهایی__Null() => IsNull(tableMKView_FishHamkaran.ماموریت_عادی_نهاییColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_ماموریت_تعلیل_نهایی__Null() => IsNull(tableMKView_FishHamkaran.ماموریت_تعلیل_نهاییColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکرد_ماموریت_حومه_نهایی__Null() => IsNull(tableMKView_FishHamkaran.کارکرد_ماموریت_حومه_نهاییColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_فوق_العاده_در_دسترسی_نهایی__Null() => IsNull(tableMKView_FishHamkaran.فوق_العاده_در_دسترسی_نهاییColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_بیمه_تکمیلی_سازمانی_کارمند__Null() =>
                IsNull(tableMKView_FishHamkaran.بیمه_تکمیلی_سازمانی_کارمندColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_تعطیل_کاری_دستور_کار_Null() =>
                IsNull(tableMKView_FishHamkaran.تعطیل_کاری_دستور_کارColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارانه_2__Null() =>
                IsNull(tableMKView_FishHamkaran.کارانه_2Column);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_حق_ناهار__Null() =>
                IsNull(tableMKView_FishHamkaran.حق_ناهارColumn);


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_خالص_حقوق__Null() =>
                IsNull(tableMKView_FishHamkaran.خالص_حقوقColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_گروه_شغلی__Null() =>
                IsNull(tableMKView_FishHamkaran.گروه_شغلیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_مزد_ماهانه__Null() =>
                IsNull(tableMKView_FishHamkaran.مزد_ماهانهColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکرد_شبکاری_روز__Null() =>
                IsNull(tableMKView_FishHamkaran.NightWorkingColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_کارکرد_تعطیل_کاری_روز__Null() =>
                IsNull(tableMKView_FishHamkaran.HolydayWorkingColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_بیمه_تکمیلی__Null() =>
                IsNull(tableMKView_FishHamkaran.بیمه_تکمیلیColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_قسط_وام_مسکن__Null() =>
                IsNull(tableMKView_FishHamkaran.قسط_وام_مسکنColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_مزد_روزانه__Null() =>
                IsNull(tableMKView_FishHamkaran.مزد_روزانه_Column);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_تعهدات_دولتی__Null() =>
                IsNull(tableMKView_FishHamkaran.تعهدات_دولتیColumn);
            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_دستمزد_ماهانه__Null() =>
                IsNull(tableMKView_FishHamkaran.دستمزد_ماهانهColumn);
            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public bool Is_قابل_پرداخت__Null() =>
                IsNull(tableMKView_FishHamkaran.قابل_پرداختColumn);

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارکرد_عادی__Null()
            {
                base[tableMKView_FishHamkaran.کارکرد_عادیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارکرد_اضافه_کاری__Null()
            {
                base[tableMKView_FishHamkaran.کارکرد_اضافه_کاریColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارکرد_تعطیل_کاری__Null()
            {
                base[tableMKView_FishHamkaran.کارکرد_تعطیل_کاریColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_جمعه_کاری__Null()
            {
                base[tableMKView_FishHamkaran.جمعه_کاریColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارکرد_شبکاری__Null()
            {
                base[tableMKView_FishHamkaran.کارکرد_شبکاریColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارکرد_شب_کاری_1__Null()
            {
                base[tableMKView_FishHamkaran.کارکرد_شب_کاری_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارکرد_مرخصی_استحقاقی__Null()
            {
                base[tableMKView_FishHamkaran.کارکرد_مرخصی_استحقاقیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارکرد_کارانه__Null()
            {
                base[tableMKView_FishHamkaran.کارکرد_کارانهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارکرد_ساعتی__Null()
            {
                base[tableMKView_FishHamkaran.کارکرد_ساعتیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_پایه_سنوات__Null()
            {
                base[tableMKView_FishHamkaran.پایه_سنواتColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_حقوق_پایه__Null()
            {
                base[tableMKView_FishHamkaran.حقوق_پایهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_حق_اولاد__Null()
            {
                base[tableMKView_FishHamkaran.حق_اولادColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_حق_اولاد_معوق__Null()
            {
                base[tableMKView_FishHamkaran.حق_اولاد_معوقColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_حق_مسکن__Null()
            {
                base[tableMKView_FishHamkaran.حق_مسکنColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_بن_کارگری__Null()
            {
                base[tableMKView_FishHamkaran.بن_کارگریColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_حق_خواربار__Null()
            {
                base[tableMKView_FishHamkaran.حق_خواربارColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_اضافه_کاری__Null()
            {
                base[tableMKView_FishHamkaran.اضافه_کاریColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_تعطیل_کاری__Null()
            {
                base[tableMKView_FishHamkaran.تعطیل_کاریColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_شب_کاری__Null()
            {
                base[tableMKView_FishHamkaran.شب_کاریColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_حق_شیر__Null()
            {
                base[tableMKView_FishHamkaran.حق_شیرColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_شیفت__Null()
            {
                base[tableMKView_FishHamkaran.شیفتColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_شیفت_ساعتی__Null()
            {
                base[tableMKView_FishHamkaran.شیفت_ساعتیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_مبلغ_تناژ__Null()
            {
                base[tableMKView_FishHamkaran.مبلغ_تناژColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_تنخواه__Null()
            {
                base[tableMKView_FishHamkaran.تنخواهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_حق_سوخت__Null()
            {
                base[tableMKView_FishHamkaran.حق_سوختColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_ماموریت__Null()
            {
                base[tableMKView_FishHamkaran.ماموریتColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_فوق_العاده_ماموریت__Null()
            {
                base[tableMKView_FishHamkaran.فوق_العاده_ماموریتColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_فوق_العاده_سرپرستی__Null()
            {
                base[tableMKView_FishHamkaran.فوق_العاده_سرپرستیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارانه__Null()
            {
                base[tableMKView_FishHamkaran.کارانهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارانه_ثابت__Null()
            {
                base[tableMKView_FishHamkaran.کارانه_ثابتColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارانه_ثابت2__Null()
            {
                base[tableMKView_FishHamkaran.کارانه_ثابت2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_سایر_مزایا__Null()
            {
                base[tableMKView_FishHamkaran.سایر_مزایاColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_مزایای_معوقه__Null()
            {
                base[tableMKView_FishHamkaran.مزایای_معوقهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارانه_معوق__Null()
            {
                base[tableMKView_FishHamkaran.کارانه_معوقColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_فوق_العاده_شغل__Null()
            {
                base[tableMKView_FishHamkaran.فوق_العاده_شغلColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_پاداش_پرسنل__Null()
            {
                base[tableMKView_FishHamkaran.پاداش_پرسنلColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_ایاب_و_ذهاب__Null()
            {
                base[tableMKView_FishHamkaran.ایاب_و_ذهابColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_معوقه_حقوق__Null()
            {
                base[tableMKView_FishHamkaran.معوقه_حقوقColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_بن_رمضان__Null()
            {
                base[tableMKView_FishHamkaran.بن_رمضانColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_هزینه_جارو__Null()
            {
                base[tableMKView_FishHamkaran.هزینه_جاروColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_پایه_سنوات_معوق__Null()
            {
                base[tableMKView_FishHamkaran.پایه_سنوات_معوقColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_سایر_مزایای_استیجاری__Null()
            {
                base[tableMKView_FishHamkaran.سایر_مزایای_استیجاریColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_بدهکاران_کارکنان__Null()
            {
                base[tableMKView_FishHamkaran.بدهکاران_کارکنانColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_بیمه_تامین_اجتماعی_سهم_کارگر__Null()
            {
                base[tableMKView_FishHamkaran.بیمه_تامین_اجتماعی_سهم_کارگرColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_بیمه_تکمیلی_سهم_کارمند__Null()
            {
                base[tableMKView_FishHamkaran.بیمه_تکمیلی_سهم_کارمندColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_سایر_کسور__Null()
            {
                base[tableMKView_FishHamkaran.سایر_کسورColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_خسارت_کارکنان__Null()
            {
                base[tableMKView_FishHamkaran.خسارت_کارکنانColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارکنان_بدهکار__Null()
            {
                base[tableMKView_FishHamkaran.کارکنان_بدهکارColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_مساعده__Null()
            {
                base[tableMKView_FishHamkaran.مساعدهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_تعهدات_دولتی_کارمند__Null()
            {
                base[tableMKView_FishHamkaran.تعهدات_دولتی_کارمندColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_جمع_اقساط_وام__Null()
            {
                base[tableMKView_FishHamkaran.جمع_اقساط_وامColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_تعاونی_مصرف_کارکنان__Null()
            {
                base[tableMKView_FishHamkaran.تعاونی_مصرف_کارکنانColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_مالیات_حقوق__Null()
            {
                base[tableMKView_FishHamkaran.مالیات_حقوقColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_جمع_مزایا__Null()
            {
                base[tableMKView_FishHamkaran.جمع_مزایاColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_جمع_کسور__Null()
            {
                base[tableMKView_FishHamkaran.جمع_کسورColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_خالص_پرداختی__Null()
            {
                base[tableMKView_FishHamkaran.خالص_پرداختیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_شماره_حساب__Null()
            {
                base[tableMKView_FishHamkaran.شماره_حسابColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_نام__Null()
            {
                base[tableMKView_FishHamkaran.نامColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_نام_خانوادگی__Null()
            {
                base[tableMKView_FishHamkaran.نام_خانوادگیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کد_پرسنلی__Null()
            {
                base[tableMKView_FishHamkaran.کد_پرسنلیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_نام_پدر__Null()
            {
                base[tableMKView_FishHamkaran.نام_پدرColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کد_ملی__Null()
            {
                base[tableMKView_FishHamkaran.کد_ملیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_شماره_شناسنامه__Null()
            {
                base[tableMKView_FishHamkaran.شماره_شناسنامهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_تاریخ_تولد__Null()
            {
                base[tableMKView_FishHamkaran.تاریخ_تولدColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_نام_شعبه__Null()
            {
                base[tableMKView_FishHamkaran.نام_شعبهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_سال__Null()
            {
                base[tableMKView_FishHamkaran.سالColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_ماه__Null()
            {
                base[tableMKView_FishHamkaran.ماهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_شماره_بیمه__Null()
            {
                base[tableMKView_FishHamkaran.شماره_بیمهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارکرد_موثر__Null()
            {
                base[tableMKView_FishHamkaran.کارکرد_موثرColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_پاداش__Null()
            {
                base[tableMKView_FishHamkaran.پاداشColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_تعداد_اولاد__Null()
            {
                base[tableMKView_FishHamkaran.تعداد_اولادColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_مالیات__Null()
            {
                base[tableMKView_FishHamkaran.مالیاتColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_بیمه_تامین_اجتماعی_سهم_کارمند__Null()
            {
                base[tableMKView_FishHamkaran.بیمه_تامین_اجتماعی_سهم_کارمندColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_دستمزد_روزانه__Null()
            {
                base[tableMKView_FishHamkaran.دستمزد_روزانهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_فوق_العاده_جذب__Null()
            {
                base[tableMKView_FishHamkaran.فوق_العاده_جذبColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_فوق_العاده_کارایی__Null()
            {
                base[tableMKView_FishHamkaran.فوق_العاده_کاراییColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_معوقه_دستی__Null()
            {
                base[tableMKView_FishHamkaran.معوقه_دستیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_بیمه_تامین_اجتماعی_سهم_کارفرما__Null()
            {
                base[tableMKView_FishHamkaran.بیمه_تامین_اجتماعی_سهم_کارفرماColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_بیمه_بیکاری__Null()
            {
                base[tableMKView_FishHamkaran.بیمه_بیکاریColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_بیمه_تکمیلی_سهم_کارفرما__Null()
            {
                base[tableMKView_FishHamkaran.بیمه_تکمیلی_سهم_کارفرماColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_معوقه_دستی_با_مالیات__Null()
            {
                base[tableMKView_FishHamkaran.معوقه_دستی_با_مالیاتColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_فوق_العاده_خلاقیت__Null()
            {
                base[tableMKView_FishHamkaran.فوق_العاده_خلاقیتColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_فوق_العاده_پست__Null()
            {
                base[tableMKView_FishHamkaran.فوق_العاده_پستColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_حق_ایاب_و_ذهاب__Null()
            {
                base[tableMKView_FishHamkaran.حق_ایاب_و_ذهابColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_فوق_العاده_منزلت_شغلی__Null()
            {
                base[tableMKView_FishHamkaran.فوق_العاده_منزلت_شغلیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_ماموریت_عادی__Null()
            {
                base[tableMKView_FishHamkaran.ماموریت_عادیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_ماموریت_روز_تعلیل__Null()
            {
                base[tableMKView_FishHamkaran.ماموریت_روز_تعلیلColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_ماموریت_حومه__Null()
            {
                base[tableMKView_FishHamkaran.ماموریت_حومهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_حق_غذای_ماموریت_حومه__Null()
            {
                base[tableMKView_FishHamkaran.حق_غذای_ماموریت_حومهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_احضار_به_کار_پایین_تر_از_5_س__Null()
            {
                base[tableMKView_FishHamkaran.احضار_به_کار_پایین_تر_از_5_سColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_احضار_به_کار_بین_5_تا_10_س__Null()
            {
                base[tableMKView_FishHamkaran.احضار_به_کار_بین_5_تا_10_سColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_احضار_به_کار_بالاتر_از_10_س__Null()
            {
                base[tableMKView_FishHamkaran.احضار_به_کار_بالاتر_از_10_سColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_هزینه_موبایل__Null()
            {
                base[tableMKView_FishHamkaran.هزینه_موبایلColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کسر_کار__Null()
            {
                base[tableMKView_FishHamkaran.کسر_کارColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_حقوق_گروه_مشاور__Null()
            {
                base[tableMKView_FishHamkaran.حقوق_گروه_مشاورColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_حقوق_گروه_ساعتی__Null()
            {
                base[tableMKView_FishHamkaran.حقوق_گروه_ساعتیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_غیبت_ماهانه__Null()
            {
                base[tableMKView_FishHamkaran.غیبت_ماهانهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_احضار_به_کار_پایین_تر_از_5س__Null()
            {
                base[tableMKView_FishHamkaran.احضار_به_کار_پایین_تر_از_5سColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_احضار_به_کار_بین_5_تا_10س__Null()
            {
                base[tableMKView_FishHamkaran.احضار_به_کار_بین_5_تا_10سColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_سایر2__Null()
            {
                base[tableMKView_FishHamkaran.سایر2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_روند_حقوق__Null()
            {
                base[tableMKView_FishHamkaran.روند_حقوقColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارکرد_شب_کاری__Null()
            {
                base[tableMKView_FishHamkaran.کارکرد_شب_کاریColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_سایر3__Null()
            {
                base[tableMKView_FishHamkaran.سایر3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_سایر1__Null()
            {
                base[tableMKView_FishHamkaran.سایر1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_نوبت_کاری_10__Null()
            {
                base[tableMKView_FishHamkaran.نوبت_کاری_10Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_ماموریت_عادی_نهایی__Null()
            {
                base[tableMKView_FishHamkaran.ماموریت_عادی_نهاییColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_ماموریت_تعلیل_نهایی__Null()
            {
                base[tableMKView_FishHamkaran.ماموریت_تعلیل_نهاییColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارکرد_ماموریت_حومه_نهایی__Null()
            {
                base[tableMKView_FishHamkaran.کارکرد_ماموریت_حومه_نهاییColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_فوق_العاده_در_دسترسی_نهایی__Null()
            {
                base[tableMKView_FishHamkaran.فوق_العاده_در_دسترسی_نهاییColumn] = Convert.DBNull;
            }
            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_بیمه_تکمیلی_سازمانی_کارمند__Null()
            {
                base[tableMKView_FishHamkaran.بیمه_تکمیلی_سازمانی_کارمندColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_تعطیل_کاری_دستور_کاری__Null()
            {
                base[tableMKView_FishHamkaran.تعطیل_کاری_دستور_کارColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارانه_2__Null()
            {
                base[tableMKView_FishHamkaran.کارانه_2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_حق_ناهار__Null()
            {
                base[tableMKView_FishHamkaran.حق_ناهارColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_خالص_حقوق__Null()
            {
                base[tableMKView_FishHamkaran.خالص_حقوقColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_گروه_شغلی__Null()
            {
                base[tableMKView_FishHamkaran.گروه_شغلیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_مزد_ماهانه__Null()
            {
                base[tableMKView_FishHamkaran.مزد_ماهانهColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارکرد_شبکاری_روز__Null()
            {
                base[tableMKView_FishHamkaran.NightWorkingColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_کارکرد_تعطیل_کاری_روز__Null()
            {
                base[tableMKView_FishHamkaran.HolydayWorkingColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_بیمه_تکمیلی__Null()
            {
                base[tableMKView_FishHamkaran.بیمه_تکمیلیColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_قسط_وام_مسکن__Null()
            {
                base[tableMKView_FishHamkaran.قسط_وام_مسکنColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_مزد_روزانه__Null()
            {
                base[tableMKView_FishHamkaran.مزد_روزانه_Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_تعهدات_دولتی__Null()
            {
                base[tableMKView_FishHamkaran.تعهدات_دولتیColumn] = Convert.DBNull;
            }
            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_دستمزد_ماهانه__Null()
            {
                base[tableMKView_FishHamkaran.دستمزد_ماهانهColumn] = Convert.DBNull;
            }
            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public void Set_قابل_پرداخت__Null()
            {
                base[tableMKView_FishHamkaran.قابل_پرداختColumn] = Convert.DBNull;
            }
            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string کد_پرسنلی
            {
                get =>
                    (string)base[tableMKView_FishHamkaran.کد_پرسنلیColumn];
                set =>
                    base[tableMKView_FishHamkaran.کد_پرسنلیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string نام
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_FishHamkaran.نامColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'نام' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_FishHamkaran.نامColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string نام_خانوادگی
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_FishHamkaran.نام_خانوادگیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'نام خانوادگی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_FishHamkaran.نام_خانوادگیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string نام_پدر
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_FishHamkaran.نام_پدرColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'نام پدر' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_FishHamkaran.نام_پدرColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string کد_ملی
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_FishHamkaran.کد_ملیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کد ملی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_FishHamkaran.کد_ملیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string شماره_شناسنامه
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_FishHamkaran.شماره_شناسنامهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'شماره شناسنامه' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_FishHamkaran.شماره_شناسنامهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DateTime تاریخ_تولد
            {
                get
                {
                    DateTime time;
                    try
                    {
                        time = (DateTime)base[tableMKView_FishHamkaran.تاریخ_تولدColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'تاریخ تولد' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return time;
                }
                set =>
                    base[tableMKView_FishHamkaran.تاریخ_تولدColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string نام_شعبه
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_FishHamkaran.نام_شعبهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'نام شعبه' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_FishHamkaran.نام_شعبهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string شماره_حساب
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_FishHamkaran.شماره_حسابColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'شماره حساب' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_FishHamkaran.شماره_حسابColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string سال
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_FishHamkaran.سالColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'سال' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_FishHamkaran.سالColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string ماه
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_FishHamkaran.ماهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ماه' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_FishHamkaran.ماهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public string شماره_بیمه
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string)base[tableMKView_FishHamkaran.شماره_بیمهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'شماره بیمه' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return str;
                }
                set =>
                    base[tableMKView_FishHamkaran.شماره_بیمهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارکرد_موثر
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارکرد_موثرColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارکرد موثر' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.کارکرد_موثرColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حقوق_پایه
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.حقوق_پایهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'حقوق پایه' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.حقوق_پایهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal اضافه_کاری
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.اضافه_کاریColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'اضافه کاری' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.اضافه_کاریColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حق_مسکن
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.حق_مسکنColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'حق مسکن' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.حق_مسکنColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حق_خواربار
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.حق_خواربارColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'حق خواربار' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.حق_خواربارColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حق_اولاد
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.حق_اولادColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'حق اولاد' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.حق_اولادColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal تعطیل_کاری
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.تعطیل_کاریColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'تعطیل کاری' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.تعطیل_کاریColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal بن_کارگری
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.بن_کارگریColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'بن کارگری' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.بن_کارگریColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal پاداش
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.پاداشColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'پاداش' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.پاداشColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal پاداش_پرسنل
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.پاداش_پرسنلColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'پاداش پرسنل' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.پاداش_پرسنلColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حق_شیر
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.حق_شیرColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'حق شیر' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.حق_شیرColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal تعداد_اولاد
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.تعداد_اولادColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'تعداد اولاد' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.تعداد_اولادColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal جمع_مزایا
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.جمع_مزایاColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'جمع مزایا' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.جمع_مزایاColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal شب_کاری
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.شب_کاریColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'شب کاری' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.شب_کاریColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal مالیات
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.مالیاتColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'مالیات' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.مالیاتColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal بیمه_تامین_اجتماعی_سهم_کارمند
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.بیمه_تامین_اجتماعی_سهم_کارمندColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'بیمه تامین اجتماعی سهم کارمند' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.بیمه_تامین_اجتماعی_سهم_کارمندColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal بیمه_تکمیلی_سهم_کارمند
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.بیمه_تکمیلی_سهم_کارمندColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'بیمه تکمیلی سهم کارمند' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.بیمه_تکمیلی_سهم_کارمندColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal جمع_اقساط_وام
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.جمع_اقساط_وامColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'جمع اقساط وام' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.جمع_اقساط_وامColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal دستمزد_روزانه
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.دستمزد_روزانهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'دستمزد روزانه' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.دستمزد_روزانهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal فوق_العاده_جذب
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.فوق_العاده_جذبColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'فوق العاده جذب' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.فوق_العاده_جذبColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal مساعده
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.مساعدهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'مساعده' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.مساعدهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal فوق_العاده_کارایی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.فوق_العاده_کاراییColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'فوق العاده کارایی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.فوق_العاده_کاراییColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal جمع_کسور
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.جمع_کسورColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'جمع کسور' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.جمع_کسورColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal خالص_پرداختی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.خالص_پرداختیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'خالص پرداختی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.خالص_پرداختیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal معوقه_دستی_
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.معوقه_دستیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'معوقه دستی ' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.معوقه_دستیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal بیمه_تامین_اجتماعی_سهم_کارفرما
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.بیمه_تامین_اجتماعی_سهم_کارفرماColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'بیمه تامین اجتماعی سهم کارفرما' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.بیمه_تامین_اجتماعی_سهم_کارفرماColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal بیمه_بیکاری_
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.بیمه_بیکاریColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'بیمه بیکاری ' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.بیمه_بیکاریColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal بیمه_تکمیلی_سهم_کارفرما
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.بیمه_تکمیلی_سهم_کارفرماColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'بیمه تکمیلی سهم کارفرما' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.بیمه_تکمیلی_سهم_کارفرماColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal معوقه_دستی_با_مالیات
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.معوقه_دستی_با_مالیاتColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'معوقه دستی با مالیات' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.معوقه_دستی_با_مالیاتColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal فوق_العاده_خلاقیت
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.فوق_العاده_خلاقیتColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'فوق العاده خلاقیت' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.فوق_العاده_خلاقیتColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal فوق_العاده_شغل
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.فوق_العاده_شغلColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'فوق العاده شغل' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.فوق_العاده_شغلColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal فوق_العاده_پست_
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.فوق_العاده_پستColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'فوق العاده پست ' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.فوق_العاده_پستColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حق_ایاب_و_ذهاب
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.حق_ایاب_و_ذهابColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'حق ایاب و ذهاب' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.حق_ایاب_و_ذهابColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal فوق_العاده_منزلت_شغلی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.فوق_العاده_منزلت_شغلیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'فوق العاده منزلت شغلی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.فوق_العاده_منزلت_شغلیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal ماموریت_عادی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.ماموریت_عادیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ماموریت عادی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.ماموریت_عادیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal ماموریت_روز_تعلیل
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.ماموریت_روز_تعلیلColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ماموریت روز تعلیل' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.ماموریت_روز_تعلیلColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal ماموریت_حومه
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.ماموریت_حومهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ماموریت حومه' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.ماموریت_حومهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حق_غذای_ماموریت_حومه
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.حق_غذای_ماموریت_حومهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'حق غذای ماموریت حومه' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.حق_غذای_ماموریت_حومهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal احضار_به_کار_پایین_تر_از_5_س
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.احضار_به_کار_پایین_تر_از_5_سColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'احضار به کار پایین تر از 5 س' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.احضار_به_کار_پایین_تر_از_5_سColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal احضار_به_کار_بین_5_تا_10_س
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.احضار_به_کار_بین_5_تا_10_سColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'احضار به کار بین 5 تا 10 س' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.احضار_به_کار_بین_5_تا_10_سColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal احضار_به_کار_بالاتر_از_10_س
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.احضار_به_کار_بالاتر_از_10_سColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'احضار به کار بالاتر از 10 س' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.احضار_به_کار_بالاتر_از_10_سColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal هزینه_موبایل
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.هزینه_موبایلColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'هزینه موبایل' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.هزینه_موبایلColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کسر_کار
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کسر_کارColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کسر کار' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.کسر_کارColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حقوق_گروه_مشاور
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.حقوق_گروه_مشاورColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'حقوق گروه مشاور' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.حقوق_گروه_مشاورColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حقوق_گروه_ساعتی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.حقوق_گروه_ساعتیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'حقوق گروه ساعتی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.حقوق_گروه_ساعتیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal غیبت_ماهانه
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.غیبت_ماهانهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'غیبت ماهانه' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.غیبت_ماهانهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارکرد_اضافه_کاری
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارکرد_اضافه_کاریColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارکرد اضافه کاری' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.کارکرد_اضافه_کاریColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارکرد_تعطیل_کاری
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارکرد_تعطیل_کاریColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارکرد تعطیل کاری' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.کارکرد_تعطیل_کاریColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal جمعه_کاری
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.جمعه_کاریColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'جمعه_کاری' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.جمعه_کاریColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارکرد_شبکاری
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارکرد_شبکاریColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارکرد شبکاری' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.کارکرد_شبکاریColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارکرد_مرخصی_استحقاقی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارکرد_مرخصی_استحقاقیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارکرد مرخصی استحقاقی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.کارکرد_مرخصی_استحقاقیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارکرد_کارانه
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارکرد_کارانهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارکرد کارانه' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.کارکرد_کارانهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارکرد_کارانه2
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارکرد_کارانه2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارکرد کارانه2' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.کارکرد_کارانه2Column] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارکرد_ساعتی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارکرد_ساعتیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارکرد ساعتی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.کارکرد_ساعتیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارکرد_شب_کاری_1
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارکرد_شب_کاری_1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارکرد شب کاری 1' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.کارکرد_شب_کاری_1Column] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارکرد_شب_کاری
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارکرد_شب_کاریColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارکرد شب کاری' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.کارکرد_شب_کاریColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal سایر3
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.سایر3Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'سایر3' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.سایر3Column] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal سایر1
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.سایر1Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'سایر1' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.سایر1Column] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal _نوبت_کاری_10__
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.نوبت_کاری_10Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'نوبت کاری 10 %' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.نوبت_کاری_10Column] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal ماموریت_عادی_نهایی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.ماموریت_عادی_نهاییColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ماموریت عادی نهایی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.ماموریت_عادی_نهاییColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal ماموریت_تعلیل_نهایی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.ماموریت_تعلیل_نهاییColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ماموریت تعلیل نهایی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.ماموریت_تعلیل_نهاییColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارکرد_ماموریت_حومه_نهایی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارکرد_ماموریت_حومه_نهاییColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارکرد ماموریت حومه نهایی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.کارکرد_ماموریت_حومه_نهاییColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal فوق_العاده_در_دسترسی_نهایی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.فوق_العاده_در_دسترسی_نهاییColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'فوق العاده در دسترسی نهایی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.فوق_العاده_در_دسترسی_نهاییColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal احضار_به_کار_پایین_تر_از_5س
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.احضار_به_کار_پایین_تر_از_5سColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'احضار به کار پایین تر از 5س' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.احضار_به_کار_پایین_تر_از_5سColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal احضار_به_کار_بین_5_تا_10س
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.احضار_به_کار_بین_5_تا_10سColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'احضار به کار بین 5 تا 10س' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.احضار_به_کار_بین_5_تا_10سColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal سایر_کسور
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.سایر_کسورColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'سایر کسور' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.سایر_کسورColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal سایر2
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.سایر2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'سایر2' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.سایر2Column] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal روند_حقوق
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.روند_حقوقColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'روند حقوق' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.روند_حقوقColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal سایر_مزایا
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.سایر_مزایاColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'سایر مزایا' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.سایر_مزایاColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal خسارت_کارکنان
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.خسارت_کارکنانColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'خسارت کارکنان' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.خسارت_کارکنانColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal پایه_سنوات
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.پایه_سنواتColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'پایه سنوات' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set =>
                    base[tableMKView_FishHamkaran.پایه_سنواتColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حق_اولاد_معوق
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.حق_اولاد_معوقColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'حق اولاد معوق' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.حق_اولاد_معوقColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal شیفت
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.شیفتColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'شیفت' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.شیفتColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal شیفت_ساعتی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.شیفت_ساعتیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'شیفت ساعتی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.شیفت_ساعتیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal مبلغ_تناژ
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.مبلغ_تناژColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'مبلغ تناژ' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.مبلغ_تناژColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal تنخواه
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.تنخواهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'تنخواه' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.تنخواهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حق_سوخت
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.حق_سوختColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'حق سوخت' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.حق_سوختColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal ماموریت
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.ماموریتColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ماموریت' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.ماموریتColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal فوق_العاده_ماموریت
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.فوق_العاده_ماموریتColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'فوق العاده ماموریت' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.فوق_العاده_ماموریتColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal فوق_العاده_سرپرستی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.فوق_العاده_سرپرستیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'فوق العاده سرپرستی' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.فوق_العاده_سرپرستیColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارانه
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارانهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارانه' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.کارانهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارانه_ثابت
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارانه_ثابتColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارانه ثابت' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.کارانه_ثابتColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارانه_ثابت2
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارانه_ثابت2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارانه ثابت2' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.کارانه_ثابت2Column] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal مزایای_معوقه
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.مزایای_معوقهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'مزایای معوقه' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.مزایای_معوقهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارانه_معوق
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارانه_معوقColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارانه معوق' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.کارانه_معوقColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal ایاب_و_ذهاب
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.ایاب_و_ذهابColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ایاب و ذهاب' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.ایاب_و_ذهابColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal معوقه_حقوق
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.معوقه_حقوقColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'معوقه حقوق' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.معوقه_حقوقColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal بن_رمضان
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.بن_رمضانColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'بن رمضان' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.بن_رمضانColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal هزینه_جارو
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.هزینه_جاروColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'هزینه جارو' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.هزینه_جاروColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal پایه_سنوات_معوق
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.پایه_سنوات_معوقColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'پایه سنوات معوق' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.پایه_سنوات_معوقColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal سایر_مزایای_استیجاری
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.سایر_مزایای_استیجاریColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'سایر مزایای استیجاری' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.سایر_مزایای_استیجاریColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal بدهکاران_کارکنان
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.بدهکاران_کارکنانColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'بدهکاران کارکنان' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.بدهکاران_کارکنانColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal بیمه_تامین_اجتماعی_سهم_کارگر
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.بیمه_تامین_اجتماعی_سهم_کارگرColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'بیمه تامین اجتماعی سهم کارگر' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.بیمه_تامین_اجتماعی_سهم_کارگرColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارکنان_بدهکار
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارکنان_بدهکارColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'کارکنان بدهکار' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.کارکنان_بدهکارColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal تعهدات_دولتی_کارمند
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.تعهدات_دولتی_کارمندColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'تعهدات دولتی کارمند' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.تعهدات_دولتی_کارمندColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal تعاونی_مصرف_کارکنان
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.تعاونی_مصرف_کارکنانColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'تعاونی مصرف کارکنان' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.تعاونی_مصرف_کارکنانColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal مالیات_حقوق
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.مالیات_حقوقColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'مالیات حقوق' in table 'MKView_FishHamkaran' is DBNull.", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.مالیات_حقوقColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal بیمه_تکمیلی_سازمانی_کارمند
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.بیمه_تکمیلی_سازمانی_کارمندColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Case Exception Occured");
                    }

                    return num;
                }
                set => base[tableMKView_FishHamkaran.بیمه_تکمیلی_سازمانی_کارمندColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal تعطیل_کاری_دستور_کار
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.تعطیل_کاری_دستور_کارColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Cast Exception");
                    }

                    return num;
                }
                set => base[tableMKView_FishHamkaran.تعطیل_کاری_دستور_کارColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal کارانه2
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.کارانه_2Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Cast Exception", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.کارانه_2Column] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal حق_ناهار
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.حق_ناهارColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Cast Exception", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.حق_ناهارColumn] = value;
            }


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal خالص_حقوق
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.خالص_حقوقColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Cast Exception", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.خالص_حقوقColumn] = value;
            }


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal گروه_شغلی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.گروه_شغلیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Cast Exception", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.گروه_شغلیColumn] = value;
            }


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal مزد_ماهانه
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.مزد_ماهانهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Cast Exception", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.مزد_ماهانهColumn] = value;
            }


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public dynamic Nightworkprop
            {
                get
                {
                    dynamic num;
                    try
                    {
                        num = base[tableMKView_FishHamkaran.NightWorkingColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Cast Exception", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.NightWorkingColumn] = value;
            }


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal Holidayworkprop
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.HolydayWorkingColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Cast Exception", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.HolydayWorkingColumn] = value;
            }


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal بیمه_تکمیلی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.بیمه_تکمیلیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Cast Exception", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.بیمه_تکمیلیColumn] = value;
            }


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal قسط_وام_مسکن
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.قسط_وام_مسکنColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Cast Exception", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.قسط_وام_مسکنColumn] = value;
            }


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal مزد_روزانه
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.مزد_روزانه_Column];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Cast Exception", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.مزد_روزانه_Column] = value;
            }


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal تعهدات_دولتی
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.تعهدات_دولتیColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Cast Exception", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.تعهدات_دولتیColumn] = value;
            }


            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal دستمزد_ماهانه
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.دستمزد_ماهانهColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Cast Exception", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.دستمزد_ماهانهColumn] = value;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public decimal قابل_پرداخت
            {
                get
                {
                    decimal num;
                    try
                    {
                        num = (decimal)base[tableMKView_FishHamkaran.قابل_پرداختColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("Invalid Cast Exception", exception);
                    }
                    return num;
                }
                set => base[tableMKView_FishHamkaran.قابل_پرداختColumn] = value;
            }

            //[DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            //public decimal مبلغ_قسط
            //{
            //    get
            //    {
            //        decimal num;
            //        try
            //        {
            //            num = (decimal)base[tableMKView_FishHamkaran.مبلغ_قسطColumn];
            //        }
            //        catch (InvalidCastException exception)
            //        {
            //            throw new StrongTypingException("The value for column 'مبلغ قسط' in table 'MKView_FishHamkaran' is DBNull.", exception);
            //        }
            //        return num;
            //    }
            //    set => base[tableMKView_FishHamkaran.مبلغ_قسطColumn] = value;
            //}

            //[DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            //public decimal مانده_قسط
            //{
            //    get
            //    {
            //        decimal num;
            //        try
            //        {
            //            num = (decimal)base[tableMKView_FishHamkaran.مانده_قسطColumn];
            //        }
            //        catch (InvalidCastException exception)
            //        {
            //            throw new StrongTypingException("The value for column 'مانده قسط' in table 'MKView_FishHamkaran' is DBNull.", exception);
            //        }
            //        return num;
            //    }
            //    set => base[tableMKView_FishHamkaran.مانده_قسطColumn] = value;
            //}
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public class MKView_FishHamkaranRowChangeEvent : EventArgs
        {
            private MKView_FishHamkaranRow eventRow;
            private DataRowAction eventAction;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public MKView_FishHamkaranRowChangeEvent(MKView_FishHamkaranRow row, DataRowAction action)
            {
                eventRow = row;
                eventAction = action;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public MKView_FishHamkaranRow Row =>
                eventRow;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public DataRowAction Action =>
                eventAction;
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public delegate void MKView_FishHamkaranRowChangeEventHandler(object sender, MKView_FishHamkaranRowChangeEvent e);
    }
}

