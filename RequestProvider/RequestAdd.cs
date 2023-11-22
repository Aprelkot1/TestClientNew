using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClient.DictionaryService;
using TestClient.ServerProvider;
using TestClient.Dictionary;
using TestClient.ServiceProvider;
namespace TestClient.RequestProvider
{
    internal class RequestAdd
    {
        public async void Test(string name)
        {
            RequestService rs = new RequestService
            {
               
                type = "[ADD]",
                dict = "Tests",
                text = name,
                options = ""
            };
            ObservableCollection<Test> request = JsonConvert.DeserializeObject<ObservableCollection<Test>>(await ServerDataStream.ServerDataStreamJson(rs));
           GetListsProvider.testList.Add(request[0]);
        }
        public async void Question(string name, string test)
        {
            RequestService rs = new RequestService
            {

                type = "[ADD]",
                dict = "Questions",
                text = name,
                options = test
            };
            ObservableCollection<Questions> request = JsonConvert.DeserializeObject<ObservableCollection<Questions>>(await ServerDataStream.ServerDataStreamJson(rs));
            GetListsProvider.questiontList.Add(request[0]);
        }
        public async void Answer(string name, string question, string correct)
        {
            RequestService rs = new RequestService
            {

                type = "[ADD]",
                dict = "Answers",
                text = name,
                options = question + " " + correct
            };
            ObservableCollection<Answers> request = JsonConvert.DeserializeObject<ObservableCollection<Answers>>(await ServerDataStream.ServerDataStreamJson(rs));
            GetListsProvider.answerList.Add(request[0]);
        }
    }
 
}

