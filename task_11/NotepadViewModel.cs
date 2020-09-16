//using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.Windows.Forms;



namespace Notepad
{
    class NotepadViewModel
    {

        public bool HaveChange { get; set; }
        public System.Windows.Controls.TextBox Npad { get; set; }
        public string Text { get; set; }
        public string FileName { get; set; }
        

        public NotepadViewModel()
        {
            HaveChange = false;
            InitializeCommands();
        }

        
        public void text_Changed(object sender, EventArgs e)
        {
            HaveChange = true;
        }

        public RelayCommand OpenCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand CloseCommand { get; private set; }

        private void InitializeCommands()
        {
            OpenCommand = new RelayCommand(o => OpenFile());
            SaveCommand = new RelayCommand(o => SaveFile());
            CloseCommand = new RelayCommand(o => CloseApp());
            
        }

        public void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                using (StreamReader file = new StreamReader(FileName))
                {
                    Npad.Text = file.ReadToEnd();
                }
            }
        }
        public void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (FileName != "") { saveFileDialog.FileName = FileName; }
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) { return; }
            using (StreamWriter file = new StreamWriter (saveFileDialog.FileName))
            {
                
                file.Write(Npad.Text);
            }
            HaveChange = false;
        }
        public void CloseApp()
        {
            if (HaveChange == true)
            {
                DialogResult result = MessageBox.Show("Сохранить файл?", "Закрыть", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel) { return; }
                if (result == DialogResult.Yes) { SaveFile(); }
            }
            Application.Exit();
        }
        public void CloseWin(object sender, EventArgs e)
        {
            CloseApp();
        }

    }
}
