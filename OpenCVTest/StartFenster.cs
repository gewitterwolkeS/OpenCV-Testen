using Microsoft.Win32;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Point = OpenCvSharp.Point;
using Window = System.Windows.Window;

namespace Ballerspiel
{
    internal class StartFenster:Window
    {
        /// <summary> 
        /// Konstruktor, wird aufgerufen sobald mit "new StartFenster()"
        /// ein neues Objekt der Klasse "StartFenster" erstellt wird.
        /// </summary>
        public StartFenster()
        {
            this.Title = "Hallo";
        }

       
    }
}
