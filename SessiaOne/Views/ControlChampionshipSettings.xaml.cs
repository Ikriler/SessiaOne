using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SessiaOne.DataSetTableAdapters;

namespace SessiaOne.Views
{
    public partial class ControlChampionshipSettings : UserControl
    {
        private ContentControl contentControl;
        private DataSet.competentionRow competention;
        public ControlChampionshipSettings(ContentControl contentControl, DataSet.competentionRow competention = null)
        {
            InitializeComponent();
            this.contentControl = contentControl;
            this.competention = competention;

            if(competention != null)
            {
                //labelContent.Content = competention.description;
            }
        }
    }
}
