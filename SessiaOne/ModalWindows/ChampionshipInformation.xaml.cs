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
using System.Windows.Shapes;
using SessiaOne.DataSetTableAdapters;
using SessiaOne.Models;

namespace SessiaOne.ModalWindows
{
    public partial class ChampionshipInformation : Window
    {
        private DataSet.competentionRow competentionRow;

        private static ChampionshipInformation championshipInformationWindow;
        public ChampionshipInformation(DataSet.competentionRow competentionRow)
        {
            InitializeComponent();

            this.competentionRow = competentionRow;

            championshipInformationWindow = this;

            initFields();
        }

        private void initFields()
        {
            this.championshipName.Text = competentionRow.title;
            this.championshipDates.Content = competentionRow.date_start + " - " + competentionRow.date_end;
            this.championshipCity.Content = competentionRow.city;
            this.championshipDesctiption.Text = competentionRow.description;
            this.championshipMembersCount.Content = User.getUsersCountByCompetentionIdAndUsersRole(competentionRow.id, Role.getRoleByName(Role.ROLE_MEMBER));
            this.championshipExpertsCount.Content = User.getUsersCountByCompetentionIdAndUsersRole(competentionRow.id, Role.getRoleByName(Role.ROLE_EXPERT));
            this.championshipCompetentionsCount.Content = Competention.getCountSkillsByCompetentionId(competentionRow.id);
        }
        private void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                ChampionshipInformation.championshipInformationWindow.DragMove();
            }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
