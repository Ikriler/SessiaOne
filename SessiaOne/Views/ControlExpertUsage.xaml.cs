using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SessiaOne.DataSetTableAdapters;
using SessiaOne.Models;

namespace SessiaOne.Views
{
    public partial class ControlExpertUsage : UserControl
    {
        public ControlExpertUsage()
        {
            InitializeComponent();
            initComboBoxes();
            initExpertsDataGrid();
        }

        private void initComboBoxes()
        {
            List<string> skillsTitles = Skill.getSkillsTitles();

            skillsTitles = skillsTitles.Prepend("Все").ToList();

            List<string> gender = new List<string>();

            gender.Add("Все");
            gender.Add("м");
            gender.Add("ж");

            gender_combobox.ItemsSource = gender;
            skills_combobox.ItemsSource = skillsTitles;
        }

        private void search()
        {
            string defaultFilter = "Все";

            string searchFio = fio.Text;
            string searchGender = gender_combobox.SelectedItem == null ? defaultFilter : gender_combobox.SelectedItem.ToString();
            string searchSkill = skills_combobox.SelectedItem == null ? defaultFilter : skills_combobox.SelectedItem.ToString();


            List<Predicate<User>> filter = new List<Predicate<User>>();

            if(searchFio != "")
            {
                filter.Add(u => u.fio.Contains(searchFio));
            }
            if(searchGender != "Все")
            {
                filter.Add(u => u.gender.Equals(searchGender));
            }
            if(searchSkill != "Все")
            {
                filter.Add(u => u.competention.Equals(searchSkill));
            }


            dataGrid.Items.Filter = delegate(object o)
            {
                var item = o as User;

                return filter.TrueForAll(x => x(item));
            };
        }

        private void initExpertsDataGrid()
        {
            dataGrid.ItemsSource = User.getExpertsList();
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            gender_combobox.SelectedIndex = 0;
            skills_combobox.SelectedIndex = 0;
            fio.Text = "";

            search();
        }

        private void fio_KeyDown(object sender, KeyEventArgs e)
        {
            search();
        }

        private void skills_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            search();
        }

        private void gender_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            search();
        }
    }
}
