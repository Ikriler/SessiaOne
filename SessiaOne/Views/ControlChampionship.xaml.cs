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
using SessiaOne.ModalWindows;
using SessiaOne.Models;

namespace SessiaOne.Views
{
    public partial class ControlChampionship : UserControl
    {
        private ContentControl contentControl;
        public ControlChampionship(ContentControl contentControl)
        {
            InitializeComponent();
            initDataTable();
            this.contentControl = contentControl;
        }

        private void initDataTable()
        {
            competentionTableAdapter tableAdapterForCompetention = new competentionTableAdapter();
            DataSet.competentionDataTable competentionRows = new DataSet.competentionDataTable();

            tableAdapterForCompetention.Fill(competentionRows);

            gridChampionship.Items.Clear();
            gridChampionship.ItemsSource = competentionRows.Reverse();

        }

        private void gridChampionship_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            openInfoWindow(sender);
        }

        private void openInfoWindow(object sender)
        {
            if (sender != null)
            {
                DataGrid grid = gridChampionship;

                if (grid != null && grid.SelectedItem != null && grid.SelectedItems.Count == 1)
                {
                    DataSet.competentionRow competentionDataGridRow = (grid.SelectedItem as System.Data.DataRowView).Row as DataSet.competentionRow;

                    ChampionshipInformation championshipInformationWindow = new ChampionshipInformation(competentionDataGridRow);
                    championshipInformationWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    championshipInformationWindow.Show();
                }
            }
        }

        private void changeChampionship_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = gridChampionship;

                if (grid != null && grid.SelectedItem != null && grid.SelectedItems.Count == 1)
                {
                    DataSet.competentionRow competentionDataGridRow = (grid.SelectedItem as System.Data.DataRowView).Row as DataSet.competentionRow;

                    contentControl.Content = new ControlChampionshipSettings(contentControl, competentionDataGridRow);
                }
            }
        }

        private void seeInfoChampionsip_Click(object sender, RoutedEventArgs e)
        {
            openInfoWindow(sender);
        }
    }
}
