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

            competentionTableAdapter.InsertCompetention(title, date_start, date_end, description, city, image);

            int competention_id = (int)competentionTableAdapter.GetLastInsertID();

            competention_skillTableAdapter competention_SkillTableAdapter = new competention_skillTableAdapter();

            foreach (DataSet.skillRow skillRow in skillRows)
            {
                competention_SkillTableAdapter.Insert(competention_id, skillRow.id);
            }
        }

        public static void updateCompetention(string title, DateTime date_start, DateTime date_end, string description, string city, byte[] image, List<DataSet.skillRow> skillRows, int original_id)
        {
            competentionTableAdapter competentionTableAdapter = new competentionTableAdapter();

            competentionTableAdapter.UpdateCompetention(title, date_start, date_end, description, city, image, original_id);

            competention_skillTableAdapter competention_SkillTableAdapter = new competention_skillTableAdapter();

            clearSkillsForCompetention(original_id);

            foreach (DataSet.skillRow skillRow in skillRows)
            {
                competention_SkillTableAdapter.Insert(original_id, skillRow.id);
            }
        }

        public static void clearSkillsForCompetention(int competention_id)
        {
            competention_skillTableAdapter competention_SkillTableAdapter = new competention_skillTableAdapter();

            List<DataSet.competention_skillRow> competention_SkillRows = CompetentionSkill.initCompetentionSkillDataTable().Where(c => c.competention_id.Equals(competention_id)).ToList();

            foreach(DataSet.competention_skillRow competention_SkillRow in competention_SkillRows)
            {
                var test = competention_SkillRow.id;
                competention_SkillTableAdapter.DeleteSkillForCompetention(competention_SkillRow.id);
            }
        }

        public static List<DataSet.skillRow> getSkillsForCompetention(int competention_id)
        {
            List<DataSet.competention_skillRow> competention_skills = CompetentionSkill.initCompetentionSkillDataTable().Where(dataBaseCompetention_Skill => dataBaseCompetention_Skill.competention_id.Equals(competention_id)).ToList();

            List<DataSet.skillRow> skills = new List<DataSet.skillRow>();

            DataSet.skillDataTable skillRows = Skill.initSkillDataTable();

            foreach(DataSet.competention_skillRow competention_SkillRow in competention_skills)
            {
                var skill = skillRows.Where(s => s.id.Equals(competention_SkillRow.skill_id)).FirstOrDefault();
                if(skill != null)
                {
                    skills.Add(skill);
                }
            }

            return skills;
        }
    }
}
