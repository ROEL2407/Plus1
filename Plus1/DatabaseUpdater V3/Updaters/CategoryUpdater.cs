using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatabaseUpdater_V3.Updaters
{
    class CategoryUpdater
    {
        public static void Run()
        {
            Entities db = new Entities();
            XmlDocument doc = new XmlDocument();
            doc.Load(Program.BaseURL + "categories");
            string xmlcontents = doc.InnerXml;
            XmlElement xelRoot = doc.DocumentElement;

            XmlNodeList Categories = xelRoot.SelectNodes("/Categories/Category");
            foreach (XmlNode xndNode in Categories)
            {
                Categories c = new Categories();
                c.Name = xndNode["Name"].InnerText;
                var original = db.Categories.Find(xndNode["Name"].InnerText);
                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(c);
                    db.SaveChanges();
                }
                else
                {
                    db.Categories.Add(c);
                    XmlNodeList SubCategories = xndNode.SelectNodes("Subcategory");
                    foreach (XmlNode SubNode in SubCategories)
                    {
                        SubCategories sc = new SubCategories();
                        sc.Name = SubNode["Name"].InnerText;
                        sc.Parent_Name = xndNode["Name"].InnerText;
                        db.SubCategories.Add(sc);

                        XmlNodeList SubSubCategories = SubNode.SelectNodes("Subsubcategory");
                        foreach (XmlNode SubSubNode in SubSubCategories)
                        {
                            SubSubCategories ssc = new SubSubCategories();
                            ssc.Name = SubSubNode["Name"].InnerText;
                            ssc.Parent_Name = SubNode["Name"].InnerText;
                            db.SubSubCategories.Add(ssc);
                        }
                    }
                    db.SaveChanges();
            }
            }
        }
    }
}
