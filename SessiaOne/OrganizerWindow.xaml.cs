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
using SessiaOne.Views;

namespace SessiaOne
{

    public partial class OrganizerWindow : Window
    {
        private DataSet.usersRow user;
        public OrganizerWindow(DataSet.usersRow loginUser)
        {
            InitializeComponent();
            this.user = loginUser;

            setHelloMessage();

            setButtonsDefaultColorBlue();

            contentControl.Content = new ControlChampionship(contentControl);

            setButtonBackgroundColor(buttonChampionship, Colors.Green);
        }

        private void setHelloMessage()
        {
            String currentHelloTimeType = "Доброе утро";

            DateTime currentDateTime = DateTime.Now;

            DateTime periodDayStart = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 11, 1, 0);
            DateTime periodDayEnd = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 17, 59, 0);

            DateTime periodEveningStart = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 18, 0, 0);
            DateTime periodEveningEnd = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 23, 0, 0);


            DateTime periodNightStart = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, 23, 1, 0);
            DateTime periodNightEnd = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day + 1, 5, 59, 0);

            if (periodDayStart <= currentDateTime && currentDateTime <= periodDayEnd)
            {
                currentHelloTimeType = "Добрый день";
            }
            else if (periodEveningStart <= currentDateTime && currentDateTime <= periodEveningEnd)
            {
                currentHelloTimeType = "Добрый вечер";
            }
            else if (periodNightStart <= currentDateTime && currentDateTime <= periodNightEnd)
            {
                currentHelloTimeType = "Доброй ночи";
            }

            labelHelloMessage.Content = $"{currentHelloTimeType}, {this.user.fio}";
        }

        private void setButtonBackgroundColor(Button button, Color color)
        {
            button.Background = new SolidColorBrush(color);
        }

        private void setButtonsDefaultColorBlue()
        {
            SolidColorBrush defaultColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#486cc4"));

            buttonChampionship.Background = defaultColor;
            buttonProtocols.Background = defaultColor;
            buttonExpertUsage.Background = defaultColor;
            buttonChampionshipSettings.Background = defaultColor;
        }

        private void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Login = "";
            Properties.Settings.Default.Save();
            openWindow(new Login());
        }

        private void openWindow(Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Show();
            this.Close();
        }

        private void buttonChampionship_Click(object sender, RoutedEventArgs e)
        {
            setButtonsDefaultColorBlue();

            contentControl.Content = new ControlChampionship(contentControl);

            setButtonBackgroundColor(sender as Button, Colors.Green);
        }

        private void buttonChampionshipSettings_Click(object sender, RoutedEventArgs e)
        {
            setButtonsDefaultColorBlue();

            contentControl.Content = new ControlChampionshipSettings(contentControl);

            setButtonBackgroundColor(sender as Button, Colors.Green);
        }

        private void buttonExpertUsage_Click(object sender, RoutedEventArgs e)
        {
            setButtonsDefaultColorBlue();

            contentControl.Content = new ControlExpertUsage();

            setButtonBackgroundColor(sender as Button, Colors.Green);
        }

        private void buttonProtocols_Click(object sender, RoutedEventArgs e)
        {
            setButtonsDefaultColorBlue();

            contentControl.Content = new ControlProtocols();

            setButtonBackgroundColor(sender as Button, Colors.Green);
        }
    }
}
