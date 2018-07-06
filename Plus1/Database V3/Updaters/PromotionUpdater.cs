using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Database_V3.Updaters
{
    class PromotionUpdater
    {
        public static void Run()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Program.BaseURL + "promotions");
            string xmlcontents = doc.InnerXml;

            XmlElement xelRoot = doc.DocumentElement;
            XmlNodeList xnlNodes = xelRoot.SelectNodes("/Promotions/Promotion");

            foreach (XmlNode xndNode in xnlNodes)
            {
                Entities db = new Entities();
                Promotions p = new Promotions();

                p.EAN = xndNode["EAN"].InnerText;
                p.Title = xndNode["Title"].InnerText;
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
