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

namespace TestClient
{
    /// <summary>
    /// Логика взаимодействия для EditTestWindow.xaml
    /// </summary>
    public partial class EditTestWindow : Window
    {

        private string testId;
        private string qId = string.Empty;
        GetListsProvider glp = new GetListsProvider();
        public EditTestWindow(string testId)
        {
            InitializeComponent();
            GetListsProvider.answerList.Clear();
            this.testId = testId;
            QuestionListBox.ItemsSource = GetListsProvider.questiontList;
            AnswerListBox.ItemsSource = GetListsProvider.answerList;
            this.Closed += MainWindow_Closed;
        }
        public void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            RequestAdd ra = new RequestAdd();
            ra.Question(AddQuestionBox.Text, testId);
        }
        public void EditQuestion_Click(object sender, RoutedEventArgs e)
        {
            RequestEdit re = new RequestEdit();
            re.Questions(sender);
        }
        public void RemoveQuestion_Click(object sender, RoutedEventArgs e)
        {
            RequestRemove rr = new RequestRemove();
            rr.Questions(sender);
        }
        public void SelectQuestion_Click(object sender, RoutedEventArgs e)
        {
            var listBox = sender as System.Windows.Controls.ListBox;
            var element = listBox.SelectedItem as Questions;
            if (element != null)
            {
                qId = element.Id;
            }
            if (!String.IsNullOrEmpty(qId))
            {
                glp.GetAnswers(qId);
            }
            
        }
        public void AddAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(qId))
            {
                RequestAdd ra = new RequestAdd();
                ra.Answer(AddAnswerBox.Text, qId, TrueAnswerCheckBox.IsChecked.ToString());
            }
            else
            {
                MessageBox.Show("Выберите вопрос!");
            }
        }
        public void EditAnswer_Click(object sender, RoutedEventArgs e)
        {
            RequestEdit re = new RequestEdit();
            re.Answers(sender);
        }
        public void RemoveAnswer_Click(object sender, RoutedEventArgs e)
        {
            RequestRemove rr = new RequestRemove();
            rr.Answers(sender);
        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
          
        }
    }
}
