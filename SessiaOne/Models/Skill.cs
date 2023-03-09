using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessiaOne.DataSetTableAdapters;
using SessiaOne.Models;
namespace SessiaOne.Models
{
    internal class Skill
    {
        public static DataSet.skillDataTable initSkillDataTable()
        {
            skillTableAdapter skillTableAdapter = new skillTableAdapter();
            DataSet.skillDataTable skillDataTable = new DataSet.skillDataTable();

            skillTableAdapter.Fill(skillDataTable);

            return skillDataTable;
        }

        public static DataSet.skillRow getSkillByTitle(string title)
        {
            DataSet.skillDataTable skillDataTable = initSkillDataTable();

            DataSet.skillRow skillRow = skillDataTable.Where(s => s.title.Equals(title)).FirstOrDefault();

            return skillRow;
        }

    }
}
