using System;
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
