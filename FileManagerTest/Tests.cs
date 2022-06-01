using Microsoft.VisualStudio.TestTools.UnitTesting;
using JOLO_FileManager;
using System.IO;
using System;

namespace FileManagerTest
{
    [TestClass]
    public class Tests
    {
        private static string? _filePath = null;
        private static string? _filePathTwo = null;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _filePath = Path.Combine(
                Directory.GetParent(Directory.GetCurrentDirectory()) // dir
                .Parent.Parent.Parent.ToString(), 
                @"Files\",                                           // folder
                context.Properties["LargestFile"].ToString()!);      // name

            _filePathTwo = Path.Combine(
                Directory.GetParent(Directory.GetCurrentDirectory()) // dir
                .Parent.Parent.Parent.ToString(),
                @"Files\MoreFiles\",                                 // folder
                context.Properties["FileOne"].ToString()!);          // name
        }
        [TestMethod]
        public void FileExistsPASS()
        {
            FileManager fm = new(_filePath!);
            Assert.IsTrue(fm.FileExists());
        }
        [TestMethod]
        public void FileExistsFAIL()
        {
            FileManager fm = new("");
            Assert.IsFalse(fm.FileExists());
        }
        [TestMethod]
        public void DirectoryNamePASS()
        {
            FileManager fm = new(_filePath!);
            Assert.AreEqual("Files", fm.DirectoryName());
        }
        [TestMethod]
        public void DirectoryNameFAIL()
        {
            FileManager fm = new(_filePath!);
            Assert.AreNotEqual("Fail", fm.DirectoryName());
        }
        [TestMethod]
        public void LargestFileFoundPASS()
        {
            FileManager fm = new(_filePath!);
            Assert.AreEqual("Largest.txt", fm.LargestFileInCurrentDirectory());
        }
        [TestMethod]
        public void LargestFileNotFirstFilePASS()
        {
            FileManager fm = new(_filePathTwo!);
            Assert.AreEqual("b.txt", fm.LargestFileInCurrentDirectory());
        }
        [TestMethod]
        public void VowelWeightPASS()
        {
            FileManager fm = new(_filePath!);
            Assert.AreEqual("86 As, 143 Es, 85 Is, 90 Os, 37 Us, 25 Ys",
                fm.VowelWeight());
        }
        [TestMethod]
        public void VowelWeightNOTTXTFILE()
        {
            FileManager fm = new("");
            Assert.AreEqual("0 As, 0 Es, 0 Is, 0 Os, 0 Us, 0 Ys", 
                fm.VowelWeight());
        }

        // Methods below require scoping change in FileManager, scoped for release build
        // change methods in FM to public/static for testing

        //[TestMethod]
        //public void GetVowelOutputALLONES()
        //{
        //    int[] allOnes = { 1, 1, 1, 1, 1, 1 };
        //    Assert.AreEqual("1 A, 1 E, 1 I, 1 O, 1 U, 1 Y", 
        //        FileManager.GetVowelOutputs(allOnes));
        //}
        //[TestMethod]
        //public void GetVowelOutputALLNINES()
        //{
        //    int[] allNines = { 9, 9, 9, 9, 9, 9 };
        //    Assert.AreEqual("9 As, 9 Es, 9 Is, 9 Os, 9 Us, 9 Ys", 
        //        FileManager.GetVowelOutputs(allNines));

        //}
        //[TestMethod]
        //public void GetVowelCountALLZEROS()
        //{
        //    int[] allZeros = { 0, 0, 0, 0, 0, 0 };
        //    CollectionAssert.AreEqual(allZeros, FileManager.GetVowelCounts(""));
        //}
        //[TestMethod]
        //public void GetVowelCountALLTHREES()
        //{
        //    int[] allThrees = { 3, 3, 3, 3, 3, 3 };
        //    CollectionAssert.AreEqual(allThrees, 
        //        FileManager.GetVowelCounts("aaaeeeiiiooouuuyyy"));
        //}
        [TestMethod]
        public void FileNamePASS()
        {
            FileManager fm = new(_filePath!);
            Assert.AreEqual("Largest", fm.FileName());
        }
        [TestMethod]
        public void FileNameFAIL()
        {
            FileManager fm = new(_filePath!);
            Assert.AreNotEqual("Fail", fm.FileName());
        }
        [TestMethod]
        public void FileExtensionPASS()
        {
            FileManager fm = new(_filePath!);
            Assert.AreEqual(".txt", fm.FileExtension());
        }
        [TestMethod]
        public void FileExtensionFAIL()
        {

            FileManager fm = new(_filePath!);
            Assert.AreNotEqual("Fail", fm.FileExtension());
        }
        [TestMethod]
        public void GetByteArrayPass()
        {
          FileManager fm = new(_filePath!);
         Assert.IsInstanceOfType(fm.GetByteArray(),typeof(byte[]));
        }
        [TestMethod]
        public void GetByteArrayFail()
        {

            FileManager fm = new(_filePath!);
            Assert.IsNotInstanceOfType("fail", typeof(byte[]));
        }
        [TestMethod]
        public void ToStringTEST()
        {
            FileManager fm = new(_filePath!);
            string output = fm.ToString();
            Assert.IsNotNull(output);
        }
    }
}