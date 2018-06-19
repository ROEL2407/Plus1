using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatabaseUpdater_V2
{
    class Program
    {
        /*
        ------------------------------------------------------------
        |                                                          |
        |                   DatabaseUpdater                        |         
        |                   Version: V2                             |
        |                   By Tom                                 |
        |                                                          |
        ------------------------------------------------------------
        */
        static string BaseURL = "http://supermaco.starwave.nl/api/";
        static void Main(string[] args)
        {

        }

        static void ProductUpdate()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(BaseURL + "products");
            string xmlcontents = doc.InnerXml;

            XmlElement xelRoot = doc.DocumentElement;
            XmlNodeList xnlNodes = xelRoot.SelectNodes("/Products/Product");

            foreach (XmlNode xndNode in xnlNodes)
            {
                Entities db = new Entities();

                Products p = new Products();
                p.EAN = xndNode["EAN"].InnerText;
                p.Title = xndNode["Title"].InnerText;
                p.Brand = xndNode["Brand"].InnerText;
                p.Shortdescription = xndNode["Shortdescription"].InnerText;
                p.FullDescription = xndNode["Fulldescription"].InnerText;
                p.Image = xndNode["Image"].InnerText;
                p.Weight = xndNode["Weight"].InnerText;
                p.Price = decimal.Parse(xndNode["Price"].InnerText);

                Products Existing = db.Products.FirstOrDefault(pe => p.EAN == xndNode["EAN"].InnerText);
                    if (Existing != null)
                    {

                    }

                db.Products.Add(p);

                db.SaveChanges();
            }
            Console.WriteLine("Finished Product Table Routine");
    }
    }
}
