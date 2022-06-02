using System.Text;

namespace JOLO_FileManager
{
    public class FileManager
    {
        public string FilePath { get; set; }
        public FileManager(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath)); // If null throw ex
        }
        public bool FileExists()
        {
            return File.Exists(FilePath);
        }
        public string DirectoryName()
        {
            return Directory.GetParent(FilePath).Name;
        }
        public string LargestFileInCurrentDirectory()
        {
            FileInfo[] files = Directory.GetParent(FilePath).GetFiles(); 
            // Stores files in FileInfo[] in ascending order of name by default
            if (files.Length == 0) // No files in DIR logic
            {
                return "No files in DIR";
            }

            FileInfo largestFile = files[0]; // Set first file as largest

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Length > largestFile.Length) // Replace largest if found
                {
                    largestFile = files[i];
                }    
            }
            return largestFile.Name;
        }
        public string VowelWeight()
        {
            if (Path.GetExtension(FilePath) != ".txt") // If not .txt, return all 0's
            {
                return "0 As, 0 Es, 0 Is, 0 Os, 0 Us, 0 Ys";
            }
            // Count vowels and store in a int[] (Method Below)
            GetVowelCounts(File.ReadAllText(FilePath).ToLower(), out int[] vowelCounts);
            // Output vowels in correct format (Method Below)
            return GetVowelOutputs(vowelCounts);
        }
        public string FileName()
        {
            return Path.GetFileNameWithoutExtension(FilePath);
        }
        public string FileExtension()
        {
            return Path.GetExtension(FilePath);
        }
        public byte[]? GetByteArray()
        {
            return File.ReadAllBytes(FilePath);
        }
        public override string ToString()
        {
            FileInfo fileInfo = new(FilePath); // Grab info via FileInfo of the file path
            return
                $"File Path: {FilePath}\n" +
                $"Size: {fileInfo.Length}\n" +
                $"Is Read Only: {fileInfo.IsReadOnly}\n" +
                $"Last Changed: {fileInfo.LastWriteTime}";
        }
        public static int[] GetVowelCounts(string allText, out int[] vowelCounts)
        {
            vowelCounts = new int[6]; // Vowels are stored 0-5 alphabetically
            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };

            for (int i = 0; i < allText.Length; i++) // Each char in text document
            {
                for (int j = 0; j < vowels.Length; j++) // Check for a match with every vowel
                {
                    if (allText[i] == vowels[j])
                    {
                        vowelCounts[j]++; // Increment count
                        break;
                    }
                }
            }
            return vowelCounts;
        }
        public static string GetVowelOutputs(int[] vowelCounts)
        {
            StringBuilder sb = new();
            string[] vowels = { "A", "E", "I", "O", "U", "Y" }; // Keeping consistant vowel format throughout class

            for (int i = 0; i < vowelCounts.Length; i++)
            {
                if (i == 5) // If on last vowel, do not add ", " @ end
                {
                    if (vowelCounts[i] != 1)
                    {
                        sb.Append($"{vowelCounts[i]} Ys");
                        break;
                    }
                    sb.Append($"1 Y");
                    break;
                }
                if (vowelCounts[i] != 1) // If not 1 vowel, use plural
                {
                    sb.Append($"{vowelCounts[i]} {vowels[i]}s, "); // Add ", " on end for formatting
                    continue;
                }
                sb.Append($"1 {vowels[i]}, ");
            }
            return sb.ToString();
        }
    }
}