using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WallInfo
{
    public partial class WallsForm : Form
    {
        public Command cmd;
        public WallsForm(Command cmd)
        {
            this.cmd = cmd;
            InitializeComponent();

        }

        private void WallsForm_Load(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = cmd.walls.ToArray();
            this.wallsGridView.DataSource = cmd.walls;


        }

        private void wallDataBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void wallsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            WallData wallData = cmd.walls.ElementAt(e.RowIndex);
            cmd.UiDoc.ShowElements(wallData.ids);
            cmd.UiDoc.Selection.SetElementIds(wallData.ids);
            
        }
    }
}
