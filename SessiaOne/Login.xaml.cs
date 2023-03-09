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

namespace SessiaOne
{
    public partial class Login : Window
    {
        private static Login loginWindow;
        public Login()
        {
            InitializeComponent();
            loginWindow = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            String login = Properties.Settings.Default.Login;

            if (login != null && login != "")
            {
                DataSet.usersRow currentUser = User.getUserByLogin(login);
                if(currentUser == null)
                {
                    MessageBox.Show("Пользователя с таким логином больше не существует!");
                    Properties.Settings.Default.Login = "";
                    Properties.Settings.Default.Save();
                    return;
                }
                openWindowByRole(currentUser);
            }
        }

        private void MoveWindow(object sender, RoutedEventArgs e)
        {
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Login.loginWindow.DragMove();
            }
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            usersTableAdapter tableAdapterForUsers = new usersTableAdapter();
            DataSet.usersDataTable usersDataSet = new DataSet.usersDataTable();

            String pin = textBoxPin.Text;
            String password = textBoxPassword.Text;

            tableAdapterForUsers.Fill(usersDataSet);

            DataSet.usersRow currentUser = usersDataSet.Where(dataBaseUser => dataBaseUser.pin.Equals(pin) && dataBaseUser.password.Equals(password)).FirstOrDefault();

            if(currentUser != null)
            {
                if(checkBoxRemember.IsChecked == true)
                {
                    Properties.Settings.Default.Login = currentUser.pin;
                    Properties.Settings.Default.Save();
                }
                openWindowByRole(currentUser);
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }

        }

        private void openWindowByRole(DataSet.usersRow currentUser)
        {
            DataSet.rolesRow role = Role.getRoleById(currentUser.role_id);

            if (role == null)
            {
                MessageBox.Show("Роль не найдена!");
                return;
            }

            switch (role.name)
            {
                case "Участник":
                    break;
                case "Эксперт":
                    break;
                case "Гланый эксперт":
                    break;
                case "Заместитель главного эксперта":
                    break;
                case "Технический эксперт":
                    break;
                case "Организатор":
                    openWindow(new OrganizerWindow(currentUser));
                    break;
                default:
                    MessageBox.Show("Окна для пользовател с такой ролью не существует!");
                    break;
            }
        }

        private void openWindow(Window window)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Show();
            this.Close();
        }

    }
}
