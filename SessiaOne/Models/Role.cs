using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessiaOne.DataSetTableAdapters;

namespace SessiaOne.Models
{
    internal class Role
    {
        public static string ROLE_MEMBER = "Участник";
        public static string ROLE_EXPERT = "Эксперт";

        public static DataSet.rolesRow getRoleById(int id)
        {
            DataSet.rolesDataTable rolesRows = initRolesDataTable();

            DataSet.rolesRow role = rolesRows.Where(dataBaseRole => dataBaseRole.id.Equals(id)).FirstOrDefault();

            return role;
        }

        public static DataSet.rolesRow getRoleByName(String name)
        {
            DataSet.rolesDataTable rolesRows = initRolesDataTable();

            DataSet.rolesRow role = rolesRows.Where(dataBaseRole => dataBaseRole.name.Equals(name)).FirstOrDefault();

            return role;
        }

        private static DataSet.rolesDataTable initRolesDataTable()
        {
            rolesTableAdapter rolesTableAdapter = new rolesTableAdapter();
            DataSet.rolesDataTable rolesRows = new DataSet.rolesDataTable();

            rolesTableAdapter.Fill(rolesRows);

            return rolesRows;
        }
    }
}
