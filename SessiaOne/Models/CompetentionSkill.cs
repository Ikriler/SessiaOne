using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SessiaOne.DataSetTableAdapters;
using SessiaOne.Models;

namespace SessiaOne.Models
{
    internal class CompetentionSkill
    {
        public static DataSet.competention_skillDataTable initCompetentionSkillDataTable()
        {
            competention_skillTableAdapter competention_SkillTableAdapter = new competention_skillTableAdapter();
            DataSet.competention_skillDataTable competention_SkillRows = new DataSet.competention_skillDataTable();

            competention_SkillTableAdapter.Fill(competention_SkillRows);

            return competention_SkillRows;
        }
    }
}
