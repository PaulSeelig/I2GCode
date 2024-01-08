using System;
using GUI_I2G;

interface IHistorySafe
{
    //A method that adds a HistoryEntry to the json file
    /// <summary>
    /// Takes a History parameter and the Path and safes the entry into the List and into a new file following the same path
    /// needs reference to the json library using System.Text.Json;
    /// </summary>
    public void SaveGcodeProject(HistoryEntry historyEntry)
    {
    }

}
