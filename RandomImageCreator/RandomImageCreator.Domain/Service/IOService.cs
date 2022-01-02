﻿using System;
using System.Drawing;

namespace RandomImageCreator.Domain
{
    public class IOService
    {
        public static void SaveImage(string path, Bitmap image)
        {
            var fileName = Guid.NewGuid();
            var dirInfo = new System.IO.DirectoryInfo(path);
            CheckDirectoryExists(dirInfo);

            image.Save(path + fileName + ".png");
            image.Dispose();
        }

        private static void CheckDirectoryExists(System.IO.DirectoryInfo dirInfo)
        {
            if (!dirInfo.Exists)
            {
                System.IO.Directory.CreateDirectory(dirInfo.FullName);
            }
        }
    }
}
