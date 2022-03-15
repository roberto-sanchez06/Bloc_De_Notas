using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bloc_De_Notas
{
    public partial class FrmNombre : Form
    {
        public string Nombre { get; set; }
        public FrmNombre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("No se aceptan cadenas vacias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Nombre = textBox1.Text;
            Dispose();
        }
    }
}
