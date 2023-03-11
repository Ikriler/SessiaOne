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
        public string fio { get; set; }
        public string gender { get; set; }
        public string competention { get; set; }
        public DateTime db_date { get; set; }


        public static DataSet.usersDataTable users;

        User(string fio, string gender, string competention, DateTime db_date)
        {
            this.fio = fio;
            this.gender = gender;
            this.competention = competention;
            this.db_date = db_date;
        }

        public static DataSet.usersRow getUserByLogin(String login)
        {
            users = users ?? initUsersDataTable();

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
            users = users ?? initUsersDataTable();

            int count = users.Select(dataBaseUser =>  !dataBaseUser.Ischampionship_idNull() && dataBaseUser.championship_id == id && dataBaseUser.role_id.Equals(role.id)).Count();

            return count;
        }

        public static List<DataSet.usersRow> getUsersByRole(DataSet.rolesRow role)
        {
            DataSet.usersDataTable users = initUsersDataTable();

            List<DataSet.usersRow> usersList = users.Where(u => u.role_id.Equals(role.id)).ToList();

            return usersList;
        }

        public static List<User> getExpertsList()
        {
            users = users ?? initUsersDataTable();

            List<User> experts = new List<User>();

            DataSet.rolesRow expertRole = Role.getRoleByName(Role.ROLE_EXPERT);

            List<DataSet.usersRow> usersRows = users.Where(u => u.role_id.Equals(expertRole.id)).ToList();

            foreach(DataSet.usersRow user in usersRows)
            {
                string skill = Skill.getTitleSkillById(user.skill_id);
                User expert = new User(user.fio, user.gender, skill, user.db_date);

                experts.Add(expert);
            }

            return experts;
        }
    }
}
