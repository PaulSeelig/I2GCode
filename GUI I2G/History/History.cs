using System;
using GUI_I2G;
using System.Text.Json;
using System.Collections.Generic;
using System.CodeDom;

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
	public HistoryEntry GetEntry(string projectName)
	{ 
		return (from entry in history where entry.projectName == projectName select entry).FirstOrDefault();
	}

	/// <summary>
	/// A method that hopefully returns the list sorted by LastOpened
	/// </summary>
	/// <returns>List sorted by LastOpened</returns>
    public List<HistoryEntry> GetHistoryByLast()
    {
        return history.OrderByDescending(entry => entry.lastOpened).ToList();
    }

	/// <summary>
	/// just a test method
	/// </summary>
	/// <returns>Count of History elements</returns>
	public int GetHistoryCount()
	{
		return history.Count;
	}

    /// <summary>
    /// Updates an existing history entry.
    /// </summary>
    /// <param name="updatedEntry">The updated history entry.</param>
    public void SaveChangesToProject(HistoryEntry updatedEntry)
    {
        // Find the index of the entry in the list
        int index = history.FindIndex(entry => entry.projectName == updatedEntry.projectName);

        // If the entry is found, update it
        if (index != -1)
        {
			updatedEntry.UpdateLastOpened();
            history[index] = updatedEntry;
        }

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
		File.WriteAllText(jsonFilePath, json);
    }

	/// <summary>
	/// Needs to be called with the start of Programm,
	/// creates the History List from safefile
	/// </summary>
	/// <param name="jsonFilePath"></param>
	public void OpenHistoryfromFile(string jsonFilePath)
	{
		string json = File.ReadAllText(jsonFilePath);
        history = JsonSerializer.Deserialize<List<HistoryEntry>>(json);
	}
}
