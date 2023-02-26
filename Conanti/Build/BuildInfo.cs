using System;
using System.IO;
using System.Linq;

namespace Conanti.Build
{
    public static class BuildInfo
    {
        public static string[] SourceFiles = null!;
        public static string[] BuiltFiles = null!;
        public static string SourcePath = null!;
        public static string BuildPath = null!;
        public static void Generate(string srcDir)
        {
            SourcePath = srcDir;

            Directory.CreateDirectory(srcDir + "/../build");

            BuildPath = Path.GetFullPath(srcDir + "/../build");

            SourceFiles = getSourceFiles();

            BuiltFiles = getSourceFiles();
            for (int i = 0; i < BuiltFiles.Length; i++)
            {
                if (BuiltFiles[i].ToLower().EndsWith(".cnt"))
                    BuiltFiles[i] = Path.ChangeExtension(BuiltFiles[i], ".py");

                BuiltFiles[i] = BuiltFiles[i].Replace(SourcePath, BuildPath);
            }
        }
        private static string[] getSourceFiles()
        {
            return Directory.EnumerateFiles(SourcePath, "*.*", SearchOption.AllDirectories)
                                                .Where(fileName => Path.GetExtension(fileName).TrimStart('.').ToLowerInvariant() == "cnt").ToArray();
        }
    }
}
