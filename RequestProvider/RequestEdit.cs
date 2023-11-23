using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestClient.DictionaryService;
using TestClient.ServerProvider;
using TestClient.ServiceProvider;
using TestClient.Dictionary;
namespace TestClient.RequestProvider
{
    internal class RequestEdit
    {
        public async void Test(object o)
        {
            Test test = o as Test;
            RequestService rs = new RequestService
            {
                type = "[EDIT]",
                dict = "Tests",
                text = test.TestName,
                options = test.Id
            };
            var request = await ServerDataStream.ServerDataStreamJson(rs);
        }
        public async void Questions(object o)
        {
            Questions q = o as Questions;
            RequestService rs = new RequestService
            {
                type = "[EDIT]",
                dict = "Questions",
                text = q.Question,
                options = q.Id
            };
            var request = await ServerDataStream.ServerDataStreamJson(rs);
        }
        public async void Answers(object o)
        {
            Answers a = o as Answers;
            RequestService rs = new RequestService
            {
                type = "[EDIT]",
                dict = "Answers",
                text = a.Answer,
                options = a.Id + " " + a.True
            };
            var request = await ServerDataStream.ServerDataStreamJson(rs);
        }
    }
}
