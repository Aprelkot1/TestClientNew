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
                options = test.id
            };
            var request = await ServerDataStream.ServerDataStreamJson(rs);
            for(int i = 0; i <GetListsProvider.testList.Count; i++) 
            {
                if (GetListsProvider.testList[i].id == test.id)
                {
                    GetListsProvider.testList.Remove(GetListsProvider.testList[i]);
                }
            }
        }
        public async void Questions(object sender)
        {
            FindChildrenProvider fcp = new FindChildrenProvider();
            var Id = fcp.FindTextBoxChildrenText("QuestionIdBox", sender as System.Windows.Controls.Button);
            RequestService rs = new RequestService
            {
                type = "[DEL]",
                dict = "Questions",
                text = "",
                options = Id
            };
            var request = await ServerDataStream.ServerDataStreamJson(rs);
            for (int i = 0; i < GetListsProvider.questiontList.Count; i++)
            {
                    if (GetListsProvider.questiontList[i].Id == Id)
                    {
                        GetListsProvider.questiontList.Remove(GetListsProvider.questiontList[i]);

                    }
            }
        }
        public async void Answers(object sender)
        {
            FindChildrenProvider fcp = new FindChildrenProvider();
            var Id = fcp.FindTextBoxChildrenText("AnswerIdBox", sender as System.Windows.Controls.Button);
            RequestService rs = new RequestService
            {
                type = "[DEL]",
                dict = "Answers",
                text = "",
                options = Id
            };
            var request = await ServerDataStream.ServerDataStreamJson(rs);
            for (int i = 0; i < GetListsProvider.answerList.Count; i++)
            {
                if (GetListsProvider.answerList[i].Id == Id)
                {
                    GetListsProvider.answerList.Remove(GetListsProvider.answerList[i]);

                }
            }
        }
    }
}
