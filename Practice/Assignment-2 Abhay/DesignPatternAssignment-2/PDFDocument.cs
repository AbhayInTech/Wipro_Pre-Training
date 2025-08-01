using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternAssignment_2
{
    public class PDFDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening PDF Document.");
        }
    }
}
