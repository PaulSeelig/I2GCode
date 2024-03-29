﻿using System;
using GUI_I2G;
using System.Text.Json;
using System.Collections.Generic;
using System.CodeDom;

//Authored by Paul Seelig s0578706
public class History :  IHistorySafe
{
	//Properties:
	//private so only inhouse methods can access it
	private List<HistoryEntry> history = new List<HistoryEntry> ();

	//Methods:
	/// <summary>
	/// returns the history entry with the given Project Name
	/// </summary>
	/// <param name="projectName"> the name required for the search </param>
	public HistoryEntry GetEntryByName(string projectName)
	{ 
		return history.Where(e => e.projectName == projectName).FirstOrDefault(); 
	}

	/// <summary>
	/// returns the HistoryEntry at the spezified index
	/// </summary>
	/// <param name="index"></param>
	/// <returns>returns a HistoryEntry object</returns>
	public HistoryEntry GetEntryByIndex(int index)
	{
		return history[index];
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
    /// a method to get the last five Projects by Name and Index to display them and find them using GetByIndex()
    /// should it be called after each save of a project?
    /// </summary>
    /// <param name="Indexes"></param>
    /// <returns>string array and hopefully an int array</returns>
    public HistoryEntry[] GetLastOpened() 
	{
        history = history.OrderByDescending(entry => entry.lastOpened).ToList();
        return history.ToArray();
	}

    /// <summary>
    /// Adds a History object to the List or updates an existing entry
    /// </summary>
    /// <param name="entry">The history entry to be added.</param>
    public void SaveGcodeProject(HistoryEntry entry)
	{
        // Find the index of the entry in the list
        int index = history.FindIndex(e => e.projectName == entry.projectName);

        // If the entry is found, update it
        if (index != -1)
        {
            entry.UpdateLastOpened();
            history[index] = entry;
        } 
		else
		{
			entry.UpdateLastOpened();
			history.Add(entry); 
		}
	}

	public void DeleteGcodeProject(int index)
	{
		history.RemoveAt(index);
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
	public void OpenHistoryFromFile(string jsonFilePath)
	{
        string json = File.ReadAllText(jsonFilePath);
        history = JsonSerializer.Deserialize<List<HistoryEntry>>(json);
	}
}
