using Microsoft.Win32;
using NotepadWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotepadWPF.ViewModels
{
    public class FileViewModel
    {
        public DocumentModel Document { get; private set; }

        //Funcionalidades para a ToolBar
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommnad {  get; }

        public FileViewModel(DocumentModel document)
        {
            Document = document;
            NewCommand = new RelayCommands(NewFile);
            SaveCommand = new RelayCommands(SaveFile);
            SaveAsCommand = new RelayCommands(SaveFileAs);
            OpenCommnad = new RelayCommands(OpenFile);
        }

        public void NewFile()
        {
            Document.fileName = string.Empty;
            Document.filePath = string.Empty;
            Document.Text = string.Empty;
        }
        private void SaveFile()
        {
            File.WriteAllText(Document.filePath, Document.Text);
        }
        private void SaveFileAs()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Arquivo de texto (*.txt) | *.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                DockFile(saveFileDialog);
                File.WriteAllText(saveFileDialog.FileName, Document.Text);
            }
                
                
        }
        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                DockFile(openFileDialog);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void DockFile<T>(T dialog) where T : FileDialog
        {
            Document.filePath = dialog.FileName;
            Document.fileName = dialog.SafeFileName;
        }
    }
}
