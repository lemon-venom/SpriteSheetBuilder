using SpriteSheetBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteSheetBuilderUtility
{
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
            
            ISpriteSheetBuilderDialog spriteSheetBuilder = new SpriteSheetBuilderDialog();

            Form applicationMainForm = ((Form)spriteSheetBuilder);

            applicationMainForm.ShowInTaskbar = true;
            
            Application.Run(applicationMainForm);
        }
    }
}
