namespace FishHoghoghi.FishDataSetTableAdapters
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics;

    [DesignerCategory("code"), ToolboxItem(true), DataObject(true), Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), HelpKeyword("vs.data.TableAdapter")]
    public class MKView_ContractHamkaranTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        private SqlCommand[] _commandCollection;
        private bool _clearBeforeFill;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public MKView_ContractHamkaranTableAdapter()
        {
            ClearBeforeFill = true;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Fill, true)]
        public virtual int Fill(FishDataSet.MKView_ContractHamkaranDataTable dataTable, string NationalID)
        {
            Adapter.SelectCommand = CommandCollection[0];
            if (NationalID == null)
            {
                Adapter.SelectCommand.Parameters[0].Value = DBNull.Value;
            }
            else
            {
                Adapter.SelectCommand.Parameters[0].Value = NationalID;
            }
            if (ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return Adapter.Fill(dataTable);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, true)]
        public virtual FishDataSet.MKView_ContractHamkaranDataTable GetData(string NationalID)
        {
            Adapter.SelectCommand = CommandCollection[0];
            if (NationalID == null)
            {
                Adapter.SelectCommand.Parameters[0].Value = DBNull.Value;
            }
            else
            {
                Adapter.SelectCommand.Parameters[0].Value = NationalID;
            }
            FishDataSet.MKView_ContractHamkaranDataTable dataTable = new FishDataSet.MKView_ContractHamkaranDataTable();
            Adapter.Fill(dataTable);
            return dataTable;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private void InitAdapter()
        {
            _adapter = new SqlDataAdapter();
            DataTableMapping mapping = new DataTableMapping
            {
                SourceTable = "Table",
                DataSetTable = "MKView_ContractHamkaran",
                ColumnMappings = {
                    {
                        "کد پرسنلی",
                        "کد پرسنلی"
                    },
                    {
                        "نام",
                        "نام"
                    },
                    {
                        "نام خانوادگی",
                        "نام خانوادگی"
                    },
                    {
                        "نام پدر",
                        "نام پدر"
                    },
                    {
                        "پروژه",
                        "پروژه"
                    },
                    {
                        "کد پروژه",
                        "کد پروژه"
                    },
                    {
                        "شغل",
                        "شغل"
                    },
                    {
                        "کد ملی",
                        "کد ملی"
                    },
                    {
                        "شماره شناسنامه",
                        "شماره شناسنامه"
                    },
                    {
                        "محل صدور",
                        "محل صدور"
                    },
                    {
                        "آخرین مدرک و رشته تحصیلی",
                        "آخرین مدرک و رشته تحصیلی"
                    },
                    {
                        "وضعیت سربازی",
                        "وضعیت سربازی"
                    },
                    {
                        "تاریخ تولد",
                        "تاریخ تولد"
                    },
                    {
                        "تاریخ شروع قرارداد",
                        "تاریخ شروع قرارداد"
                    },
                    {
                        "تاریخ پایان قرارداد",
                        "تاریخ پایان قرارداد"
                    },
                    {
                        "مدت قرارداد",
                        "مدت قرارداد"
                    },
                    {
                        "حقوق پایه",
                        "حقوق پایه"
                    },
                    {
                        "حق مسکن",
                        "حق مسکن"
                    },
                    {
                        "بن کارگری",
                        "بن کارگری"
                    },
                    {
                        "حق اولاد",
                        "حق اولاد"
                    },
                    {
                        "پایه سنوات",
                        "پایه سنوات"
                    },
                    {
                        "EmployeeStatuteID",
                        "EmployeeStatuteID"
                    },
                    {
                        "تعداد اولاد",
                        "تعداد اولاد"
                    },
                    {
                        "کد گروه شغل",
                        "کد گروه شغل"
                    },
                    {
                        "نام واحد یا سازمان محل خدمت",
                        "نام واحد یا سازمان محل خدمت"
                    },
                    {
                        "مدیریت واحد یا سازمان محل خدمت",
                        "مدیریت واحد یا سازمان محل خدمت"
                    },
                    {
                        "نشانی واحد یا سازمان محل خدمت",
                        "نشانی واحد یا سازمان محل خدمت"
                    },
                    {
                        "ساعت شروع کار",
                        "ساعت شروع کار"
                    },
                    {
                        "ساعت پایان کار",
                        "ساعت پایان کار"
                    },
                    {
                        "company_name",
                        "company_name"
                    },
                    {
                        "ceo_name",
                        "ceo_name"
                    },
                    {
                        "register_number",
                        "register_number"
                    },
                    {
                        "address",
                        "address"
                    }
                }
            };
            _adapter.TableMappings.Add(mapping);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private void InitCommandCollection()
        {
            _commandCollection = new SqlCommand[] { new SqlCommand() };
            _commandCollection[0].Connection = Connection;
            _commandCollection[0].CommandText = "SELECT   TOP 1    *\r\nFROM            MKView_ContractHamkaran\r\nWHERE ([کد ملی] = @NationalID)\r\nORDER BY EmployeeStatuteID DESC";
            _commandCollection[0].CommandType = CommandType.Text;
            _commandCollection[0].Parameters.Add(new SqlParameter("@NationalID", SqlDbType.NVarChar, 20, ParameterDirection.Input, 0, 0, "کد ملی", DataRowVersion.Current, false, null, "", "", ""));
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private void InitConnection()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["Sg3ConnectionString"].ConnectionString;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        protected internal SqlDataAdapter Adapter
        {
            get
            {
                if (_adapter == null)
                {
                    InitAdapter();
                }
                return _adapter;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        internal SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    InitConnection();
                }
                return _connection;
            }
            set
            {
                _connection = value;
                if (Adapter.InsertCommand != null)
                {
                    Adapter.InsertCommand.Connection = value;
                }
                if (Adapter.DeleteCommand != null)
                {
                    Adapter.DeleteCommand.Connection = value;
                }
                if (Adapter.UpdateCommand != null)
                {
                    Adapter.UpdateCommand.Connection = value;
                }
                for (int i = 0; i < CommandCollection.Length; i++)
                {
                    if (CommandCollection[i] != null)
                    {
                        CommandCollection[i].Connection = value;
                    }
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        internal SqlTransaction Transaction
        {
            get =>
                _transaction;
            set
            {
                _transaction = value;
                for (int i = 0; i < CommandCollection.Length; i++)
                {
                    CommandCollection[i].Transaction = _transaction;
                }
                if (Adapter != null && Adapter.DeleteCommand != null)
                {
                    Adapter.DeleteCommand.Transaction = _transaction;
                }
                if (Adapter != null && Adapter.InsertCommand != null)
                {
                    Adapter.InsertCommand.Transaction = _transaction;
                }
                if (Adapter != null && Adapter.UpdateCommand != null)
                {
                    Adapter.UpdateCommand.Transaction = _transaction;
                }
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        protected SqlCommand[] CommandCollection
        {
            get
            {
                if (_commandCollection == null)
                {
                    InitCommandCollection();
                }
                return _commandCollection;
            }
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public bool ClearBeforeFill
        {
            get =>
                _clearBeforeFill;
            set =>
                _clearBeforeFill = value;
        }
    }
}