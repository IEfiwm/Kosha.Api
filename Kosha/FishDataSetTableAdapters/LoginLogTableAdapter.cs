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
    public class LoginLogTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        private SqlCommand[] _commandCollection;
        private bool _clearBeforeFill;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public LoginLogTableAdapter()
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
        public virtual int Fill(FishDataSet.LoginLogDataTable dataTable)
        {
            Adapter.SelectCommand = CommandCollection[0];
            if (ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return Adapter.Fill(dataTable);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, true)]
        public virtual FishDataSet.LoginLogDataTable GetData()
        {
            Adapter.SelectCommand = CommandCollection[0];
            FishDataSet.LoginLogDataTable dataTable = new FishDataSet.LoginLogDataTable();
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
                DataSetTable = "LoginLog",
                ColumnMappings = {
                    {
                        "id",
                        "id"
                    },
                    {
                        "username",
                        "username"
                    },
                    {
                        "login_at",
                        "login_at"
                    },
                    {
                        "mac_address",
                        "mac_address"
                    }
                }
            };
            _adapter.TableMappings.Add(mapping);
            _adapter.DeleteCommand = new SqlCommand();
            _adapter.DeleteCommand.Connection = Connection;
            _adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LoginLog] WHERE (([id] = @Original_id))";
            _adapter.DeleteCommand.CommandType = CommandType.Text;
            _adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Original, false, null, "", "", ""));
            _adapter.InsertCommand = new SqlCommand();
            _adapter.InsertCommand.Connection = Connection;
            _adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[LoginLog] ([username], [login_at], [mac_address]) VALUES (@username, @login_at, @mac_address)";
            _adapter.InsertCommand.CommandType = CommandType.Text;
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "username", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@login_at", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "login_at", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.InsertCommand.Parameters.Add(new SqlParameter("@mac_address", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "mac_address", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand = new SqlCommand();
            _adapter.UpdateCommand.Connection = Connection;
            _adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LoginLog] SET [username] = @username, [login_at] = @login_at, [mac_address] = @mac_address WHERE (([id] = @Original_id))";
            _adapter.UpdateCommand.CommandType = CommandType.Text;
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "username", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@login_at", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "login_at", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@mac_address", SqlDbType.NChar, 0, ParameterDirection.Input, 0, 0, "mac_address", DataRowVersion.Current, false, null, "", "", ""));
            _adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_id", SqlDbType.Int, 0, ParameterDirection.Input, 0, 0, "id", DataRowVersion.Original, false, null, "", "", ""));
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private void InitCommandCollection()
        {
            _commandCollection = new SqlCommand[2];
            _commandCollection[0] = new SqlCommand();
            _commandCollection[0].Connection = Connection;
            _commandCollection[0].CommandText = "SELECT * FROM dbo.LoginLog;";
            _commandCollection[0].CommandType = CommandType.Text;
            _commandCollection[1] = new SqlCommand();
            _commandCollection[1].Connection = Connection;
            _commandCollection[1].CommandText = "INSERT INTO [dbo].[LoginLog] ([username], [login_at], [mac_address]) VALUES (@username, @login_at, @mac_address)";
            _commandCollection[1].CommandType = CommandType.Text;
            _commandCollection[1].Parameters.Add(new SqlParameter("@username", SqlDbType.NChar, 20, ParameterDirection.Input, 0, 0, "username", DataRowVersion.Current, false, null, "", "", ""));
            _commandCollection[1].Parameters.Add(new SqlParameter("@login_at", SqlDbType.NChar, 20, ParameterDirection.Input, 0, 0, "login_at", DataRowVersion.Current, false, null, "", "", ""));
            _commandCollection[1].Parameters.Add(new SqlParameter("@mac_address", SqlDbType.NChar, 50, ParameterDirection.Input, 0, 0, "mac_address", DataRowVersion.Current, false, null, "", "", ""));
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private void InitConnection()
        {
            _connection = new SqlConnection();
            _connection.ConnectionString = ConfigurationManager.ConnectionStrings["Sg3ConnectionString"].ConnectionString;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Insert, true)]
        public virtual int Insert(string username, string login_at, string mac_address)
        {
            int num2;
            if (username == null)
            {
                Adapter.InsertCommand.Parameters[0].Value = DBNull.Value;
            }
            else
            {
                Adapter.InsertCommand.Parameters[0].Value = username;
            }
            if (login_at == null)
            {
                Adapter.InsertCommand.Parameters[1].Value = DBNull.Value;
            }
            else
            {
                Adapter.InsertCommand.Parameters[1].Value = login_at;
            }
            if (mac_address == null)
            {
                Adapter.InsertCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                Adapter.InsertCommand.Parameters[2].Value = mac_address;
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

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Insert, false)]
        public virtual int InsertQuery(string username, string login_at, string mac_address)
        {
            int num;
            SqlCommand command = CommandCollection[1];
            if (username == null)
            {
                command.Parameters[0].Value = DBNull.Value;
            }
            else
            {
                command.Parameters[0].Value = username;
            }
            if (login_at == null)
            {
                command.Parameters[1].Value = DBNull.Value;
            }
            else
            {
                command.Parameters[1].Value = login_at;
            }
            if (mac_address == null)
            {
                command.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                command.Parameters[2].Value = mac_address;
            }
            ConnectionState state = command.Connection.State;
            if ((command.Connection.State & ConnectionState.Open) != ConnectionState.Open)
            {
                command.Connection.Open();
            }
            try
            {
                num = command.ExecuteNonQuery();
            }
            finally
            {
                if (state == ConnectionState.Closed)
                {
                    command.Connection.Close();
                }
            }
            return num;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(FishDataSet dataSet) =>
            Adapter.Update(dataSet, "LoginLog");

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter")]
        public virtual int Update(FishDataSet.LoginLogDataTable dataTable) =>
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
        public virtual int Update(string username, string login_at, string mac_address, int Original_id)
        {
            int num2;
            if (username == null)
            {
                Adapter.UpdateCommand.Parameters[0].Value = DBNull.Value;
            }
            else
            {
                Adapter.UpdateCommand.Parameters[0].Value = username;
            }
            if (login_at == null)
            {
                Adapter.UpdateCommand.Parameters[1].Value = DBNull.Value;
            }
            else
            {
                Adapter.UpdateCommand.Parameters[1].Value = login_at;
            }
            if (mac_address == null)
            {
                Adapter.UpdateCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                Adapter.UpdateCommand.Parameters[2].Value = mac_address;
            }
            Adapter.UpdateCommand.Parameters[3].Value = Original_id;
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