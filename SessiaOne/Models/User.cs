using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessiaOne.DataSetTableAdapters;
using System.Configuration;
using System.Data.SqlClient;

namespace SessiaOne.Models
{
    internal class User
    {
        public static DataSet.usersRow getUserByLogin(String login)
        {
            DataSet.usersDataTable users = initUsersDataTable();

            DataSet.usersRow user = users.Where(dataBaseUser => dataBaseUser.pin.Equals(login)).FirstOrDefault();

            return user;
        } 

        public static DataSet.usersDataTable initUsersDataTable()
        {
            usersTableAdapter tableAdapterForUsers = new usersTableAdapter();
            DataSet.usersDataTable users = new DataSet.usersDataTable();

            tableAdapterForUsers.Fill(users);

            return users;
        }

        public static int getUsersCountByCompetentionIdAndUsersRole(int id, DataSet.rolesRow role)
        {
            DataSet.usersDataTable users = initUsersDataTable();

            int count = users.Select(dataBaseUser =>  !dataBaseUser.Ischampionship_idNull() && dataBaseUser.championship_id == id && dataBaseUser.role_id.Equals(role.id)).Count();

            return count;
        }
    }
}
