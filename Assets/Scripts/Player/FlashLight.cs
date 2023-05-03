using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class FlashLight : MonoBehaviour
{
    #region COMPONENTS
    private InputActions inputs;
    private Animator anim;
    #endregion

    [SerializeField] private float batteryDuration;
    private float currentBattery;

    public float CurrenBattery => currentBattery; 

    private bool isOn = false;
    private bool isRecharging = false;
    private bool canUse;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        inputs = new InputActions();

        inputs.Enable();
        inputs.Player.FlashLight.performed += FlashLight_Input;

        currentBattery = batteryDuration;
    }
    private void Update()
    {
        if (isRecharging)
        {
            Mathf.Lerp(currentBattery, batteryDuration, 1f);
            return;
        }
        if (isOn)
        {
            currentBattery -= Time.deltaTime;
            if(currentBattery < 0)
            {
                canUse = false;
                FlashLightOff();
            }
        }
        if(currentBattery > 0) canUse = true;
        

    }
    private void FlashLight_Input(InputAction.CallbackContext obj)
    {
        if (!isOn && canUse) FlashLightOn();
        else FlashLightOff();
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
    private void StartRecharge()
    {
        isRecharging = true;
    }
    private void StopRecharge()
    {
        isRecharging = false;
    }
}
