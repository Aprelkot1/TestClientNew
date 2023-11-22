using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using TestClient.Dictionary;

namespace TestClient.ServiceProvider
{
    internal class FindChildrenProvider
    {
        public string FindCheckBoxChildren(string childName, Button button)
        {
            DependencyObject parentObj = VisualTreeHelper.GetParent(button);
            int childrenCount = VisualTreeHelper.GetChildrenCount(parentObj);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parentObj, i);
                CheckBox childType = child as CheckBox;
                if (childType != null)
                {
                    if (childType.Name == childName)
                    {
                        return childType.IsChecked.ToString();
                    }
                }
            }
            return null;
        }
        public string FindTextBoxChildrenText(string childName, Button button)
        {
            DependencyObject parentObj = VisualTreeHelper.GetParent(button);
            int childrenCount = VisualTreeHelper.GetChildrenCount(parentObj);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parentObj, i);
                TextBox childType = child as TextBox;
                if (childType != null)
                {
                    if (childType.Name == childName)
                    {
                        return childType.Text;
                    }
                }
            }
            return null;
        }
        public string FindDatePickerChildrenText(string childName, Button button)
        {
            DependencyObject parentObj = VisualTreeHelper.GetParent(button);
            int childrenCount = VisualTreeHelper.GetChildrenCount(parentObj);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parentObj, i);
                DatePicker childType = child as DatePicker;
                if (childType != null)
                {
                    if (childType.Name == childName)
                    {
                        return childType.Text;
                    }
                }
            }
            return null;
        }
        public string FindTextBlockChildrenText(string childName, Button button)
        {
            DependencyObject parentObj = VisualTreeHelper.GetParent(button);
            int childrenCount = VisualTreeHelper.GetChildrenCount(parentObj);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parentObj, i);
                TextBlock childType = child as TextBlock;
                if (childType != null)
                {
                    if (childType.Name == childName)
                    {
                        return childType.Text;
                    }
                }
            }
            return null;
        }
        public string FindComboBoxChildrenSelectedItem(string childName, Button button)
        {
            DependencyObject parentObj = VisualTreeHelper.GetParent(button);
            int childrenCount = VisualTreeHelper.GetChildrenCount(parentObj);
            for (int i = 0; i < childrenCount; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parentObj, i);
                ComboBox childType = child as ComboBox;
                if (childType != null)
                {
                    if (childType.Name == childName)
                    {
                        return childType.Text;
                    }
                }
            }
            return null;
        }
    }
}

