using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternAssignment_2
{
    public class DocumentFactory
    {
        public IDocument CreateDocument(string type)
        {
            switch (type.ToLower())
            {
                case "pdf":
                    return new PDFDocument();
                case "word":
                    return new WordDocument();
                default:
                    throw new ArgumentException("Invalid document type.");
            }
        }
    }
}
