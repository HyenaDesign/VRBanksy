using UnityEngine;

public class VisibilityTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject targetElement; // Het element dat zichtbaar moet worden

    private void Start()
    {
        // Zorg ervoor dat het element onzichtbaar is bij het begin
        if (targetElement != null)
        {
            targetElement.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Controleer of het de XR Rig is (of een specifiek onderdeel daarvan)
        if (other.CompareTag("XR Rig")) // Zorg ervoor dat de XR Rig de tag "XR Rig" heeft
        {
            if (targetElement != null)
            {
                targetElement.SetActive(true); // Maak het element zichtbaar
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Optioneel: Element onzichtbaar maken als de XR Rig de box verlaat
        if (other.CompareTag("XR Rig"))
        {
            if (targetElement != null)
            {
                targetElement.SetActive(false);
            }
        }
    }
}
