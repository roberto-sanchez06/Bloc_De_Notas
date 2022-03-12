using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bloc_De_Notas
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private TreeNode CrearArbol(DirectoryInfo directory)
        {
            TreeNode treeNode = new TreeNode { Text = directory.Name, Tag = directory.FullName };
            foreach (DirectoryInfo di in directory.GetDirectories())
            {
                treeNode.Nodes.Add(CrearArbol(di));
            }
            foreach (var files in directory.GetFiles())
            {
                treeNode.Nodes.Add(new TreeNode { Text = files.Name, Tag = directory.FullName });
            }
            return treeNode;
        }

        private void carpetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = null;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog.SelectedPath;
            }
            treeView1.Nodes.Clear();
            DirectoryInfo directory = new DirectoryInfo(path);
            treeView1.Nodes.Add(CrearArbol(directory));
        }
    }
}
