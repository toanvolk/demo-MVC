using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Demo_Main.Common
{
    public static class GenerateFileName
    {
        public static string Generate(HttpPostedFileBase file)
        {
            string filename = ReplaceUnicode.Replace(Path.GetFileName(file.FileName));
            filename = filename.Trim();
            filename = filename.Trim('-');
            filename = filename.ToLower();
            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&".ToCharArray();
            filename = filename.Replace("c#", "C-Sharp");
            filename = filename.Replace("vb.net", "VB-Net");
            filename = filename.Replace("asp.net", "Asp-Net");
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (filename.Contains(strChar))
                {
                    filename = filename.Replace(strChar, string.Empty);
                }
            }
            filename = filename.Replace(" ", "-");
            filename = filename.Replace("--", "-");
            filename = filename.Replace("---", "-");
            filename = filename.Replace("----", "-");
            filename = filename.Replace("-----", "-");
            filename = filename.Replace("----", "-");
            filename = filename.Replace("---", "-");
            filename = filename.Replace("--", "-");
            filename = filename.Trim();
            filename = filename.Trim('-');
            string saveFile = "re-" + filename;

            return saveFile;
        }

        private static string numberPattern = " ({0})";

        public static string NextAvailableFilename(HttpServerUtilityBase server, string path)
        {
            // Short-cut if already available
            if (!File.Exists(server.MapPath(path)))
                return path;

            // If path has extension then insert the number pattern just before the extension and return next filename
            if (Path.HasExtension(path))
                return GetNextFilename(server, path.Insert(path.LastIndexOf(Path.GetExtension(path)), numberPattern));

            // Otherwise just append the pattern to the path and return next filename
            return GetNextFilename(server, path + numberPattern);
        }

        private static string GetNextFilename(HttpServerUtilityBase server, string pattern)
        {
            string tmp = string.Format(pattern, 1);
            if (tmp == pattern)
                throw new ArgumentException("The pattern must include an index place-holder", "pattern");

            if (!File.Exists(server.MapPath(tmp)))
                return tmp; // short-circuit if no matches

            int min = 1, max = 2; // min is inclusive, max is exclusive/untested

            while (File.Exists(server.MapPath(string.Format(pattern, max))))
            {
                min = max;
                max *= 2;
            }

            while (max != min + 1)
            {
                int pivot = (max + min) / 2;
                if (File.Exists(server.MapPath(string.Format(pattern, pivot))))
                    min = pivot;
                else
                    max = pivot;
            }

            return string.Format(pattern, max);
        }
    }
}