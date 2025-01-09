using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 5.0f; // Speed of camera movement
    public float sensitivity = 3.0f; // Sensitivity for mouse movement

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Update()
    {
        
        Debug.Log("Update is running");


        // Move camera with WASD keys
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime; // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;   // W/S or Up/Down
        transform.Translate(new Vector3(moveX, 0, moveZ));
    

        // Rotate camera with mouse
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f); // Prevent flipping

        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);
    }
}