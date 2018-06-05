using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatabaseUpdater
{
    class Program
    {
        static string BaseURL = "http://supermaco.starwave.nl/api/";

        static void Main(string[] args)
        {
            UpdateProductTable(); 
        }

        static void UpdateProductTable()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load( BaseURL + "products");
            string xmlcontents = doc.InnerXml;

            XmlElement xelRoot = doc.DocumentElement;
            XmlNodeList xnlNodes = xelRoot.SelectNodes("/Products/Product");

            foreach (XmlNode xndNode in xnlNodes)
            {
                Console.WriteLine(xndNode["Title"].InnerText);
 

                //Your sql insert command will go here;
            }

            Console.ReadKey();
        }
    }

}

