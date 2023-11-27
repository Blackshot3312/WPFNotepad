﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadWPF.Models
{
    public class DocumentModel: ObservableObject
    {
        private string _text;
        public string Text { get { return _text; } 
            set {
                OnPropertyChanged(ref _text, value); 
              
            } 
        }

        private string _filePath;
        public string filePath
        {
            get { return _filePath; }
            set
            {
                OnPropertyChanged(ref _filePath, value);
                
            }
        }

        private string _fileName;
        public string fileName
        {
            get { return _fileName; }
            set
            {
                OnPropertyChanged(ref _fileName, value);
            
            }
        }
        public bool isEmpty
        {
            get
            {
                if(string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(filePath)) return true;

                return false;
            }
        }

    }
}