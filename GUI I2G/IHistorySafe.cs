using System;
 
interface IHistorySafe
{
    //A method that adds a HistoryEntry to the json file
    /// <summary>
    /// Takes a History parameter and the Path and safes the entry into the List and into a new file following the same path
    /// needs reference to the json library using System.Text.Json;
    /// </summary>
    /// <param name="historyEntry"></param>
    /// <param name="existingEntries"></param>
    public void SaveGcodeProject(HistoryEntry historyEntry,string jsonFilePath)
    {
        //string jsonFromFile = File.ReadAllText(jsonFilePath); <- used to be like this might be slightly smarter to give the method the jsonFromFile 
        //could lead to NULL errors or Path errors
        //might slow down the programm creating a new List everytime the method is called
        List<HistoryEntry> existingEntries = JsonSerializer.Deserialize<List<HistoryEntry>>(jsonFilePath) ?? new List<HistoryEntry>();
        //adding the new entry
        existingEntries.Add(historyEntry);
        //saving new entry to json file
        string updatedJsonString = JsonSerializer.Serialize(existingEntries);
        File.WriteAllText(jsonFilePath, updatedJsonString);
    }

}
