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
        public static DataSet.skillDataTable skillDataTable;
        public static DataSet.skillDataTable initSkillDataTable()
        {
            skillTableAdapter skillTableAdapter = new skillTableAdapter();
            skillDataTable = new DataSet.skillDataTable();

            skillTableAdapter.Fill(skillDataTable);

            return skillDataTable;
        }

        public static DataSet.skillRow getSkillByTitle(string title)
        {
            skillDataTable = skillDataTable ?? initSkillDataTable();

            DataSet.skillRow skillRow = skillDataTable.Where(s => s.title.Equals(title)).FirstOrDefault();

            return skillRow;
        }


        public static string getTitleSkillById(int skill_id)
        {
            skillDataTable = skillDataTable ?? initSkillDataTable();

            DataSet.skillRow skillRow = skillDataTable.Where(s => s.id.Equals(skill_id)).FirstOrDefault();

            string title = skillRow != null ? skillRow.title : "";

            return title;
        }

        public static List<string> getSkillsTitles()
        {
            skillDataTable = skillDataTable ?? initSkillDataTable();

            List<string> titles = skillDataTable.Select(s => s.title).ToList();

            return titles;
        }
    }
}
