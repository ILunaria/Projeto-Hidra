using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    #region COMPONENTS
    private InputActions inputs;
    private Animator anim;
    [SerializeField] private Slider batteryBar;
    #endregion

    [SerializeField] private float batteryDuration;
    private float currentBattery;

    private bool isOn = false;
    private bool canUse;

    private void Start()
    {
        anim = GetComponent<Animator>();
        inputs = new InputActions();

        inputs.Enable();
        inputs.Player.FlashLight.performed += FlashLight_Input;

        currentBattery = batteryDuration;
        batteryBar.maxValue = batteryDuration;
    }
    private void Update()
    {
        if (GameManager.isPaused) return;
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

        batteryBar.value = currentBattery;
    }
    private void FlashLight_Input(InputAction.CallbackContext obj)
    {
        if (GameManager.isPaused) return;
        if (!isOn && canUse) FlashLightOn();
        else FlashLightOff();
    }
    private void FlashLightOff()
    {
        anim.CrossFade("Lantern_Off", 1f,1);
        isOn = false;
    }
    private void FlashLightOn()
    {
        anim.CrossFade("Lantern_On", 1f,1);
        isOn = true;
    }
    public void StartRecharge()
    {
        FlashLightOff();
        GameManager.SetPaused(true);

        StartCoroutine(Recharge());

        StopRecharge();
    }
    public void StopRecharge()
    {
        GameManager.SetPaused(false);
    }
    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(5);
    }
}
