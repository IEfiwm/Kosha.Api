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
    public class MKView_FishHamkaranTableAdapter : Component
    {
        private SqlDataAdapter _adapter;
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        private SqlCommand[] _commandCollection;
        private bool _clearBeforeFill;

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        public MKView_FishHamkaranTableAdapter()
        {
            ClearBeforeFill = true;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Fill, true)]
        public virtual int Fill(FishDataSet.MKView_FishHamkaranDataTable dataTable, string NationalID, string AccountID, string Year, string Month)
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
            if (AccountID == null)
            {
                Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            else
            {
                Adapter.SelectCommand.Parameters[1].Value = AccountID;
            }
            if (Year == null)
            {
                Adapter.SelectCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                Adapter.SelectCommand.Parameters[2].Value = Year;
            }
            if (Month == null)
            {
                Adapter.SelectCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                Adapter.SelectCommand.Parameters[3].Value = Month;
            }
            if (ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return Adapter.Fill(dataTable);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Fill, false)]
        public virtual int FillByValidation(FishDataSet.MKView_FishHamkaranDataTable dataTable, string NationalID, string AccountID)
        {
            Adapter.SelectCommand = CommandCollection[1];
            if (NationalID == null)
            {
                Adapter.SelectCommand.Parameters[0].Value = DBNull.Value;
            }
            else
            {
                Adapter.SelectCommand.Parameters[0].Value = NationalID;
            }
            if (AccountID == null)
            {
                Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            else
            {
                Adapter.SelectCommand.Parameters[1].Value = AccountID;
            }
            if (ClearBeforeFill)
            {
                dataTable.Clear();
            }
            return Adapter.Fill(dataTable);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, true)]
        public virtual FishDataSet.MKView_FishHamkaranDataTable GetData(string NationalID, string AccountID, string Year, string Month)
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
            if (AccountID == null)
            {
                Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            else
            {
                Adapter.SelectCommand.Parameters[1].Value = AccountID;
            }
            if (Year == null)
            {
                Adapter.SelectCommand.Parameters[2].Value = DBNull.Value;
            }
            else
            {
                Adapter.SelectCommand.Parameters[2].Value = Year;
            }
            if (Month == null)
            {
                Adapter.SelectCommand.Parameters[3].Value = DBNull.Value;
            }
            else
            {
                Adapter.SelectCommand.Parameters[3].Value = Month;
            }
            FishDataSet.MKView_FishHamkaranDataTable dataTable = new FishDataSet.MKView_FishHamkaranDataTable();
            Adapter.Fill(dataTable);
            return dataTable;
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0"), HelpKeyword("vs.data.TableAdapter"), DataObjectMethod(DataObjectMethodType.Select, false)]
        public virtual FishDataSet.MKView_FishHamkaranDataTable GetDataByValidation(string NationalID, string AccountID)
        {
            Adapter.SelectCommand = CommandCollection[1];
            if (NationalID == null)
            {
                Adapter.SelectCommand.Parameters[0].Value = DBNull.Value;
            }
            else
            {
                Adapter.SelectCommand.Parameters[0].Value = NationalID;
            }
            if (AccountID == null)
            {
                Adapter.SelectCommand.Parameters[1].Value = DBNull.Value;
            }
            else
            {
                Adapter.SelectCommand.Parameters[1].Value = AccountID;
            }
            FishDataSet.MKView_FishHamkaranDataTable dataTable = new FishDataSet.MKView_FishHamkaranDataTable();
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
                DataSetTable = "MKView_FishHamkaran",
                ColumnMappings = {
                    {
    "کارکرد عادی",
    "کارکرد عادی"
},

{
    "کارکرد اضافه کاری",
    "کارکرد اضافه کاری"
},

{
    "کارکرد تعطیل کاری",
    "کارکرد تعطیل کاری"
},

{
    "جمعه کاری",
    "جمعه کاری"
},

{
    "کارکرد شبکاری",
    "کارکرد شبکاری"
},

{
    "کارکرد شب کاری 1",
    "کارکرد شب کاری 1"
},

{
    "کارکرد مرخصی استحقاقی",
    "کارکرد مرخصی استحقاقی"
},

{
    "کارکرد کارانه",
    "کارکرد کارانه"
},

{
    "کارکرد ساعتی",
    "کارکرد ساعتی"
},

{
    "پایه سنوات",
    "پایه سنوات"
},

{
    "حقوق پایه",
    "حقوق پایه"
},

{
    "حق اولاد",
    "حق اولاد"
},

{
    "حق اولاد معوق",
    "حق اولاد معوق"
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
    "حق خواربار",
    "حق خواربار"
},

{
    "اضافه کاری",
    "اضافه کاری"
},

{
    "تعطیل کاری",
    "تعطیل کاری"
},

{
    "شب کاری",
    "شب کاری"
},

{
    "حق شیر",
    "حق شیر"
},

{
    "شیفت",
    "شیفت"
},

{
    "شیفت ساعتی",
    "شیفت ساعتی"
},

{
    "مبلغ تناژ",
    "مبلغ تناژ"
},

{
    "تنخواه",
    "تنخواه"
},

{
    "حق سوخت",
    "حق سوخت"
},

{
    "ماموریت",
    "ماموریت"
},

{
    "فوق العاده ماموریت",
    "فوق العاده ماموریت"
},

{
    "فوق العاده سرپرستی",
    "فوق العاده سرپرستی"
},

{
    "کارانه",
    "کارانه"
},

{
    "کارانه ثابت",
    "کارانه ثابت"
},

{
    "کارانه ثابت2",
    "کارانه ثابت2"
},

{
    "سایر مزایا",
    "سایر مزایا"
},

{
    "مزایای معوقه",
    "مزایای معوقه"
},

{
    "کارانه معوق",
    "کارانه معوق"
},

{
    "فوق العاده شغل",
    "فوق العاده شغل"
},

{
    "پاداش پرسنل",
    "پاداش پرسنل"
},

{
    "ایاب و ذهاب",
    "ایاب و ذهاب"
},

{
    "معوقه حقوق",
    "معوقه حقوق"
},

{
    "بن رمضان",
    "بن رمضان"
},

{
    "هزینه جارو",
    "هزینه جارو"
},

{
    "پایه سنوات معوق",
    "پایه سنوات معوق"
},

{
    "سایر مزایای استیجاری",
    "سایر مزایای استیجاری"
},

{
    "بدهکاران کارکنان",
    "بدهکاران کارکنان"
},

{
    "بیمه تامین اجتماعی سهم کارگر",
    "بیمه تامین اجتماعی سهم کارگر"
},

{
    "بیمه تکمیلی سهم کارمند",
    "بیمه تکمیلی سهم کارمند"
},

{
    "سایر کسور",
    "سایر کسور"
},

{
    "خسارت کارکنان",
    "خسارت کارکنان"
},

{
    "کارکنان بدهکار",
    "کارکنان بدهکار"
},

{
    "مساعده",
    "مساعده"
},

{
    "تعهدات دولتی کارمند",
    "تعهدات دولتی کارمند"
},

{
    "جمع اقساط وام",
    "جمع اقساط وام"
},

{
    "تعاونی مصرف کارکنان",
    "تعاونی مصرف کارکنان"
},

{
    "مالیات حقوق",
    "مالیات حقوق"
},

{
    "جمع مزایا",
    "جمع مزایا"
},

{
    "جمع کسور",
    "جمع کسور"
},

{
    "خالص پرداختی",
    "خالص پرداختی"
},

{
    "شماره حساب",
    "شماره حساب"
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
    "کد پرسنلی",
    "کد پرسنلی"
},

{
    "نام پدر",
    "نام پدر"
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
    "تاریخ تولد",
    "تاریخ تولد"
},

{
    "نام شعبه",
    "نام شعبه"
},

{
    "سال",
    "سال"
},

{
    "ماه",
    "ماه"
},

{
    "شماره بیمه",
    "شماره بیمه"
},

{
    "کارکرد موثر",
    "کارکرد موثر"
},

{
    "پاداش",
    "پاداش"
},

{
    "تعداد اولاد",
    "تعداد اولاد"
},

{
    "مالیات",
    "مالیات"
},

{
    "بیمه تامین اجتماعی سهم کارمند",
    "بیمه تامین اجتماعی سهم کارمند"
},

{
    "دستمزد روزانه",
    "دستمزد روزانه"
},

{
    "فوق العاده جذب",
    "فوق العاده جذب"
},

{
    "فوق العاده کارایی",
    "فوق العاده کارایی"
},

{
    "معوقه دستی",
    "معوقه دستی"
},

{
    "بیمه تامین اجتماعی سهم کارفرما",
    "بیمه تامین اجتماعی سهم کارفرما"
},

{
    "بیمه بیکاری",
    "بیمه بیکاری"
},

{
    "بیمه تکمیلی سهم کارفرما",
    "بیمه تکمیلی سهم کارفرما"
},

{
    "معوقه دستی با مالیات",
    "معوقه دستی با مالیات"
},

{
    "فوق العاده خلاقیت",
    "فوق العاده خلاقیت"
},

{
    "فوق العاده پست",
    "فوق العاده پست"
},

{
    "حق ایاب و ذهاب",
    "حق ایاب و ذهاب"
},

{
    "فوق العاده منزلت شغلی",
    "فوق العاده منزلت شغلی"
},

{
    "ماموریت عادی",
    "ماموریت عادی"
},

{
    "ماموریت روز تعلیل",
    "ماموریت روز تعلیل"
},

{
    "ماموریت حومه",
    "ماموریت حومه"
},

{
    "حق غذای ماموریت حومه",
    "حق غذای ماموریت حومه"
},

{
    "احضار به کار پایین تر از 5 س",
    "احضار به کار پایین تر از 5 س"
},

{
    "احضار به کار بین 5 تا 10 س",
    "احضار به کار بین 5 تا 10 س"
},

{
    "احضار به کار بالاتر از 10 س",
    "احضار به کار بالاتر از 10 س"
},

{
    "هزینه موبایل",
    "هزینه موبایل"
},

{
    "کسر کار",
    "کسر کار"
},

{
    "حقوق گروه مشاور",
    "حقوق گروه مشاور"
},

{
    "حقوق گروه ساعتی",
    "حقوق گروه ساعتی"
},

{
    "غیبت ماهانه",
    "غیبت ماهانه"
},

{
    "احضار به کار پایین تر از 5س",
    "احضار به کار پایین تر از 5س"
},

{
    "احضار به کار بین 5 تا 10س",
    "احضار به کار بین 5 تا 10س"
},

{
    "سایر2",
    "سایر2"
},

{
    "روند حقوق",
    "روند حقوق"
},

{
    "کارکرد شب کاری",
    "کارکرد شب کاری"
},

{
    "سایر3",
    "سایر3"
},

{
    "سایر1",
    "سایر1"
},

{
    "نوبت کاری 10",
    "نوبت کاری 10"
},

{
    "ماموریت عادی نهایی",
    "ماموریت عادی نهایی"
},

{
    "ماموریت تعلیل نهایی",
    "ماموریت تعلیل نهایی"
},

{
    "کارکرد ماموریت حومه نهایی",
    "کارکرد ماموریت حومه نهایی"
},

{
    "فوق العاده در دسترسی نهایی",
    "فوق العاده در دسترسی نهایی"
}
                }
            };
            _adapter.TableMappings.Add(mapping);
        }

        [DebuggerNonUserCode, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
        private void InitCommandCollection()
        {
            _commandCollection = new SqlCommand[2];
            _commandCollection[0] = new SqlCommand();
            _commandCollection[0].Connection = Connection;
            _commandCollection[0].CommandText = "SELECT   *     \r\nFROM            MKView_FishHamkaran\r\nWHERE        ([کد ملی] = @NationalID) AND ([شماره حساب] = @AccountID) AND (سال = @Year) AND (ماه = @Month)";
            _commandCollection[0].CommandType = CommandType.Text;
            _commandCollection[0].Parameters.Add(new SqlParameter("@NationalID", SqlDbType.NVarChar, 20, ParameterDirection.Input, 0, 0, "کد ملی", DataRowVersion.Current, false, null, "", "", ""));
            _commandCollection[0].Parameters.Add(new SqlParameter("@AccountID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "شماره حساب", DataRowVersion.Current, false, null, "", "", ""));
            _commandCollection[0].Parameters.Add(new SqlParameter("@Year", SqlDbType.NVarChar, 4, ParameterDirection.Input, 0, 0, "سال", DataRowVersion.Current, false, null, "", "", ""));
            _commandCollection[0].Parameters.Add(new SqlParameter("@Month", SqlDbType.NVarChar, 2, ParameterDirection.Input, 0, 0, "ماه", DataRowVersion.Current, false, null, "", "", ""));
            _commandCollection[1] = new SqlCommand();
            _commandCollection[1].Connection = Connection;
            _commandCollection[1].CommandText = "SELECT top 1 * \r\nFROM            MKView_FishHamkaran\r\nWHERE        ([کد ملی] = @NationalID) AND ([شماره حساب] = @AccountID)";
            _commandCollection[1].CommandType = CommandType.Text;
            _commandCollection[1].Parameters.Add(new SqlParameter("@NationalID", SqlDbType.NVarChar, 20, ParameterDirection.Input, 0, 0, "کد ملی", DataRowVersion.Current, false, null, "", "", ""));
            _commandCollection[1].Parameters.Add(new SqlParameter("@AccountID", SqlDbType.NVarChar, 50, ParameterDirection.Input, 0, 0, "شماره حساب", DataRowVersion.Current, false, null, "", "", ""));
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

