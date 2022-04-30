namespace Satistools.ImageMove;

/// <summary>
/// A tool for recursive copying of files under the BaseDir to TargetDir.
/// </summary>
public class Mover
{
    /// <summary>
    /// Base dir from which the image are analysed
    /// </summary>
    private readonly string _baseDir;
    
    /// <summary>
    /// Target dir where the images are copied.
    /// </summary>
    private readonly string _targetDir;

    public Mover(string baseDir, string targetDir)
    {
        _baseDir = baseDir;
        _targetDir = targetDir;
    }

    /// <summary>
    /// Runs the directory processing.
    /// </summary>
    public void Run()
    {
        ProcessDirectory(_baseDir);
    }

    /// <summary>
    /// Get all files and subdirectories and recursively process others.
    /// </summary>
    /// <param name="directory">The directory to be processed.</param>
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

    /// <summary>
    /// Copy the found file to location if it doesn't exists yet.
    /// </summary>
    /// <param name="filePath">The path of the file.</param>
    /// <param name="sourceDir">Directory in which the file was found.</param>
    private void ProcessFile(string filePath, string sourceDir)
    {
        string fileName = filePath[(sourceDir.Length + 1)..];
        Console.WriteLine($"Copying {fileName}");
        string targetPath = Path.Combine(_targetDir, fileName);

        if (File.Exists(targetPath))
        {
            Console.WriteLine($"Target path {targetPath} already exists, skipping");
            return;
        }
        
        File.Copy(filePath, targetPath);
    }
}