using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace lab14
{
    public class ButtonGenerator : IcontrolGenerator
    {
        public UIElement Generate(string param)
        {
            return new Button()
            {
                Content = param
            };
        }
    }
}
