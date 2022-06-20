using Microsoft.EntityFrameworkCore;
using SeABook.Model;
using SeABook.Model.DataBase;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SeABook.View
{

    public partial class LogIn : Window
    {
        private SBDataBase database;
        private MainWindow mainWindow;
        public LogIn()
        {
            InitializeComponent();
            database = new SBDataBase();
        }

        private void OpenSignIn(object sender, MouseButtonEventArgs e)
        {
            new SignIn(database).ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(passwordTextBox.Password.Length == 0)
            {
                MessageBox.Show("Введите пароль!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var user = database.Accounts.Include(x=>x.User).FirstOrDefault(x => x.Login == loginTextBox.Text && x.Password == passwordTextBox.Password);
            if (user == null)
            {
                MessageBox.Show("Введены неправильные данные!","Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show($"Добро пожалоловать, {user.User.Name} {user.User.Surname}!", "Успешно", MessageBoxButton.OK);
            Hide();
            CurrentUser.UpdateUser(user.User);
            mainWindow = new MainWindow();
        }

    }
}
