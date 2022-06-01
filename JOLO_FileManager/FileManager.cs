using System.Text;

namespace JOLO_FileManager
{
    public class FileManager
    {
        public string? FilePath { get; set; }

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
            // If not .txt return all 0's
            if (Path.GetExtension(FilePath) != ".txt") 
            {
                return "0 As, 0 Es, 0 Is, 0 Os, 0 Us, 0 Ys";
            }
            // Count vowels (Method Below)
            int[] vowelCounts = GetVowelCounts(
                File.ReadAllText(FilePath!)); // Whole .txt doc => String
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
        private int[] GetVowelCounts(string allText)
        {
            int[] vowelCounts = new int[6]; // Store the 6 vowels 0-5 alphabetically

            for (int i = 0; i < allText.Length; i++)
            {
                if (allText[i].ToString().ToLower() == "a")
                {
                    vowelCounts[0]++;
                }
                if (allText[i].ToString().ToLower() == "e")
                {
                    vowelCounts[1]++;
                }
                if (allText[i].ToString().ToLower() == "i")
                {
                    vowelCounts[2]++;
                }
                if (allText[i].ToString().ToLower() == "o")
                {
                    vowelCounts[3]++;
                }
                if (allText[i].ToString().ToLower() == "u")
                {
                    vowelCounts[4]++;
                }
                if (allText[i].ToString().ToLower() == "y")
                {
                    vowelCounts[5]++;
                }
            }
            return vowelCounts;
        }
        private string GetVowelOutputs(int[] vowelCounts)
        {
            StringBuilder sb = new();

            if (vowelCounts[0] != 1) // [0] == A's
            {
                sb.Append($"{vowelCounts[0]} As, ");
            }
            else
            {
                sb.Append("1 A, ");
            }
            if (vowelCounts[1] != 1) // [1] == E's
            {
                sb.Append($"{vowelCounts[1]} Es, ");
            }
            else
            {
                sb.Append("1 E, ");
            }
            if (vowelCounts[2] != 1) // [2] == I's
            {
                sb.Append($"{vowelCounts[2]} Is, ");
            }
            else
            {
                sb.Append("1 I, ");
            }
            if (vowelCounts[3] != 1) // [3] == O's
            {
                sb.Append($"{vowelCounts[3]} Os, ");
            }
            else
            {
                sb.Append("1 O, ");
            }
            if (vowelCounts[4] != 1) // [4] == U's
            {
                sb.Append($"{vowelCounts[4]} Us, ");
            }
            else
            {
                sb.Append("1 U, ");
            }
            if (vowelCounts[5] != 1) // [5] == Y's
            {
                sb.Append($"{vowelCounts[5]} Ys");
            }
            else
            {
                sb.Append("1 Y");
            }
            return sb.ToString();
        }
    }
}