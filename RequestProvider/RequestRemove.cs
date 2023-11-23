using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TestClient.Dictionary;
using TestClient.DictionaryService;
using TestClient.ServerProvider;
using TestClient.ServiceProvider;

namespace TestClient.RequestProvider
{
    internal class RequestRemove
    {
        public async void Test(object o)
        {
            Test test = o as Test;
            RequestService rs = new RequestService
            {
                type = "[DEL]",
                dict = "Tests",
                text = "",
                options = test.Id
            };
            var request = await ServerDataStream.ServerDataStreamJson(rs);
            for(int i = 0; i <GetListsProvider.testList.Count; i++) 
            {
                if (GetListsProvider.testList[i].Id == test.Id)
                {
                    GetListsProvider.testList.Remove(GetListsProvider.testList[i]);
                }
            }
        }
        public async void Questions(object o)
        {
            Questions q = o as Questions;
            RequestService rs = new RequestService
            {
                type = "[DEL]",
                dict = "Questions",
                text = "",
                options = q.Id
            };
            var request = await ServerDataStream.ServerDataStreamJson(rs);
            for (int i = 0; i < GetListsProvider.questiontList.Count; i++)
            {
                    if (GetListsProvider.questiontList[i].Id == q.Id)
                    {
                        GetListsProvider.questiontList.Remove(GetListsProvider.questiontList[i]);

                    }
            }
        }
        public async void Answers(object o)
        {
            Answers a = o as Answers;
            RequestService rs = new RequestService
            {
                type = "[DEL]",
                dict = "Answers",
                text = "",
                options = a.Id
            };
            var request = await ServerDataStream.ServerDataStreamJson(rs);
            for (int i = 0; i < GetListsProvider.answerList.Count; i++)
            {
                if (GetListsProvider.answerList[i].Id == a.Id)
                {
                    GetListsProvider.answerList.Remove(GetListsProvider.answerList[i]);

                }
            }
        }
    }
}
