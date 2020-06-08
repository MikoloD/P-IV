using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab14
{
    public interface IcontrolGenerator
    {
        UIElement Generate(string param);
    }
}
