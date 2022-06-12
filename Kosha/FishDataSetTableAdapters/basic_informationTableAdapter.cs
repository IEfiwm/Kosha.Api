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
    public class basic_informationTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        private SqlCommand[] _commandCollection;
        private bool _clearBeforeFill;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public basic_informationTableAdapter()
        {
            ClearBeforeFill = true;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Delete, true)]
        public virtual int Delete(int Original_id)
        {
            int num2;
            Adapter.DeleteCommand.Parameters[0].Value = Original_id;
            ConnectionState state = Adapter.DeleteCommand.Connection.State;
            if ((Adapter.DeleteCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                Adapter.DeleteCommand.Connection.Open();
            }
            try
            {
                num2 = Adapter.DeleteCommand.ExecuteNonQuery();
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    Adapter.DeleteCommand.Connection.Close();
                }
            }
            return num2;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Fill, true)]
        public virtual int Fill(FishDataSet.basic_informationDataTable dataTable)
        {
            Adapter.SelectCommand = CommandCollection[0];
            if (ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return Adapter.Fill(dataTable);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, true)]
        public virtual FishDataSet.basic_informationDataTable GetData()
        {
            Adapter.SelectCommand = CommandCollection[0];
            FishDataSet.basic_informationDataTable dataTable = new FishDataSet.basic_informationDataTable();
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
                DataSetTable = "basic_information",
                ColumnMappings = {
                    {
                        "id",
                        "id"
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
                        "support_phone_number",
                        "support_phone_number"
                    },
                    {
                        "home_subsidy",
                        "home_subsidy"
                    },
                    {
                        "mariage_base",
                        "mariage_base"
                    },
                    {
                        "bon",
                        "bon"
                    }
                }
            };
            _adapter.TableMappings.Add(mapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = Connection;
            _adapter.DeleteCommand.CommandText = "DELETE FROM [basic_information] WHERE (([id] = @Original_id))";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = Connection;
            _adapter.InsertCommand.CommandText = "INSERT INTO [basic_information] ([company_name], [ceo_name], [register_number], [support_phone_number], [home_subsidy], [mariage_base], [bon]) VALUES (@company_name, @ceo_name, @register_number, @support_phone_number, @home_subsidy, @mariage_base, @bon)";
            _adapter.InsertCommand.CommandType = CommandType.Text;
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@company_name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "company_name", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@ceo_name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ceo_name", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@register_number", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "register_number", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@support_phone_number", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "support_phone_number", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@home_subsidy", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "home_subsidy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@mariage_base", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "mariage_base", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@bon", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "bon", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = Connection;
            _adapter.UpdateCommand.CommandText = "UPDATE [basic_information] SET [company_name] = @company_name, [ceo_name] = @ceo_name, [register_number] = @register_number, [support_phone_number] = @support_phone_number, [home_subsidy] = @home_subsidy, [mariage_base] = @mariage_base, [bon] = @bon WHERE (([id] = @Original_id))";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@company_name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "company_name", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ceo_name", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "ceo_name", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@register_number", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "register_number", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@support_phone_number", SqlDbType.NVarChar, 0, ParameterDirection.Input, 0, 0, "support_phone_number", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@home_subsidy", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "home_subsidy", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@mariage_base", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "mariage_base", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@bon", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "bon", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Original, false, null, "", "", ""));
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private void InitCommandCollection()
        {
            _commandCollection = new SqlCommand[] { new SqlCommand() };
            _commandCollection[0].Connection = Connection;
            _commandCollection[0].CommandText = "SELECT * FROM basic_information";
            _commandCollection[0].CommandType = CommandType.Text;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private void InitConnection()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["Sg3ConnectionString"].ConnectionString;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Insert, true)]
        public virtual int Insert(string company_name, string ceo_name, string register_number, string support_phone_number, int? home_subsidy, int? mariage_base, int? bon)
        {
            int num2;
            if (company_name == null)
            {
                Adapter.InsertCommand.Parameters[0].Value = DBNull.Value;
            }
            else
            {
                Adapter.InsertCommand.Parameters[0].Value = company_name;
            }
            if (ceo_name == null)
            {
                Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
            }
            else
            {
                Adapter.InsertCommand.Parameters[1].Value = ceo_name;
            }
            if (register_number == null)
            {
                Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                Adapter.InsertCommand.Parameters[2].Value = register_number;
            }
            if (support_phone_number == null)
            {
                Adapter.InsertCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                Adapter.InsertCommand.Parameters[3].Value = support_phone_number;
            }
            if (home_subsidy.HasValue)
            {
                Adapter.InsertCommand.Parameters[4].Value = home_subsidy.Value;
            }
            else
            {
                Adapter.InsertCommand.Parameters[4].Value = DBNull.Value;
            }
            if (mariage_base.HasValue)
            {
                Adapter.InsertCommand.Parameters[5].Value = mariage_base.Value;
            }
            else
            {
                Adapter.InsertCommand.Parameters[5].Value = DBNull.Value;
            }
            if (bon.HasValue)
            {
                Adapter.InsertCommand.Parameters[6].Value = bon.Value;
            }
            else
            {
                Adapter.InsertCommand.Parameters[6].Value = DBNull.Value;
            }
            ConnectionState state = Adapter.InsertCommand.Connection.State;
            if ((Adapter.InsertCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                Adapter.InsertCommand.Connection.Open();
            }
            try
            {
                num2 = Adapter.InsertCommand.ExecuteNonQuery();
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    Adapter.InsertCommand.Connection.Close();
                }
            }
            return num2;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(FishDataSet dataSet) =>
            Adapter.Update(dataSet, "basic_information");

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(FishDataSet.basic_informationDataTable dataTable) =>
            Adapter.Update(dataTable);

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(DataRow dataRow)
        {
            DataRow[] dataRows = new DataRow[] { dataRow };
            return Adapter.Update(dataRows);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(DataRow[] dataRows) =>
            Adapter.Update(dataRows);

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Update, true)]
        public virtual int Update(string company_name, string ceo_name, string register_number, string support_phone_number, int? home_subsidy, int? mariage_base, int? bon, int Original_id)
        {
            int num2;
            if (company_name == null)
            {
                Adapter.UpdateCommand.Parameters[0].Value = DBNull.Value;
            }
            else
            {
                Adapter.UpdateCommand.Parameters[0].Value = company_name;
            }
            if (ceo_name == null)
            {
                Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
            }
            else
            {
                Adapter.UpdateCommand.Parameters[1].Value = ceo_name;
            }
            if (register_number == null)
            {
                Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                Adapter.UpdateCommand.Parameters[2].Value = register_number;
            }
            if (support_phone_number == null)
            {
                Adapter.UpdateCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                Adapter.UpdateCommand.Parameters[3].Value = support_phone_number;
            }
            if (home_subsidy.HasValue)
            {
                Adapter.UpdateCommand.Parameters[4].Value = home_subsidy.Value;
            }
            else
            {
                Adapter.UpdateCommand.Parameters[4].Value = DBNull.Value;
            }
            if (mariage_base.HasValue)
            {
                Adapter.UpdateCommand.Parameters[5].Value = mariage_base.Value;
            }
            else
            {
                Adapter.UpdateCommand.Parameters[5].Value = DBNull.Value;
            }
            if (bon.HasValue)
            {
                Adapter.UpdateCommand.Parameters[6].Value = bon.Value;
            }
            else
            {
                Adapter.UpdateCommand.Parameters[6].Value = DBNull.Value;
            }
            Adapter.UpdateCommand.Parameters[7].Value = Original_id;
            ConnectionState state = Adapter.UpdateCommand.Connection.State;
            if ((Adapter.UpdateCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                Adapter.UpdateCommand.Connection.Open();
            }
            try
            {
                num2 = Adapter.UpdateCommand.ExecuteNonQuery();
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    Adapter.UpdateCommand.Connection.Close();
                }
            }
            return num2;
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