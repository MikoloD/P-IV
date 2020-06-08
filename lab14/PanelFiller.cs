using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lab14
{
    public class PanelFiller : IPanelFiller
    {
        public PanelFiller(IcontrolGenerator controlGeneration,
            IDataProvider dataProvider)
        {
            ControlGeneraton = controlGeneration;
            _dataProvider = dataProvider;
        }
        public IcontrolGenerator ControlGeneraton { get; set; }
        public IDataProvider _dataProvider { get; set; }
        public void Fill(Panel panel)
        {
            for (int i = 0; i < 10; i++)
            {
                panel.Children.Add(ControlGeneraton.Generate
                    (_dataProvider.GetData()));
            }
        }
    }
}
