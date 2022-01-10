using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EmployeeJson
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void jsonConvert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee person = new Employee();
                string json1 = @"{
                  'd': [
                    {
                      'name': 'Peter Parker',
                      'role': 'Developer',
                      'birthyear': '1990',
                    },
                    {
                      'name': 'Tom Hank',
                      'role': 'Tester',
                      'birthyear': '1991',
                    },
                    {
                      'name': 'Mary Jane',
                      'role': 'QA',
                      'birthyear': '1994',
                    }
                  ]
                }";

                JObject o = JObject.Parse(json1);

                JArray a = (JArray)o["d"];

                IList<Employee> listperson = a.ToObject<IList<Employee>>();

                for(int i = 0; i < 3; i++)
                {
                    jsonTxtBox.Text += "\n" + listperson[i].name + "  " + listperson[i].role + "   " + listperson[i].birthyear;
                }
            }
            catch (Exception exObj)
            {
                jsonTxtBox.Text += "\n" + exObj.Message;
            }
        }
    }
}
