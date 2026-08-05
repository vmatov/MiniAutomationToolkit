using System;
using System.Collections.Generic;
using System.IO;

public class AppConfig
{
    private readonly Dictionary<string, string> _settings = new Dictionary<string, string>();

    public AppConfig(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        foreach (var line in File.ReadLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string trimmedLine = line.TrimStart();
            if (trimmedLine.StartsWith("#"))
            {
                continue;
            }

            string[] parts = line.Split(new[] { '=' }, 2);
            if (parts.Length != 2)
            {
                throw new InvalidDataException($"Invalid line: '{line}'. Expected format 'key=value'.");
            }

            string key = parts[0].Trim();
            string value = parts[1].Trim();

            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidDataException($"Invalid line: '{line}'. Key and value cannot be empty.");
            }

            if (_settings.ContainsKey(key))
            {
                throw new InvalidDataException($"Duplicate configuration key: '{key}'.");
            }

            _settings[key] = value;
        }
    }

    public T GetSetting<T>(string key)
    {
        if (!_settings.TryGetValue(key, out string? rawValue))
        {
            throw new KeyNotFoundException($"Key '{key}' not found in configuration.");
        }

        Type targetType = typeof(T);
        Type? underlyingType = Nullable.GetUnderlyingType(targetType);
        if (underlyingType != null)
        {
            targetType = underlyingType;
        }

        try
        {
            object convertedValue = Convert.ChangeType(rawValue, targetType);
            if (underlyingType != null)
            {
                return (T)convertedValue;
            }

            return (T)convertedValue;
        }
        catch (Exception ex) when (ex is InvalidCastException or FormatException or OverflowException)
        {
            throw new InvalidDataException($"Failed to convert value for key '{key}' to type '{typeof(T).Name}'.", ex);
        }
    }
}
