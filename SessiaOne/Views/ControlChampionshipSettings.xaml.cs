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
using Microsoft.Win32;
using SessiaOne.DataSetTableAdapters;
using SessiaOne.Models;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;

namespace SessiaOne.Views
{
    public partial class ControlChampionshipSettings : UserControl
    {
        private ContentControl contentControl;
        private DataSet.competentionRow competention;
        public ControlChampionshipSettings(ContentControl contentControl, DataSet.competentionRow competention = null)
        {
            InitializeComponent();

            this.contentControl = contentControl;
            this.competention = competention;

            initComboCompetention();
            initComboMainExpert();

            if (competention != null)
            {
                buttonAdd.Visibility = Visibility.Hidden;
            }
            else
            {
                buttonChange.Visibility = Visibility.Hidden;
            }
        }

        private void initComboCompetention()
        {
            skills_combobox.ItemsSource = Skill.initSkillDataTable();
        }


        private void initComboMainExpert()
        {
            main_expert_combobox.ItemsSource = User.getUsersByRole(Role.getRoleByName(Role.ROLE_EXPERT));
        }

        private void skill_add_Click(object sender, RoutedEventArgs e)
        {
            if(skills_combobox.SelectedItem != null)
            {
                DataSet.skillRow skillRow = (skills_combobox.SelectedItem as System.Data.DataRowView).Row as DataSet.skillRow;
                if (!dataGrid.Items.Contains(skillRow))
                {
                    dataGrid.Items.Add(skillRow);
                }
                else
                {
                    MessageBox.Show("Компетенция уже присутствует");
                }
            }
        }

        private void numberFiled_GotFocus(object sender, RoutedEventArgs e)
        {
            if((sender as TextBox).Text.Contains("о") || (sender as TextBox).Text.Contains("Название чемпионата"))
            {
                (sender as TextBox).Text = "";
            }
        }

        private void numberFiled_LostFocus(object sender, RoutedEventArgs e)
        {
            if((sender as TextBox).Text == "")
            {
                (sender as TextBox).Text = getMessageForTextBox((sender as TextBox).Name);
            }
        }

        private string getMessageForTextBox(string name)
        {
            switch(name) {
                case "countMembers":
                    return "Кол-во участников";
                case "space":
                    return "S зона";
                case "countExperts":
                    return "Кол-во экспертов";
                case "area":
                    return "S чемпионата";
                case "title":
                    return "Название чемпионата";
            }
            return "";
        }

        private void numberFiled_KeyDown(object sender, KeyEventArgs e)
        {
            char digit = ((char)KeyInterop.VirtualKeyFromKey(e.Key));
            if (!char.IsDigit(digit))
            {
                e.Handled = true;
            }
        }

        private void changeLogoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image |*.png;*.jpg;*.jpeg";
            if(fileDialog.ShowDialog() == true)
            {
                logo.Source = new BitmapImage(new Uri(fileDialog.FileName));
            }
        }

        private void delete_menu_item_Click(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItem != null)
            {
                dataGrid.Items.Remove(dataGrid.SelectedItem);
            }
            else
            {
                MessageBox.Show("Сначала выберите компетенцию");
            }
        }

        private void calculateTotalArea()
        {
            string championshipArea = area.Text;
            string brifingArea = space.Text;
            try
            {
                if (numberFieldContainsText(championshipArea) || numberFieldContainsText(brifingArea))
                {
                    totalArea_label.Content = "Общая площадь S: Ошибка";
                }
                else
                {
                    int championshipAreaNumber = Int32.Parse(championshipArea);
                    int brifingAreaNumber = Int32.Parse(brifingArea);

                    totalArea_label.Content = "Общая площадь S: " + (championshipAreaNumber + brifingAreaNumber).ToString();
                }
            }
            catch
            {
                totalArea_label.Content = "Общая площадь S: Ошибка";
            }
        }

        private bool numberFieldContainsText(string text)
        {
            Regex regex = new Regex(@"[A-Za-zА-Яа-я]+");
            MatchCollection matchCollection = regex.Matches(text);

            if(matchCollection.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void area_KeyUp(object sender, KeyEventArgs e)
        {
            calculateTotalArea();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (checkFields())
            {
                string title = this.title.Text;
                DateTime date_start = DateTime.Parse(this.date_start.Text);
                DateTime date_end = DateTime.Parse(this.date_end.Text);

                ImageConverter converter = new ImageConverter();

                MemoryStream ms = new MemoryStream();
                System.Windows.Media.Imaging.BmpBitmapEncoder bbe = new BmpBitmapEncoder();
                bbe.Frames.Add(BitmapFrame.Create(new Uri(logo.Source.ToString(), UriKind.RelativeOrAbsolute)));

                bbe.Save(ms);

                byte[] image = ms.ToArray();

                Competention.insertCompetention(title, date_start, date_end, "", "", image, getSkillRowFromDataGrid());

                contentControl.Content = new ControlChampionship(contentControl);
            }
        }

        private bool checkFields()
        {
            if(title.Text == "")
            {
                MessageBox.Show("Поле названия не должно быть пустым");
                return false;
            }

            try
            {
                DateTime date_start = DateTime.Parse(this.date_start.Text);
                DateTime date_end = DateTime.Parse(this.date_end.Text);

                if(date_end < date_start)
                {
                    MessageBox.Show("Дата конца не может быть раньше даты начала");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка в датах");
                return false;
            }

            return true;
        }

        private List<DataSet.skillRow> getSkillRowFromDataGrid()
        {
            List<DataSet.skillRow> skillRows = new List<DataSet.skillRow>();

            ItemCollection itemCollection = dataGrid.Items;

            foreach(var item in itemCollection)
            {
                skillRows.Add(item as DataSet.skillRow);
            }

            return skillRows;
        }

    }
}
