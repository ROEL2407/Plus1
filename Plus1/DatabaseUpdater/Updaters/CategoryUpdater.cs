using DatabaseUpdater.Updaters.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DatabaseUpdater
{
    class CategoryUpdater
    {
        public List<Category> AllCat = new List<Category>();
        public List<SubCategory> AllSubCat = new List<SubCategory>();
        public List<SubSubCategory> AllSubSubCat = new List<SubSubCategory>();
        public Program p = new Program();

        public void Run()
        {
            Console.WriteLine("Start Category Table Routine");
            RunCategory();
            Console.ReadKey();
        }

        public void RunCategory()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(p.BaseURL + "categories");
            string xmlcontents = doc.InnerXml;
            XmlElement xelRoot = doc.DocumentElement;

            XmlNodeList Categories = xelRoot.SelectNodes("/Categories/Category");
            foreach (XmlNode xndNode in Categories)
            {
                Category c = new Category();
                c.Name = xndNode["Name"].InnerText;
                AllCat.Add(c);
                Console.WriteLine("Category: " + c.Name);

                XmlNodeList SubCategories = xndNode.SelectNodes("Subcategory");
                foreach (XmlNode SubNode in SubCategories)
                {
                    SubCategory sc = new SubCategory();
                    sc.Name = SubNode["Name"].InnerText;
                    AllSubCat.Add(sc);
                    Console.WriteLine("SubCategory: " + SubNode["Name"].InnerText);

                    XmlNodeList SubSubCategories = SubNode.SelectNodes("Subcategory");
                    foreach (XmlNode SubSubNode in SubCategories)
                    {
                        SubSubCategory ssc = new SubSubCategory();
                        ssc.Name = SubSubNode["Name"].InnerText;
                        AllSubSubCat.Add(ssc);
                        Console.WriteLine("SubSubCategory: " + SubSubNode["Name"].InnerText);
                    }
                }
            }
        }

        public void InsertCategory()
        {
            using (var connection = new SqlConnection(p.ConnectionString))
            {
                connection.Open();
                var sql = 
                    "INSERT INTO Products(EAN, Title, Brand, Shortdescription, FullDescription, Image, Weight, Price) VALUES(@EAN, @Title, @Brand, @ShortDescription, @FullDescription, @Image, @Weight, @Price)";
                using (var cmd = new SqlCommand(sql, connection))
                {
                    /*
                    cmd.Parameters.AddWithValue("@CatName", );
                    cmd.Parameters.AddWithValue("@CatSub", );
                    cmd.Parameters.AddWithValue("@", );
                    cmd.Parameters.AddWithValue("@ShortDescription",);
                    cmd.Parameters.AddWithValue("@Image",);
                    cmd.Parameters.AddWithValue("@FullDescription",);
                    cmd.Parameters.AddWithValue("@Weight",);
                    cmd.Parameters.AddWithValue("@Price",);
                    cmd.ExecuteNonQuery();
                    */
                }
            }
        }
    }
}
