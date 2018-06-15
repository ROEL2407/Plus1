using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatabaseUpdater
{
    class ProductUpdater
    {
        public void Run()
        {

            Console.WriteLine("Start Product Table Routine");
            XmlDocument doc = new XmlDocument();
            Program p = new Program();
            doc.Load(p.BaseURL + "products");
            string xmlcontents = doc.InnerXml;

            XmlElement xelRoot = doc.DocumentElement;
            XmlNodeList xnlNodes = xelRoot.SelectNodes("/Products/Product");

            foreach (XmlNode xndNode in xnlNodes)
            {
                Console.WriteLine("Inserting: " + xndNode["Title"].InnerText);

                using (var connection = new SqlConnection(p.ConnectionString))
                {
                    connection.Open();
                    var sql = "INSERT INTO Products(EAN, Title, Brand, Shortdescription, FullDescription, Image, Weight, Price) VALUES(@EAN, @Title, @Brand, @ShortDescription, @FullDescription, @Image, @Weight, @Price)";
                    using (var cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@EAN", xndNode["EAN"].InnerText);
                        cmd.Parameters.AddWithValue("@Title", xndNode["Title"].InnerText);
                        cmd.Parameters.AddWithValue("@Brand", xndNode["Brand"].InnerText);
                        cmd.Parameters.AddWithValue("@ShortDescription", xndNode["Shortdescription"].InnerText);
                        cmd.Parameters.AddWithValue("@Image", xndNode["Image"].InnerText);
                        cmd.Parameters.AddWithValue("@FullDescription", xndNode["Fulldescription"].InnerText);
                        cmd.Parameters.AddWithValue("@Weight", xndNode["Weight"].InnerText);
                        cmd.Parameters.AddWithValue("@Price", xndNode["Price"].InnerText);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            Console.WriteLine("Finished Product Table Routine");
        }
    }
}
