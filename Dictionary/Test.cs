using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestClient.Dictionary
{
    internal class Test : INotifyPropertyChanged
    {
        private string Id { get; set; }
        private string TestName { get; set; }
       
        public string id
        {
            get { return Id; }
            set
            {
                Id = value;
                OnPropertyChanged("id");
            }
        }
        public string testName
        {
            get { return TestName; }
            set
            {
                TestName = value;
                OnPropertyChanged("testName");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
