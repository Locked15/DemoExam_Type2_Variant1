using System;
using System.Windows;
using System.Threading;
using Пиши_Стирай.Classes;

namespace Пиши_Стирай.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private Int32 errorCount = 0;

        public String UserName { get; set; }

        public String UserPassword { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void LoginButton_Click(Object sender, RoutedEventArgs e)
        {
            if (SessionData.TryToLoginInAccount(UserName, UserPassword))
            {
                GoToNextWindowAfterLogin();
            }

            else
            {
                ++errorCount;

                if (errorCount > 2)
                {
                    Title = "Блокировка...";
                    MessageBox.Show($"Слишком много неудачных входов ({errorCount}).\n\nБлокировка...", 
                                     "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

                    Thread.Sleep(20000);

                    Title = "Авторизация — Пиши-Стирай";
                }

                else
                {
                    MessageBox.Show("Указанный аккаунт не найден.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error); 
                }
            }
        }

        private void GuestButton_Click(Object sender, RoutedEventArgs e)
        {
            SessionData.ContinueAsGuest();
            GoToNextWindowAfterLogin();
        }

        private void GoToNextWindowAfterLogin()
        {
            ProductsWindow nextStage = new ProductsWindow();

            nextStage.Show();
            Close();
        }
    }
}
