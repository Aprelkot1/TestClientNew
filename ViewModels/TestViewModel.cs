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
        public ObservableCollection<Test> Tests { get; set; }

        private CommandsProvider editQuestionOpen;
        public CommandsProvider EditQuestionOpen
        {
            get
            {
                return editQuestionOpen ??
                  (editQuestionOpen = new CommandsProvider(obj =>
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
                          if (t.Id == obj as string)
                          {
                              EditTestWindow editQuestionWindow = new EditTestWindow(t.Id);
                              editQuestionWindow.Title = "Редактировать тест " + t.TestName;
                              editQuestionWindow.Show();
                              editQuestionWindow.Owner = Application.Current.MainWindow;
                          }
                      }

                  }
                ));
            }
        }
        private CommandsProvider deleteTest;
        public CommandsProvider DeleteTest
        {
            get
            {
                return deleteTest ??
                  (deleteTest = new CommandsProvider(obj =>
                  {
                      foreach (var t in GetListsProvider.testList)
                      {
                          if (t.Id == obj as string)
                          {
                              rr.Test(t);
                          }
                      }

                  }
                ));
            }
        }
        private CommandsProvider editTest;
        public CommandsProvider EditTest
        {
            get
            {
                return editTest ??
                  (editTest = new CommandsProvider(obj =>
                  {
                      foreach(var t in GetListsProvider.testList)
                      {
                          if(t.Id == obj as string)
                          {
                              re.Test(t);
                          }
                      }
                     
                  }
                ));
            }
        }
        private CommandsProvider addTest;
        public CommandsProvider AddTest
        {
            get
            {
                return addTest ??
                  (addTest = new CommandsProvider(obj =>
                  {
                      ra.Test(obj as string);
                  },
                 (obj) => !String.IsNullOrEmpty(obj as string)));
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
