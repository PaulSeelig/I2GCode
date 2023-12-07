using System;
using GUI_I2G;
using System.Text.Json;
using System.Collections.Generic;

public class History : IHistorySafe
{
	//Properties:
	//private so only inhouse methods can access it
	private List<HistoryEntry> history = new List<HistoryEntry> ();

	private string jsonFilePath; //needs to designate a default don't know how yet

	//Methods:
	/// <summary>
	/// returns the history entry with the given Project Name
	/// </summary>
	/// <param name="projectName"> the name required for the search </param>
	public HistoryEntry GetEntries(string projectName)
	{ 
		return (from entry in history where entry.projectName == projectName select entry).FirstOrDefault();
	}

    /// <summary>
    /// Adds a History object to the List and calls Save function (could change)
    /// </summary>
    /// <param name="entry">The history entry to be added.</param>
    public void SaveGcodeProject(HistoryEntry entry)
	{
		history.Add(entry);
		SaveHistoryToFile();
	}

    /// <summary>
    /// Saves the List of HistoryEntries to a jsonfile
    /// </summary>
    public void SaveHistoryToFile()
	{
        string json = JsonSerializer.Serialize(history);
		File.WriteAllText(json, jsonFilePath);
    }

	public History(string filePath)
	{
		jsonFilePath = filePath;
	}
}
