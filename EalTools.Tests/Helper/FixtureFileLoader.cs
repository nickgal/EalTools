namespace EalTools.Tests;

public static class FixtureFileLoader
{
    public static string GetFilePath(string fixtureDir, string fileName)
    {
        var runningDir = TestContext.CurrentContext.TestDirectory;
        var projectDir = Directory.GetParent(runningDir).Parent.Parent.FullName;
        var filePath = Path.Join(projectDir, fixtureDir, fileName);

        return filePath;
    }

    public static byte[] LoadFileToBytes(string fixtureDir, string fileName)
    {
        var filePath = GetFilePath(fixtureDir, fileName);
        return File.ReadAllBytes(filePath);
    }
}
