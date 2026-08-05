using System;

public static class FileSearcher
{
public static string FindFirstScreenshot(List<string> fileNames)
	{
		var screenshotFiles = fileNames.FirstOrDefault(fileName => fileName.ToLowerInvariant().EndsWith(".png"));
		if (screenshotFiles == null)
		{
			throw new InvalidOperationException("No screenshots found in the provided list.");
		}
		return screenshotFiles;
	}
}
