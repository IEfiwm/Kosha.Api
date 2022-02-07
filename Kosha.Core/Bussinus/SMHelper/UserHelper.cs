﻿using Kosha.Core.Bussinus.SMHelper.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kosha.Core.Bussinus.SMHelper
{
    public class UserHelper : IUserHelper
    {
        public DataRow GetUserById(string userId, out DataTable table)
        {
            table = DataAccessObject.ExecuteCommand($@"SELECT  * FROM [identity].Users
                    INNER JOIN
                    SM.Basic.TbBankAccount ON TbBankAccount.Id = SM.[Identity].Users.BankAccountRef
                    where [identity].Users.Id =  N'{userId}' ");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }

        public DataRow GetUserByNumber(string number, out DataTable table)
        {

            table = DataAccessObject.ExecuteCommand($@"SELECT * FROM [identity].Users where PhoneNumber = N'{number}' ");

            if (table.Rows.Count == 0)
                return null;

            return table.Rows[0];
        }
    }
}
