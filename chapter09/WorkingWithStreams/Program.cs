using System;
using System.IO;
using System.Xml;
using static System.Environment;
using static System.IO.Path;
using System.IO.Compression;

namespace WorkingWithStreams
{
    class Program
    {
        // define an array of Viper pilot call signs
        static string[] callsigns = new string[] {"Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack"};
        
        public static void Main(string[] args)
        {
            //WorkWithText();
            WorkWithXml();
            WorkWithCompression();
        }

        static void WorkWithText()
        {
            // define a file to write to
            string textFile = Combine(CurrentDirectory, "streams.txt");

            // create a text file and return a helper writer
            StreamWriter text = File.CreateText(textFile);

            // enumerate the strings, writing each one
            // to the stream on a separate line
            foreach(string item in callsigns)
            {
                text.WriteLine(item);
            }
            text.Close(); // release the resources

            // output the content of the file
            System.Console.WriteLine($"{textFile} contains {new FileInfo(textFile).Length:N0} bytes");
            System.Console.WriteLine(File.ReadAllText(textFile));
        }

        private static void WorkWithXml()
        {
            
            FileStream xmlFileStream = null;
            XmlWriter xml = null;

            try
            {
                // define a file to write to
                string xmlFile = Combine(CurrentDirectory, "streams.xml");
                // create a file stream
                xmlFileStream = File.Create(xmlFile);
                // wrap the file stream in an XML writer helper and automatically indent nested elements
                xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings {Indent=true});
                // write the XML declaration
                xml.WriteStartDocument();

                // write a root element
                xml.WriteStartElement("callsigns");

                // enumerate the strings writing each one to the stream
                foreach(string item in callsigns)
                {
                    xml.WriteElementString("callsign", item);
                }

                // write the close root element
                xml.WriteEndElement();

                // close helper and stream
                xml.Close();
                xmlFileStream.Close();

                // output all the contents of the file
                System.Console.WriteLine($"{xmlFile} contains {new FileInfo(xmlFile).Length:N0}");

                System.Console.WriteLine(File.ReadAllText(xmlFile));

            }
            catch(Exception ex)
            {
                // if the path doesnt exist the exception will be caught
                System.Console.WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (xml != null)
                {
                    xml.Dispose();
                    System.Console.WriteLine("The XML writer's unmanaged resources have been disposed.");
                }
                if (xmlFileStream != null)
                {
                    xmlFileStream.Dispose();
                    System.Console.WriteLine("The file stream's unmanaged resources have been disposed");
                }
            }
        }

        static void WorkWithCompression()
        {
            // compress the XML output
            string gzipFilePath = Combine(CurrentDirectory, "streams.gzip");

            FileStream gzipFile = File.Create(gzipFilePath);

            using (GZipStream compressor = new GZipStream(gzipFile, CompressionMode.Compress))
            {
                using (XmlWriter xmlGzip = XmlWriter.Create(compressor))
                {
                    xmlGzip.WriteStartDocument();
                    xmlGzip.WriteStartElement("callsigns");

                    foreach(string item in callsigns)
                    {
                        xmlGzip.WriteElementString("callsign", item);
                    }
                    // the normal call to WriteEndElement is not necessary
                    // because when the XmlWriter disposes, it will automatically
                    // end any elements of any depth
                }
            } // also closes the underlying stream

            // output all the content of the compressed file
            System.Console.WriteLine($"{gzipFilePath} contains {new FileInfo(gzipFilePath).Length:N0} bytes");

            System.Console.WriteLine("The compressed contents: ");
            System.Console.WriteLine(File.ReadAllText(gzipFilePath));

            // read a compressed file
            System.Console.WriteLine("Reading the compressed XML file: ");
            gzipFile = File.Open(gzipFilePath, FileMode.Open);

            using (GZipStream decompressor = new GZipStream(gzipFile, CompressionMode.Decompress))
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    // check if we are on an element node named callsign
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
                    {
                        reader.Read(); // move to the text inside element
                        System.Console.WriteLine($"{reader.Value}");
                    }
                }
            }
        }
    }
}