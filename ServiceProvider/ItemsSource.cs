using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestClient.ServiceProvider
{
    internal class ItemsSource
    {
        public void OnStart(ListBox TestListBox) 
        {
            TestListBox.ItemsSource = GetListsProvider.testList;
        }
    }
}
