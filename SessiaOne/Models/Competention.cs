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
            int count = CompetentionSkill.initCompetentionSkillDataTable().Where(dataBaseCompetention_Skill => dataBaseCompetention_Skill.competention_id == id).Count();

            return count;
        }

        public static DataSet.competentionDataTable initCompetentionDataTable()
        {
            competentionTableAdapter competentionTableAdapter = new competentionTableAdapter();
            DataSet.competentionDataTable competentionRows = new DataSet.competentionDataTable();

            competentionTableAdapter.Fill(competentionRows);

            return competentionRows;
        }


        public static void insertCompetention(string title, DateTime date_start, DateTime date_end, string description, string city, byte[] image, List<DataSet.skillRow> skillRows)
        {
            competentionTableAdapter competentionTableAdapter = new competentionTableAdapter();

            int competention_id = competentionTableAdapter.InsertCompetention(title, date_start, date_end, description, city, image);

            competention_skillTableAdapter competention_SkillTableAdapter = new competention_skillTableAdapter();

            foreach (DataSet.skillRow skillRow in skillRows)
            {
                competention_SkillTableAdapter.Insert(competention_id, skillRow.id);
            }
        }
    }
}
