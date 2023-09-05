using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;    // The player's Transform component
    public Vector3 offset;      // Offset distance between the player and camera
    public float x;             // X Offset 
    public float y;             // Y Offset 
    public float smoothSpeed = 0.125f;  // The speed of camera following the player
    public float zoomSpeed = 2f;  // The speed of zooming

    private Camera cam; // The Camera component

    public Player_Skript player1;
    private bool isFacingRight;

    private void Start()
    {
        cam = GetComponent<Camera>();  // Get the Camera component
    }

    private void FixedUpdate ()
    {
        
        if(player1 != null){
            isFacingRight = player1.FacingRight;
            if(player1.FacingRight)
            {
                offset.x = x;
            }
            else
            {
                offset.x = -x;   
            }
        }
        // Adjust the offset based on x and y values
        // offset.x = x;
        // offset.y = y;
        
        // Desired position is player's position with the offset
        Vector3 desiredPosition = player.position + offset;

        // Lerp from current position to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Fix the z position to -10
        smoothedPosition.z = -10f;

        // Update the position of the camera
        transform.position = smoothedPosition;

        // Zoom the camera based on the zoom speed
        cam.fieldOfView -= zoomSpeed * Time.deltaTime;

        // Limit the field of view to prevent it from going too low or too high
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, 15f, 90f);
    }
}
