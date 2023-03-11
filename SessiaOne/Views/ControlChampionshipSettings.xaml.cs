﻿using System;
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
using System.Drawing.Imaging;

namespace SessiaOne.Views
{
    public partial class ControlChampionshipSettings : UserControl
    {
        private ContentControl contentControl;
        private DataSet.competentionRow competention;
        private bool isImageChanged = false;
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
                initFieldsForCompetention();
            }
            else
            {
                buttonChange.Visibility = Visibility.Hidden;
            }
        }

        private void initFieldsForCompetention()
        {
            title.Text = competention.title;
            try
            {
                date_start.Text = competention.date_start.ToString().Split(' ')[0];
                date_end.Text = competention.date_end.ToString().Split(' ')[0];
            }
            catch
            {
                MessageBox.Show("Ошибка. Не удалось преобразовать даты");
            }

            if(!competention.IsimageNull())
            {
                try
                {
                    System.Drawing.Image image = convertByteToImage(competention.image);
                    logo.Source = convertImageToBitmapImage(image); 
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            List<DataSet.skillRow> skillRows = Competention.getSkillsForCompetention(competention.id);

            foreach(DataSet.skillRow skillRow in skillRows)
            {
                dataGrid.Items.Add(skillRow);
            }
        }

        public BitmapImage convertImageToBitmapImage(System.Drawing.Image img)
        {
            using (var memory = new MemoryStream())
            {
                img.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        private void buttonChange_Click(object sender, RoutedEventArgs e)
        {
            if (checkFields())
            {
                string title = this.title.Text;
                DateTime date_start = DateTime.Parse(this.date_start.Text);
                DateTime date_end = DateTime.Parse(this.date_end.Text);

                byte[] image = null;

                if (isImageChanged)
                {
                    MemoryStream ms = new MemoryStream();
                    System.Windows.Media.Imaging.BmpBitmapEncoder bbe = new BmpBitmapEncoder();
                    bbe.Frames.Add(BitmapFrame.Create(new Uri(logo.Source.ToString(), UriKind.RelativeOrAbsolute)));

                    bbe.Save(ms);

                    image = ms.ToArray();
                }
                else
                {
                    if(!competention.IsimageNull())
                    {
                        image = competention.image;
                    }
                }

                Competention.updateCompetention(title, date_start, date_end, "", "", image, getSkillRowFromDataGrid(), competention.id);

                contentControl.Content = new ControlChampionship(contentControl);
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
                isImageChanged = true;
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

                MemoryStream ms = new MemoryStream();
                System.Windows.Media.Imaging.BmpBitmapEncoder bbe = new BmpBitmapEncoder();
                bbe.Frames.Add(BitmapFrame.Create(new Uri(logo.Source.ToString(), UriKind.RelativeOrAbsolute)));

                bbe.Save(ms);

                byte[] image = ms.ToArray();

                Competention.insertCompetention(title, date_start, date_end, "", "", image, getSkillRowFromDataGrid());

                contentControl.Content = new ControlChampionship(contentControl);
            }
        }

        private System.Drawing.Image convertByteToImage(byte[] byteImage)
        {
            MemoryStream ms = new MemoryStream(byteImage);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

            return image;
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
