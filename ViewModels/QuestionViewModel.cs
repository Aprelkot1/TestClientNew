using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestClient.Dictionary;
using TestClient.RequestProvider;
using TestClient.ServiceProvider;

namespace TestClient.ViewModels
{
    internal class QuestionViewModel
    {
        GetListsProvider glp = new GetListsProvider();
        RequestAdd ra = new RequestAdd();
        RequestEdit re = new RequestEdit();
        RequestRemove rr = new RequestRemove();
        private Questions selectedQuestion;
        public ObservableCollection<Questions> QuestionsList { get; set; }
        public ObservableCollection<Answers> AnswersList { get; set; }
        private string TestId;
        private string correct;
        private CommandsProvider deleteQuestion;
        public CommandsProvider DeleteQuestion
        {
            get
            {
                return deleteQuestion ??
                  (deleteQuestion = new CommandsProvider(obj =>
                  {
                      foreach (var t in GetListsProvider.questiontList)
                      {
                          if (t.Id == obj as string)
                          {
                              rr.Questions(t);
                          }
                      }

                  }
                ));
            }
        }
        private CommandsProvider editQuestion;
        public CommandsProvider EditQuestion
        {
            get
            {
                return editQuestion ??
                  (editQuestion = new CommandsProvider(obj =>
                  {
                     
                      foreach (var t in GetListsProvider.questiontList)
                      {
                          if (t.Id == obj as string)
                          {
                              re.Questions(t);
                          }
                      }

                  }
                ));
            }
        }
        private CommandsProvider addQuestion;
        public CommandsProvider AddQuestion
        {
            get
            {
                return addQuestion ??
                  (addQuestion = new CommandsProvider(obj =>
                  {

                      ra.Question(obj as string, TestId);
                  },
                 (obj) => !String.IsNullOrEmpty(obj as string)));
            }
        }
        private CommandsProvider addAnswer;
        public CommandsProvider AddAnswer
        {
            get
            {
                return addAnswer ??
                  (addAnswer = new CommandsProvider(obj =>
                  {
                      if (selectedQuestion != null)
                      {
                          ra.Answer(obj as string, selectedQuestion.Id, correct);
                      }
                      else
                      {
                          MessageBox.Show("Выберите вопрос!");
                      }
                  },
                 (obj) => !String.IsNullOrEmpty(obj as string)));
            }
        }
        private CommandsProvider editAnswer;
        public CommandsProvider EditAnswer
        {
            get
            {
                return editAnswer ??
                  (editAnswer = new CommandsProvider(obj =>
                  {
                      foreach (var t in GetListsProvider.answerList)
                      {
                          if (t.Id == obj as string)
                          {
                              re.Answers(t);
                          }
                      }
                  }));
            }
        }
        private CommandsProvider deleteAnswer;
        public CommandsProvider DeleteAnswer
        {
            get
            {
                return deleteAnswer ??
                  (deleteAnswer = new CommandsProvider(obj =>
                  {
                      foreach (var t in GetListsProvider.answerList)
                      {
                          if (t.Id == obj as string)
                          {
                              rr.Answers(t);
                          }
                      }

                  }
                ));
            }
        }
        public Questions SelectedQuestion
        {
            get { return selectedQuestion; }
            set
            {
                selectedQuestion = value;
                GetListsProvider.answerList.Clear();
                if (selectedQuestion != null)
                {
                    glp.GetAnswers(selectedQuestion.Id);
                }
                OnPropertyChanged("SelectedQueston");
            }

        }
        public string Correct
        {
            get { return correct; }
            set
            {
                correct = value;
                OnPropertyChanged("Correct");
            }

        }
        public QuestionViewModel(string testId)
        {
            TestId = testId;
            glp.GetQuestions(testId);
            QuestionsList = GetListsProvider.questiontList;
            AnswersList = GetListsProvider.answerList; 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}

