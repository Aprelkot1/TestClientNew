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
                text = test.testName,
                options = test.id
            };
            var request = await ServerDataStream.ServerDataStreamJson(rs);
        }
        public async void Questions(object sender)
        {
            FindChildrenProvider fcp = new FindChildrenProvider();
            var Id = fcp.FindTextBoxChildrenText("QuestionIdBox", sender as System.Windows.Controls.Button);
            var Name = fcp.FindTextBoxChildrenText("QuestionNameBox", sender as System.Windows.Controls.Button);
            RequestService rs = new RequestService
            {
                type = "[EDIT]",
                dict = "Questions",
                text = Name,
                options = Id
            };
            var request = await ServerDataStream.ServerDataStreamJson(rs);
        }
        public async void Answers(object sender)
        {
            FindChildrenProvider fcp = new FindChildrenProvider();
            var Id = fcp.FindTextBoxChildrenText("AnswerIdBox", sender as System.Windows.Controls.Button);
            var Name = fcp.FindTextBoxChildrenText("AnswerNameBox", sender as System.Windows.Controls.Button);
            var TrueCheck = fcp.FindCheckBoxChildren("TrueAnswerCheckBox", sender as System.Windows.Controls.Button);
            MessageBox.Show(TrueCheck);
            RequestService rs = new RequestService
            {
                type = "[EDIT]",
                dict = "Answers",
                text = Name,
                options = Id + " " + TrueCheck
            };
            var request = await ServerDataStream.ServerDataStreamJson(rs);
        }
    }
}
