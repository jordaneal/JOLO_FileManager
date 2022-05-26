using Microsoft.VisualStudio.TestTools.UnitTesting;
using JOLO_FileManager;
using System;
using System.IO;

namespace FileManagerTest
{
    [TestClass]
    public class Tests
    {
        private static string? _filePath = null;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            string fileName = context.Properties["FileOne"].ToString();
            string path = Path.Combine(Environment.CurrentDirectory, @"Files\", fileName);
            _filePath = path;
        }

        [TestMethod]
        public void FileExistsPASS()
        {
            Assert.IsTrue(FileManager.FileExists(_filePath));
        }
        [TestMethod]
        public void FileExistsFAIL()
        {
            Assert.IsFalse(FileManager.FileExists(null));
            Assert.IsFalse(FileManager.FileExists(""));
        }
        //[TestMethod]
        //public void DirectoryNamePASS()
        //{
        //    FileManager.DirectoryName();
        //}
        //[TestMethod]
        //public void LargestFileInCurrentDirectoryPASS()
        //{
        //    FileManager.LargestFileInCurrentDirectory();
        //}
        //[TestMethod]
        //public void FileNamePASS()
        //{
        //    FileManager.FileName();
        //}
        //[TestMethod]
        //public void VowelWeightPASS()
        //{
        //    FileManager.VowelWeight();
        //}
        //[TestMethod]
        //public void FileExtensionPASS()
        //{
        //    FileManager.FileExtension();
        //}
        //[TestMethod]
        //public void GetByteArrayPASS()
        //{
        //    FileManager.GetByteArray();
        //}
    }
}