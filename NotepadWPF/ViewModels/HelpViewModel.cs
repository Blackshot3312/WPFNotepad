using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotepadWPF.ViewModels
{
    public class HelpViewModel : ObservableObject
    {
        public ICommand HelpCommand { get; }

        public HelpViewModel(){
            HelpCommand = new RelayCommands(DisplayAbout);
       }

        private void DisplayAbout()
        {
            
        }
    }
    
}
