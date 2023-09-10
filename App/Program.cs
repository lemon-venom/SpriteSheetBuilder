using SpriteSheetBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteSheetBuilderUtility
{
    // The sprite sheet builder is a control that can be embedded in a host application, or
    // it can be shown via a popup form that hosts it. This is a simple wrapper exe that
    // shows the popup form.
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);
            
            ISpriteSheetBuilderDialog spriteSheetBuilder = new SpriteSheetBuilderForm();

            Form applicationMainForm = ((Form)spriteSheetBuilder);

            applicationMainForm.ShowInTaskbar = true;
            
            Application.Run(applicationMainForm);
        }
    }
}
