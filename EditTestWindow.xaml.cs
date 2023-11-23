using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Xml.Linq;
using TestClient.Dictionary;
using TestClient.RequestProvider;
using TestClient.ServiceProvider;
using TestClient.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace TestClient
{
    /// <summary>
    /// Логика взаимодействия для EditTestWindow.xaml
    /// </summary>
    public partial class EditTestWindow : Window
    {
       
        public EditTestWindow(string testId)
        {
            InitializeComponent();
            DataContext = new QuestionViewModel(testId);
        }
    }
}
