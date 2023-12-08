using System;
using GUI_I2G;
using System.Text.Json;
using System.Collections.Generic;

public class History : IHistorySafe
{
	//Properties:
	//private so only inhouse methods can access it
	private List<HistoryEntry> history = new List<HistoryEntry> ();

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
	/// A method that hopefully returns the list sorted by LastOpened
	/// </summary>
	/// <returns>List sorted by LastOpened</returns>
    public List<HistoryEntry> GetHistoryByLast()
    {
        return history.OrderBy(entry => entry.lastOpened).ToList();
    }


    /// <summary>
    /// Adds a History object to the List and calls Save function (could change)
    /// </summary>
    /// <param name="entry">The history entry to be added.</param>
    public void SaveGcodeProject(HistoryEntry entry)
	{
		entry.UpdateLastOpened();
		history.Add(entry);
	}

    /// <summary>
	/// saves all Entries to the designated filepath
	/// </summary>
	/// <param name="jsonFilePath"></param>
    public void SaveHistoryToFile(string jsonFilePath)
	{
        string json = JsonSerializer.Serialize(history);
		File.WriteAllText(json, jsonFilePath);
    }

}
