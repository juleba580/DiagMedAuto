using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DiagMedAuto.ViewModels
{
    public class PasswordBoxTextMode : TextBox
    {
        public PasswordBoxTextMode()
        {
            // Définir le mode de texte sur Password pour masquer le texte
            this.TextMode = TextBoxMode.Password;
        }

        public object TextBoxMode { get; }
    }
}
