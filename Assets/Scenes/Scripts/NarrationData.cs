using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AlineaData
{
    public float endTime; // When this alinea ends
    public string alineaText; // Text for this alinea
}

[CreateAssetMenu(fileName = "NarrationData", menuName = "Narration/NarrationData")]
public class NarrationData : ScriptableObject
{
    public string narrationName; // Name of the narration
    public AudioClip narrationClip; // Narration audio file
    public List<AlineaData> alineas; // List of alineas and their end times
}
