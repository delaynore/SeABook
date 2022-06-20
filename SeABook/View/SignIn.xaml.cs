using SeABook.Model.DataBase;
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

namespace SeABook.View
{
    public partial class SignIn : Window
    {
        private SBDataBase DataBase;
        public SignIn(SBDataBase db)
        {
            InitializeComponent();
            DataBase = db;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newReader = new Reader
            {
                Name = nameTextBox.Text,
                Surname = surnameTextBox.Text,
                Fathername = fathernameTextBox.Text
            };
            var newAcc = new Account
            {
                Login = loginTextBox.Text,
                Password = passwordTextBox.Text,
                User = newReader
            };
            DataBase.Accounts.Add(newAcc);
            DataBase.Readers.Add(newReader);
            DataBase.SaveChanges();
            MessageBox.Show("Поздравляем! Вы успешно зарегистрировались в системе!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
