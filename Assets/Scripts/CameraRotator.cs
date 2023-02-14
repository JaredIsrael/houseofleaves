using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] float sensitivityX, sensitivityY;
    [SerializeField] Transform mainCam;

    private float xAxis, yAxis;
    private float xClamp = 85f;
    private float xRotation = 0f;
    private bool isDisabled = false;

    private void Update()
    {

        if (!isDisabled)
        {
            transform.Rotate(Vector3.up, xAxis * Time.deltaTime);

            xRotation -= yAxis;
            xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
            Vector3 rotation = transform.eulerAngles;
            rotation.x = xRotation;

            mainCam.eulerAngles = rotation;
        }

    }

    public void ReadInput(Vector2 mouseInput)
    {
        xAxis = mouseInput.x * sensitivityX;
        yAxis = mouseInput.y * sensitivityY;
    }

    public void DisableCameraMovement()
    {
        isDisabled = true;
    }
}
