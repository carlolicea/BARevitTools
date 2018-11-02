using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BARevitTools
{
    public partial class MaterialsAMLPalette : Form
    {

        public MaterialsAMLPalette()
        {
            InitializeComponent();
        }

        private void PaletteSelectButton_Click(object sender, EventArgs e)
        {
            BARevitTools.Application.thisApp.newMainUi.MaterialsAMLPaletteRun_Click();
        }

        private void MaterialsAMLPalette_FormClosed(object sender, FormClosedEventArgs e)
        {
            BARevitTools.Application.thisApp.newMainUi.materialsAMLPalette = null;
        }
    }
}
