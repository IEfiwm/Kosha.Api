namespace FishHoghoghi.FishDataSetTableAdapters
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics;

    [DesignerCategory("code"), ToolboxItem(true), Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), HelpKeyword("vs.data.TableAdapterManager")]
    public class TableAdapterManager : Component
    {
        private UpdateOrderOption _updateOrder;
        private LoginLogTableAdapter _loginLogTableAdapter;
        private basic_informationTableAdapter _basic_informationTableAdapter;
        private bool _backupDataSetBeforeUpdate;
        private IDbConnection _connection;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private DataRow[] GetRealUpdatedRows(DataRow[] updatedRows, List<DataRow> allAddedRows)
        {
            if (updatedRows == null || updatedRows.Length < 1)
            {
                return updatedRows;
            }
            if (allAddedRows == null || allAddedRows.Count < 1)
            {
                return updatedRows;
            }
            List<DataRow> list = new List<DataRow>();
            for (int i = 0; i < updatedRows.Length; i++)
            {
                DataRow item = updatedRows[i];
                if (!allAddedRows.Contains(item))
                {
                    list.Add(item);
                }
            }
            return list.ToArray();
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        protected virtual bool MatchTableAdapterConnection(IDbConnection inputConnection) =>
            _connection != null || (Connection == null || inputConnection == null || string.Equals(Connection.ConnectionString, inputConnection.ConnectionString, StringComparison.Ordinal));

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        protected virtual void SortSelfReferenceRows(DataRow[] rows, DataRelation relation, bool childFirst)
        {
            Array.Sort(rows, new SelfReferenceComparer(relation, childFirst));
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public virtual int UpdateAll(FishDataSet dataSet)
        {
            if (dataSet == null)
            {
                throw new ArgumentNullException("dataSet");
            }
            if (!dataSet.HasChanges())
            {
                return 0;
            }
            if (_loginLogTableAdapter != null && !MatchTableAdapterConnection(_loginLogTableAdapter.Connection))
            {
                throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
            }
            if (_basic_informationTableAdapter != null && !MatchTableAdapterConnection(_basic_informationTableAdapter.Connection))
            {
                throw new ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection string.");
            }
            IDbConnection connection = Connection;
            if (connection == null)
            {
                throw new ApplicationException("TableAdapterManager contains no connection information. Set each TableAdapterManager TableAdapter property to a valid TableAdapter instance.");
            }
            bool flag = false;
            if ((connection.State & ConnectionState.Broken) == ConnectionState.Broken)
            {
                connection.Close();
            }
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
                flag = true;
            }
            IDbTransaction transaction = connection.BeginTransaction();
            if (transaction == null)
            {
                throw new ApplicationException("The transaction cannot begin. The current data connection does not support transactions or the current state is not allowing the transaction to begin.");
            }
            List<DataRow> allChangedRows = new List<DataRow>();
            List<DataRow> allAddedRows = new List<DataRow>();
            List<DataAdapter> list3 = new List<DataAdapter>();
            Dictionary<object, IDbConnection> dictionary = new Dictionary<object, IDbConnection>();
            int num = 0;
            DataSet set = null;
            if (BackupDataSetBeforeUpdate)
            {
                set = new DataSet();
                set.Merge(dataSet);
            }
            try
            {
                if (_loginLogTableAdapter != null)
                {
                    dictionary.Add(_loginLogTableAdapter, _loginLogTableAdapter.Connection);
                    _loginLogTableAdapter.Connection = (SqlConnection)connection;
                    _loginLogTableAdapter.Transaction = (SqlTransaction)transaction;
                    if (_loginLogTableAdapter.Adapter.AcceptChangesDuringUpdate)
                    {
                        _loginLogTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
                        list3.Add(_loginLogTableAdapter.Adapter);
                    }
                }
                if (_basic_informationTableAdapter != null)
                {
                    dictionary.Add(_basic_informationTableAdapter, _basic_informationTableAdapter.Connection);
                    _basic_informationTableAdapter.Connection = (SqlConnection)connection;
                    _basic_informationTableAdapter.Transaction = (SqlTransaction)transaction;
                    if (_basic_informationTableAdapter.Adapter.AcceptChangesDuringUpdate)
                    {
                        _basic_informationTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
                        list3.Add(_basic_informationTableAdapter.Adapter);
                    }
                }
                if (UpdateOrder == UpdateOrderOption.UpdateInsertDelete)
                {
                    num += UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows);
                    num += UpdateInsertedRows(dataSet, allAddedRows);
                }
                else
                {
                    num += UpdateInsertedRows(dataSet, allAddedRows);
                    num += UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows);
                }
                num += UpdateDeletedRows(dataSet, allChangedRows);
                transaction.Commit();
                if (0 < allAddedRows.Count)
                {
                    DataRow[] array = new DataRow[allAddedRows.Count];
                    allAddedRows.CopyTo(array);
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i].AcceptChanges();
                    }
                }
                if (0 < allChangedRows.Count)
                {
                    DataRow[] array = new DataRow[allChangedRows.Count];
                    allChangedRows.CopyTo(array);
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i].AcceptChanges();
                    }
                }
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                if (BackupDataSetBeforeUpdate)
                {
                    Debug.Assert(set != null);
                    dataSet.Clear();
                    dataSet.Merge(set);
                }
                else if (0 < allAddedRows.Count)
                {
                    DataRow[] array = new DataRow[allAddedRows.Count];
                    allAddedRows.CopyTo(array);
                    for (int i = 0; i < array.Length; i++)
                    {
                        DataRow row3 = array[i];
                        row3.AcceptChanges();
                        row3.SetAdded();
                    }
                }
                throw exception;
            }
            finally
            {
                if (flag)
                {
                    connection.Close();
                }
                if (_loginLogTableAdapter != null)
                {
                    _loginLogTableAdapter.Connection = (SqlConnection)dictionary[_loginLogTableAdapter];
                    _loginLogTableAdapter.Transaction = null;
                }
                if (_basic_informationTableAdapter != null)
                {
                    _basic_informationTableAdapter.Connection = (SqlConnection)dictionary[_basic_informationTableAdapter];
                    _basic_informationTableAdapter.Transaction = null;
                }
                if (0 < list3.Count)
                {
                    DataAdapter[] array = new DataAdapter[list3.Count];
                    list3.CopyTo(array);
                    for (int i = 0; i < array.Length; i++)
                    {
                        DataAdapter adapter = array[i];
                        adapter.AcceptChangesDuringUpdate = true;
                    }
                }
            }
            return num;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private int UpdateDeletedRows(FishDataSet dataSet, List<DataRow> allChangedRows)
        {
            int num = 0;
            if (_basic_informationTableAdapter != null)
            {
                DataRow[] dataRows = dataSet.basic_information.Select(null, null, DataViewRowState.Deleted);
                if (dataRows != null && dataRows.Length != 0)
                {
                    num += _basic_informationTableAdapter.Update(dataRows);
                    allChangedRows.AddRange(dataRows);
                }
            }
            if (_loginLogTableAdapter != null)
            {
                DataRow[] dataRows = dataSet.LoginLog.Select(null, null, DataViewRowState.Deleted);
                if (dataRows != null && dataRows.Length != 0)
                {
                    num += _loginLogTableAdapter.Update(dataRows);
                    allChangedRows.AddRange(dataRows);
                }
            }
            return num;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private int UpdateInsertedRows(FishDataSet dataSet, List<DataRow> allAddedRows)
        {
            int num = 0;
            if (_loginLogTableAdapter != null)
            {
                DataRow[] dataRows = dataSet.LoginLog.Select(null, null, DataViewRowState.Added);
                if (dataRows != null && dataRows.Length != 0)
                {
                    num += _loginLogTableAdapter.Update(dataRows);
                    allAddedRows.AddRange(dataRows);
                }
            }
            if (_basic_informationTableAdapter != null)
            {
                DataRow[] dataRows = dataSet.basic_information.Select(null, null, DataViewRowState.Added);
                if (dataRows != null && dataRows.Length != 0)
                {
                    num += _basic_informationTableAdapter.Update(dataRows);
                    allAddedRows.AddRange(dataRows);
                }
            }
            return num;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private int UpdateUpdatedRows(FishDataSet dataSet, List<DataRow> allChangedRows, List<DataRow> allAddedRows)
        {
            int num = 0;
            if (_loginLogTableAdapter != null)
            {
                DataRow[] updatedRows = dataSet.LoginLog.Select(null, null, DataViewRowState.ModifiedCurrent);
                updatedRows = GetRealUpdatedRows(updatedRows, allAddedRows);
                if (updatedRows != null && updatedRows.Length != 0)
                {
                    num += _loginLogTableAdapter.Update(updatedRows);
                    allChangedRows.AddRange(updatedRows);
                }
            }
            if (_basic_informationTableAdapter != null)
            {
                DataRow[] updatedRows = dataSet.basic_information.Select(null, null, DataViewRowState.ModifiedCurrent);
                updatedRows = GetRealUpdatedRows(updatedRows, allAddedRows);
                if (updatedRows != null && updatedRows.Length != 0)
                {
                    num += _basic_informationTableAdapter.Update(updatedRows);
                    allChangedRows.AddRange(updatedRows);
                }
            }
            return num;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public UpdateOrderOption UpdateOrder
        {
            get =>
                _updateOrder;
            set =>
                _updateOrder = value;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
        public LoginLogTableAdapter LoginLogTableAdapter
        {
            get =>
                _loginLogTableAdapter;
            set =>
                _loginLogTableAdapter = value;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
        public basic_informationTableAdapter basic_informationTableAdapter
        {
            get =>
                _basic_informationTableAdapter;
            set =>
                _basic_informationTableAdapter = value;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public bool BackupDataSetBeforeUpdate
        {
            get =>
                _backupDataSetBeforeUpdate;
            set =>
                _backupDataSetBeforeUpdate = value;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), Browsable(false)]
        public IDbConnection Connection
        {
            get
            {
                if (_connection != null)
                {
                    return _connection;
                }
                if (_loginLogTableAdapter != null && _loginLogTableAdapter.Connection != null)
                {
                    return _loginLogTableAdapter.Connection;
                }
                if (_basic_informationTableAdapter != null && _basic_informationTableAdapter.Connection != null)
                {
                    return _basic_informationTableAdapter.Connection;
                }
                return null;
            }
            set =>
                _connection = value;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), Browsable(false)]
        public int TableAdapterInstanceCount
        {
            get
            {
                int num = 0;
                if (_loginLogTableAdapter != null)
                {
                    num++;
                }
                if (_basic_informationTableAdapter != null)
                {
                    num++;
                }
                return num;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private class SelfReferenceComparer : IComparer<DataRow>
        {
            private DataRelation _relation;
            private int _childFirst;

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            internal SelfReferenceComparer(DataRelation relation, bool childFirst)
            {
                _relation = relation;
                if (childFirst)
                {
                    _childFirst = -1;
                }
                else
                {
                    _childFirst = 1;
                }
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            public int Compare(DataRow row1, DataRow row2)
            {
                if (row1 == row2)
                {
                    return 0;
                }
                if (row1 == null)
                {
                    return -1;
                }
                if (row2 != null)
                {
                    int distance = 0;
                    DataRow root = GetRoot(row1, out distance);
                    int num2 = 0;
                    DataRow row = GetRoot(row2, out num2);
                    if (root == row)
                    {
                        return _childFirst * distance.CompareTo(num2);
                    }
                    Debug.Assert(root.Table != null && row.Table != null);
                    if (root.Table.Rows.IndexOf(root) < row.Table.Rows.IndexOf(row))
                    {
                        return -1;
                    }
                }
                return 1;
            }

            [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
            private DataRow GetRoot(DataRow row, out int distance)
            {
                DataRow row3;
                Debug.Assert(row != null);
                DataRow row2 = row;
                distance = 0;
                IDictionary<DataRow, DataRow> dictionary = new Dictionary<DataRow, DataRow>
                {
                    [row] = row
                };
                for (row3 = row.GetParentRow(_relation, DataRowVersion.Default); row3 != null && !dictionary.ContainsKey(row3); row3 = row3.GetParentRow(_relation, DataRowVersion.Default))
                {
                    distance++;
                    row2 = row3;
                    dictionary[row3] = row3;
                }
                if (distance == 0)
                {
                    dictionary.Clear();
                    dictionary[row] = row;
                    for (row3 = row.GetParentRow(_relation, DataRowVersion.Original); row3 != null && !dictionary.ContainsKey(row3); row3 = row3.GetParentRow(_relation, DataRowVersion.Original))
                    {
                        distance++;
                        row2 = row3;
                        dictionary[row3] = row3;
                    }
                }
                return row2;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public enum UpdateOrderOption
        {
            InsertUpdateDelete,
            UpdateInsertDelete
        }
    }
}

