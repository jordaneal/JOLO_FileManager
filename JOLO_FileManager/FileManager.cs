using System.Text;

namespace JOLO_FileManager
{
    public class FileManager
    {
        public string FilePath { get; set; }
        public FileManager(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            FilePath = filePath;
        }
        public bool FileExists()
        {
            return File.Exists(FilePath);
        }
        public string DirectoryName()
        {
            return Directory.GetParent(FilePath!).Name;
        }
        public string LargestFileInCurrentDirectory()
        {
            FileInfo[] files = Directory.GetParent(FilePath!).GetFiles();

            if (files.Length == 0)
            {
                return "No files in DIR";
            }

            FileInfo largestFile = files[0]; 

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Length > largestFile.Length)
                {
                    largestFile = files[i];
                }    
            }
            return largestFile.Name;
        }
        public string VowelWeight()
        {
            // If not .txt, return all 0's
            if (Path.GetExtension(FilePath) != ".txt") 
            {
                return "0 As, 0 Es, 0 Is, 0 Os, 0 Us, 0 Ys";
            }
            // Count vowels (Method Below)
             GetVowelCounts(File.ReadAllText(FilePath!).ToLower(), out int[] vowelCounts);
            // Output vowels in correct format (Method Below)
            return GetVowelOutputs(vowelCounts);
        }
        public string FileName()
        {
            return Path.GetFileNameWithoutExtension(FilePath!);
        }
        public string FileExtension()
        {
            return Path.GetExtension(FilePath!);
        }
        public byte[]? GetByteArray()
        {
            return File.ReadAllBytes(FilePath!);
        }
        public override string ToString()
        {
            FileInfo fileInfo = new(FilePath!);
            return
                $"File Path: {FilePath}\n" +
                $"Size: {fileInfo.Length}\n" +
                $"Is Read Only: {fileInfo.IsReadOnly}\n" +
                $"Last Changed: {fileInfo.LastWriteTime}";
        }
        private int[] GetVowelCounts(string allText, out int[] vowelCounts)
        {
            vowelCounts = new int[6]; // Store the 6 vowels 0-5 alphabetically
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };

            for (int i = 0; i < allText.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if (allText[i] == vowels[j])
                    {
                        vowelCounts[j]++;
                        break;
                    }
                }
            }
            return vowelCounts;
        }
        private string GetVowelOutputs(int[] vowelCounts)
        {
            StringBuilder sb = new();
            string[] vowels = { "A", "E", "I", "O", "U", "Y" };

            for (int i = 0; i < vowelCounts.Length; i++)
            {
                if (i == 5)
                {
                    if (vowelCounts[i] != 1)
                    {
                        sb.Append($"{vowelCounts[i]} Ys");
                    }
                    else
                    {
                        sb.Append($"1 Y");
                    }
                    break;
                }
                if (vowelCounts[0] != 1)
                {
                    sb.Append($"{vowelCounts[i]} {vowels[i]}s, ");
                }
                else
                {
                    sb.Append($"1 {vowels[i]}, ");
                }
            }
            return sb.ToString();
        }
    }
}