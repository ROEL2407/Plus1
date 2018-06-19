using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatabaseUpdater_V3.Updaters
{
    class ProductUpdater
    {
        public static void Run()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Program.BaseURL + "products");
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

                var original = db.Products.Find(p.EAN);
                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(p);
                    db.SaveChanges();
                }
                else
                {
                    db.Products.Add(p);
                    db.SaveChanges();
                }


            }
            Console.WriteLine("Finished Product Table Routine");
        }
    }
}
