using System;

public class History : IHistorySafe
{
	//Properties:
	//private s´o only inhouse methods can access it
	private List<HistoryEntry> history = new List<HistoryEntry> ();

	//Methods:

	public HistoryEntry GetEntries()
	{ 
		return history; 
	}

	public override void SafeGcodeProject()
	{

	}

	public History()
	{
	}
}
