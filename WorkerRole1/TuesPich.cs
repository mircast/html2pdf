using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuesPechkin;
using System.Drawing.Printing;


namespace WorkerRole1
{
    public  class TuesPich
    {
        public static IConverter converter=   new ThreadSafeConverter(
         new PdfToolset(
             new Win64EmbeddedDeployment(
                 new TempFolderDeployment())));
        
        public  byte[] convertHTMLTOPDF(string html)
        {
            var document = new HtmlToPdfDocument
 {
     GlobalSettings =
     {
         ProduceOutline = false,
         DocumentTitle = "Pretty Websites",
         PaperSize = PaperKind.Letter, // Implicit conversion to PechkinPaperSize
         Margins =
         {
             All = 1.375,
             Unit = Unit.Centimeters
         }
         
         

     },
     Objects = {
        //new ObjectSettings { HtmlText = "<h1>Pretty Websites</h1><p>This might take a bit to convert!</p>" },
        new ObjectSettings { HtmlText = html},
        //new ObjectSettings { PageUrl = "www.microsoft.com" },
        //new ObjectSettings { PageUrl = "www.github.com" }
    }
 };

          

            byte[] result = converter.Convert(document);
            return result;
           // ByteArrayToFile(result, "C:/temp/exmple.pdf");
        }

        public static bool ByteArrayToFile(byte[] _ByteArray, string _FileName)
        {
            try
            {
                System.IO.FileStream _FileStream = new System.IO.FileStream(_FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);

                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);

                _FileStream.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }

            return false;
        }
    }
}
