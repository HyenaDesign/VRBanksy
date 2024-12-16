using UnityEngine;
using TMPro;

public class NarrationManager : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource for narration playback
    public TextMeshProUGUI textDisplay; // TextMeshPro for displaying alineas
    public NarrationData currentNarration; // The narration data to play

    private int currentAlineaIndex = 0; // Tracks the current alinea being displayed

    private void Start()
    {
        if (currentNarration != null)
        {
            StartNarration(currentNarration);
        }
    }

    public void StartNarration(NarrationData narrationData)
    {
        // Initialize narration
        currentNarration = narrationData;
        currentAlineaIndex = 0;

        // Set audio source and start playback
        audioSource.clip = currentNarration.narrationClip;
        audioSource.Play();

        // Start update loop
        InvokeRepeating(nameof(UpdateAlineaDisplay), 0, 0.1f); // Update at 10Hz
    }

    private void UpdateAlineaDisplay()
    {
        if (audioSource.isPlaying && currentNarration != null)
        {
            float currentTime = audioSource.time;

            // Check if we need to update the displayed alinea
            if (currentAlineaIndex < currentNarration.alineas.Count &&
                currentTime <= currentNarration.alineas[currentAlineaIndex].endTime)
            {
                DisplayAlinea(currentNarration.alineas[currentAlineaIndex].alineaText);
            }
            else if (currentAlineaIndex < currentNarration.alineas.Count)
            {
                currentAlineaIndex++; // Move to the next alinea
            }
        }
        else
        {
            CancelInvoke(nameof(UpdateAlineaDisplay)); // Stop updates when narration ends
        }
    }

    private void DisplayAlinea(string alineaText)
    {
        textDisplay.text = alineaText;
    }

    public void StopNarration()
    {
        // Stop narration and reset text
        audioSource.Stop();
        CancelInvoke(nameof(UpdateAlineaDisplay));
        textDisplay.text = "";
    }
}
