using UnityEngine;

public class PlayerBodySync : MonoBehaviour
{
    public Transform xrRig; // Reference to the XR Rig
    public Transform cameraTransform; // Reference to the Main Camera (Player's head)

    private CapsuleCollider capsuleCollider;

    void Start()
    {
        // Get the CapsuleCollider component
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        // Synchronize the Capsule Collider with the XR Rig's position
        Vector3 newPosition = xrRig.position;
        newPosition.y = cameraTransform.position.y - (capsuleCollider.height / 2); // Align with player's feet
        transform.position = newPosition;

        // Optionally adjust the height dynamically if player crouches or stands
        capsuleCollider.height = cameraTransform.position.y - xrRig.position.y;
    }
}
