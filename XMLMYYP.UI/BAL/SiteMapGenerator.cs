using System;
using System.IO;
using System.Text;
using System.Xml;

namespace XMLMYYP.UI.BAL
{
    public class SiteMapGenerator
    {
         XmlTextWriter writer;
 
        public SiteMapGenerator(string strPath)
        {
            writer = new XmlTextWriter(strPath, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
        }
        
        /// <summary>
        /// Writes the beginning of the SiteMap document
        /// </summary>
        public void WriteStartDocument()
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("urlset"); 
            writer.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
        }
 
        /// <summary>
        /// Writes the end of the SiteMap document
        /// </summary>
        public void WriteEndDocument()
        {
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
 
        /// <summary>
        /// Closes this stream and the underlying stream
        /// </summary>
        public void Close()
        {
            writer.Flush();
            writer.Close();
        }
 
        public void WriteItem(string link, DateTime publishedDate, string priority)
        {
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", link);
            writer.WriteElementString("lastmod", publishedDate.ToString("yyyy-MM-dd"));
            //writer.WriteElementString("changefreq", "always"); // month;y, weekly. daily .This is just hint crawlers dont use it
            //writer.WriteElementString("priority", priority); //default 0.5
            writer.WriteEndElement();
        }
    }    
}
