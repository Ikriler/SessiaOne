using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessiaOne.DataSetTableAdapters;

namespace SessiaOne.Models
{
    internal class Competention
    {
        public static DataSet.competentionRow getCompetentionById(int id)
        {
            DataSet.competentionDataTable competentionRows = initCompetentionDataTable();

            DataSet.competentionRow competentionRow = competentionRows.Where(dataBaseCompetention => dataBaseCompetention.id.Equals(id)).FirstOrDefault();

            return competentionRow;
        }

        public static int getCountSkillsByCompetentionId(int id)
        {
            competention_skillTableAdapter competention_SkillTableAdapter = new competention_skillTableAdapter();
            DataSet.competention_skillDataTable competention_SkillRows = new DataSet.competention_skillDataTable();

            competention_SkillTableAdapter.Fill(competention_SkillRows);

            int count = competention_SkillRows.Where(dataBaseCompetention_Skill => dataBaseCompetention_Skill.competention_id == id).Count();

            return count;
        }

        private static DataSet.competentionDataTable initCompetentionDataTable()
        {
            competentionTableAdapter competentionTableAdapter = new competentionTableAdapter();
            DataSet.competentionDataTable competentionRows = new DataSet.competentionDataTable();

            competentionTableAdapter.Fill(competentionRows);

            return competentionRows;
        }

    }
}
