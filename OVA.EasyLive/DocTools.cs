using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace ERDOffline.Lib
{
    public enum DocumentSection { Main, Header }
    public static class DocTools
    {
        public static void SearchAndReplace(string templatePath, string destinationFilePath, Dictionary<string, string> fieldValues, string Author)
        {
            File.Copy(templatePath, destinationFilePath, true);
            FileInfo finfo = new FileInfo(destinationFilePath);
            finfo.Attributes = FileAttributes.Directory | FileAttributes.Normal;

            string docText = "";
            
            var file = ShellFile.FromFilePath(destinationFilePath);
            ShellPropertyWriter propertyWriter = file.Properties.GetPropertyWriter();
            propertyWriter.WriteProperty(SystemProperties.System.Author, new string[] { Author });
            propertyWriter.WriteProperty(SystemProperties.System.ComputerName, new string[] { "Asia Soft" });
            propertyWriter.Close();

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destinationFilePath, true))
            {
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                }

                foreach (var item in fieldValues)
                {
                    docText = ReplaceWholeWord(docText, item.Key, item.Value);
                }

                foreach (FooterPart footer in wordDoc.MainDocumentPart.FooterParts)
                {
                    string footerText = null;
                    using (StreamReader sr = new StreamReader(footer.GetStream()))
                    {
                        footerText = sr.ReadToEnd();
                    }

                    foreach (var item in fieldValues)
                    {
                        footerText = ReplaceWholeWord(footerText, item.Key, item.Value);
                    }

                    using (StreamWriter sw = new StreamWriter(footer.GetStream(FileMode.Create)))
                    {
                        sw.Write(footerText);
                    }
                    //Save Header
                    footer.Footer.Save();

                }

                foreach (HeaderPart footer in wordDoc.MainDocumentPart.HeaderParts)
                {
                    string footerText = null;
                    using (StreamReader sr = new StreamReader(footer.GetStream()))
                    {
                        footerText = sr.ReadToEnd();
                    }

                    foreach (var item in fieldValues)
                    {
                        footerText = ReplaceWholeWord(footerText, item.Key, item.Value);
                    }

                    using (StreamWriter sw = new StreamWriter(footer.GetStream(FileMode.Create)))
                    {
                        sw.Write(footerText);
                    }
                    //Save Header
                    footer.Header.Save();

                }



                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                    sw.Close();
                    sw.Dispose();
                }
                
                wordDoc.Close();
                wordDoc.Dispose();
            }

            

        }

        public static void ProcessBookmarksPartTest(IDictionary<string, object> values, DocumentSection documentSection, object section)
        {
            IEnumerable<BookmarkStart> bookmarks = null;

            bookmarks = ((HeaderPart)section).RootElement.Descendants<BookmarkStart>();
        }

        public static string ReplaceWholeWord(this string original, string wordToFind, string replacement, RegexOptions regexOptions = RegexOptions.None)
        {
            string pattern = String.Format(@"\b{0}\b", wordToFind);

            if (replacement == null)
            {
                replacement = "---";
            }

            string ret = Regex.Replace(original, pattern, replacement, regexOptions);
            return ret;
        }

        public static string units(int num, unitsObject cases)
        {
            num = Math.Abs(num);
            var word = "";
            if (num.ToString().IndexOf('.') > -1)
            {
                word = cases.gen;
            }
            else
            {
                word = (
                    num % 10 == 1 && num % 100 != 11
                        ? cases.nom
                        : num % 10 >= 2 && num % 10 <= 4 && (num % 100 < 10 || num % 100 >= 20)
                            ? cases.gen
                            : cases.plu
                );
            }
            return word;
        }
    }

    public class unitsObject
    {
        public string nom { get; set; }
        public string gen { get; set; }
        public string plu { get; set; }
    }
}
