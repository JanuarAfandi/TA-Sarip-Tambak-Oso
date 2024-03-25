using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    public enum BackgroundType { Static, Parallax }

    public BackgroundType backgroundType = BackgroundType.Static;
    public float parallaxSpeed = 0.5f; // Adjust this value to change parallax speed

    private Transform mainCameraTransform;
    private Vector3 lastCameraPosition;

    void Start()
    {
        mainCameraTransform = Camera.main.transform;
        lastCameraPosition = mainCameraTransform.position;
    }

    void FixedUpdate()
    {
        if (backgroundType == BackgroundType.Parallax)
        {
            // Calculate the distance the camera has moved since last frame
            float deltaX = mainCameraTransform.position.x - lastCameraPosition.x;
            float deltaY = mainCameraTransform.position.y - lastCameraPosition.y;

            // Move the background based on camera movement to create parallax effect
            transform.position += new Vector3(deltaX * parallaxSpeed, deltaY * parallaxSpeed, 0);

            // Update last camera position
            lastCameraPosition = mainCameraTransform.position;
        }
    }
}
