using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using TestClient.Dictionary;
using TestClient.RequestProvider;
using TestClient.ServiceProvider;

namespace TestClient.ViewModels
{
    internal class TestViewModel : INotifyPropertyChanged
    {
       GetListsProvider glp = new GetListsProvider();
        RequestAdd ra = new RequestAdd();
        RequestEdit re = new RequestEdit(); 
        RequestRemove rr = new RequestRemove();
        private Test SelectedTest;
        public ObservableCollection<Test> Tests { get; set; }

        private CommandsProvider EditQuestionOpen;
        public CommandsProvider editQuestionOpen
        {
            get
            {
                return EditQuestionOpen ??
                  (EditQuestionOpen = new CommandsProvider(obj =>
                  {
                     
                      foreach (Window window in System.Windows.Application.Current.Windows)
                      {
                          if (window.Title.Contains("Редактировать тест"))
                          {
                              window.Close();
                          }
                      }
                      foreach (var t in GetListsProvider.testList)
                      {
                          if (t.id == obj as string)
                          {
                              EditTestWindow editQuestionWindow = new EditTestWindow(t.id);
                              GetListsProvider gl = new GetListsProvider();
                              gl.GetQuestions(t.id);
                              editQuestionWindow.Title = "Редактировать тест " + t.testName;
                              editQuestionWindow.Show();
                              editQuestionWindow.Owner = Application.Current.MainWindow;
                          }
                      }

                  }
                ));
            }
        }
        private CommandsProvider DeleteTest;
        public CommandsProvider deleteTest
        {
            get
            {
                return DeleteTest ??
                  (DeleteTest = new CommandsProvider(obj =>
                  {
                      foreach (var t in GetListsProvider.testList)
                      {
                          if (t.id == obj as string)
                          {
                              rr.Test(t);
                          }
                      }

                  }
                ));
            }
        }
        private CommandsProvider EditTest;
        public CommandsProvider editTest
        {
            get
            {
                return EditTest ??
                  (EditTest = new CommandsProvider(obj =>
                  {
                      foreach(var t in GetListsProvider.testList)
                      {
                          if(t.id == obj as string)
                          {
                              re.Test(t);
                          }
                      }
                     
                  }
                ));
            }
        }
        private CommandsProvider AddTest;
        public CommandsProvider addTest
        {
            get
            {
                return AddTest ??
                  (AddTest = new CommandsProvider(obj =>
                  {
                      ra.Test(obj as string);
                  },
                 (obj) => !String.IsNullOrEmpty(obj as string)));
            }
        }
        public Test selectedTest
        {
            get { return SelectedTest; }
            set
            {
                SelectedTest = value;
                OnPropertyChanged("selectedTest");
            }
        }
        public TestViewModel()
        {
            glp.GetTests();
            Tests = GetListsProvider.testList;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
