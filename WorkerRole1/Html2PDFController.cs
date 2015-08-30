using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WorkerRole1
{
     [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Html2PDFController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Hello from OWIN!")
            };
        }

        public HttpResponseMessage Get(int id)
        {
            string msg = String.Format("Hello from OWIN (id = {0})", id);
            return new HttpResponseMessage()
            {
                Content = new StringContent(msg)
            };
        }
        public IHttpActionResult Post([FromBody] string html)
        {
            TuesPich tue = new TuesPich();
            byte[] pdfArray=tue.convertHTMLTOPDF(html);
            PDF pdf = new PDF();
            pdf.pdfArray = pdfArray;
            pdf.tempString = Convert.ToBase64String(pdfArray);
            return Ok(pdf);
            
        }

    }
}