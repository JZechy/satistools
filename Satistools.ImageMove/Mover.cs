namespace Satistools.ImageMove;

/// <summary>
/// A tool for recursive copying of files under the BaseDir to TargetDir.
/// </summary>
public class Mover
{
    private readonly string _baseDir;
    private readonly string _targetDir;

    public Mover(string baseDir, string targetDir)
    {
        _baseDir = baseDir;
        _targetDir = targetDir;
    }

    public void Run()
    {
        ProcessDirectory(_baseDir);
    }

    private void ProcessDirectory(string directory)
    {
        Console.WriteLine($"Processing directory {directory}");
        string[] files = Directory.GetFiles(directory, "*.png");
        foreach (string file in files)
        {
            ProcessFile(file, directory);
        }

        string[] subDirs = Directory.GetDirectories(directory);
        foreach (string dir in subDirs)
        {
            ProcessDirectory(dir);
        }
    }

    private void ProcessFile(string filePath, string sourceDir)
    {
        string fileName = filePath[(sourceDir.Length + 1)..];
        Console.WriteLine($"Copying {fileName}");
        string targetPath = Path.Combine(_targetDir, fileName);

        if (File.Exists(targetPath))
        {
            Console.WriteLine($"Target path {targetPath} already exists");
            return;
        }
        
        File.Copy(filePath, targetPath);
    }
}