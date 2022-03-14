using Bloc_De_Notas.AppCore.Processes;
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
                treeNode.Nodes.Add(new TreeNode { Text = files.Name, Tag = directory.FullName+"\\"+files.Name});
            }
            return treeNode;
        }

        private void carpetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {

            }
        }

        private void treeView1_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {

            treeView1.SelectedNode = e.Node;
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string path = treeView1.SelectedNode.Tag.ToString();
            MessageBox.Show(path);
            FileInfo fileInfo = new FileInfo(path);
            if (Path.HasExtension(path))
            {
                StreamReader streamReader = new StreamReader(path);
                richTextBox1.Text = streamReader.ReadToEnd();
                //path = openFileDialog.FileName;
                streamReader.Close();
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(treeView1, e.X, e.Y);
            }
            if (Path.HasExtension(treeView1.SelectedNode.Tag.ToString()))
            {
                nuevoToolStripMenuItem.Enabled = false;
            }
       
        }

        private void carpetaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNombre frm = new FrmNombre();
                frm.ShowDialog();
                string nombre = frm.Nombre;
                DirectoryInfo di = DirectoryProcesses.Create(treeView1.SelectedNode.Tag.ToString(), nombre);
                treeView1.SelectedNode.Nodes.Add(new TreeNode { Text = nombre, Tag = di.FullName });
                MessageBox.Show(di.FullName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                   
                    filePath = openFileDialog.FileName;
                    FileInfo file1 = new FileInfo(filePath);
                    treeView1.Nodes.Add(CrearArbol(file1));



                }
            }
        }

        private TreeNode CrearArbol(FileInfo file1)
        {
            TreeNode treeNode = new TreeNode { Text = file1.Name, Tag = file1.FullName };
           
            return treeNode;

        }

        private void archivoDeTextoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                FrmNombre frm = new FrmNombre();
                frm.ShowDialog();
                string nombre = frm.Nombre;
                FileStream fstream = FileProcesses.Create(treeView1.SelectedNode.Tag.ToString(), nombre);
                string ruta = fstream.Name;
                treeView1.SelectedNode.Nodes.Add(new TreeNode { Text = nombre+".txt", Tag = ruta});
                MessageBox.Show(ruta);
                fstream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ruta = treeView1.SelectedNode.Tag.ToString();
            MessageBox.Show(ruta);
            if (Path.HasExtension(ruta))
            {
                FileProcesses.Delete(ruta);
            }
            else
            {
                DirectoryProcesses.Delete(ruta);
            }
            treeView1.SelectedNode.Remove();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void archivoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmNombre frm = new FrmNombre();
            frm.ShowDialog();
            string nombre = frm.Nombre;
            string path = Application.StartupPath + @"\" + nombre;
            try
            {
                if (File.Exists(path))
                {
                    MessageBox.Show("el archivo existe");

                }
                else
                {
                    File.Create(path);
                    FileInfo file = new FileInfo(path);
                    treeView1.Nodes.Add(CrearArbol(file));
                }
            }
            catch
            {

            }


        }

        private void carpetaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmNombre frm = new FrmNombre();
            frm.ShowDialog();
            string nombre = frm.Nombre;
            string path = Application.StartupPath + @"\" + nombre;

            try
            {
                if (Directory.Exists(path))
                {
                    MessageBox.Show("la carpeta existe");

                }
                else
                {
                    Directory.CreateDirectory(path);
                    DirectoryInfo directory = new DirectoryInfo(path);
                    treeView1.Nodes.Add(CrearArbol(directory));
                }
            }
            catch
            {

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            guardar.FileName = "sin titulo 1";
            var resultado = guardar.ShowDialog();
            if(resultado == DialogResult.OK)
            {
                StreamWriter escribir = new StreamWriter(guardar.FileName);
                foreach(object line in richTextBox1.Lines)
                {
                    escribir.WriteLine(line);
                }
                escribir.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
