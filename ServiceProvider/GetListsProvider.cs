using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestClient.Dictionary;
using TestClient.DictionaryService;
using TestClient.ServerProvider;
namespace TestClient.ServiceProvider
{
    internal class GetListsProvider
    {
        public static ObservableCollection<Test> testList = new ObservableCollection<Test>();
        public static ObservableCollection<Questions> questiontList = new ObservableCollection<Questions>();
        public static ObservableCollection<Answers> answerList = new ObservableCollection<Answers>();
        public async void GetTests()
        {
            testList.Clear();
            RequestService rs = new RequestService
            {
                type = "[GET]",
                dict = "Tests",
                text = "",
                options = ""
            };
            ObservableCollection<Test> tmpList = JsonConvert.DeserializeObject<ObservableCollection<Test>>(await ServerDataStream.ServerDataStreamJson(rs));
            foreach (var t in tmpList)
            {
                testList.Add(t);
            }
        }
        public async void GetQuestions(string test)
        {
            questiontList.Clear();
            RequestService rs = new RequestService
            {
                type = "[GET]",
                dict = "Questions",
                text = "",
                options = test
            };
            ObservableCollection<Questions> tmpList = JsonConvert.DeserializeObject<ObservableCollection<Questions>>(await ServerDataStream.ServerDataStreamJson(rs));
            foreach (var t in tmpList)
            {
                questiontList.Add(t);
            }
        }
        public async void GetAnswers(string question)
        {
            answerList.Clear();
            RequestService rs = new RequestService
            {
                type = "[GET]",
                dict = "Answers",
                text = "",
                options = question
            };
            ObservableCollection<Answers> tmpList = JsonConvert.DeserializeObject<ObservableCollection<Answers>>(await ServerDataStream.ServerDataStreamJson(rs));
            foreach (var t in tmpList)
            {
                answerList.Add(t);
            }
        }
    }
}
