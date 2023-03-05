using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{

    public float lookSenitivity = 5;
    public float lookSmoothDamp = 0.1f;
    public float xRotation;
    public float yRotation;
    public float xRotationV;
    public float yRotationV;
    public float currentXRotation;
    public float currentYRotation;
    [HideInInspector]
    public float lStickHorizontal;
    [HideInInspector]
    public float lStickVertical;
    public float lStickV;
    public float lStickH;


    public void Update()
    {
        lStickHorizontal = Input.GetAxis("JoystickX");
        lStickVertical = Input.GetAxis("JoystickY");

        lStickH = lStickHorizontal;
        lStickV = lStickVertical;

        xRotation += Input.GetAxis("JoystickY") * lookSenitivity;
        yRotation += Input.GetAxis("JoystickX") * lookSenitivity;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothDamp);
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        transform.position = transform.position;
    }
}