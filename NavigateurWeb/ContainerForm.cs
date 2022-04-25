using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;

namespace NavigateurWeb
{
    public partial class ContainerForm : TitleBarTabs
    {
        public ContainerForm()
        {
            InitializeComponent();
            AeroPeekEnabled = true;
            TabRenderer = new ChromeTabRenderer(this);
        }

        public override TitleBarTab CreateTab()
        {
            return new TitleBarTab(this)
            {
                Content = new BrowserForm
                {
                    Text = "Nouvel Onglet"
                }
            };
        }

    }
}
