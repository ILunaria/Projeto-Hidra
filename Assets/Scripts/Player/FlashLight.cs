using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLight : MonoBehaviour
{
    private InputActions inputs;
    private Animator anim;
    private CameraControll cam;

    private bool isOn = false;
    // Start is called before the first frame update
    private void Awake()
    {
        cam = FindObjectOfType<CameraControll>().GetComponent<CameraControll>();
        anim = GetComponent<Animator>();
        inputs = new InputActions();

        inputs.Enable();
        inputs.Player.FlashLight.performed += FlashLight_Input;
    }
    private void Update()
    {
        Vector3 worldAimTarget = cam.MouseWorldPostion;
        Vector3 aimDirection = Vector3.Normalize(worldAimTarget - transform.position);
        transform.forward = Vector3.Lerp(transform.forward, aimDirection, 4f * Time.deltaTime);
    }
    private void FlashLight_Input(InputAction.CallbackContext obj)
    {
        Debug.Log(obj);
        if (isOn) FlashLightOff();
        else FlashLightOn();
    }
    private void FlashLightOff()
    {
        anim.Play("FlashOff");
        isOn = false;
    }
    private void FlashLightOn()
    {
        anim.Play("FlashOn");
        isOn = true;
    }
}
