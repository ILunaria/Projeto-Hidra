using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanternDebug : MonoBehaviour
{
    private FlashLight lantern;
    private TextMeshProUGUI text;
    // Update is called once per frame
    private void Start()
    {
        lantern = FindAnyObjectByType<FlashLight>().GetComponent<FlashLight>();
        text = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        text.SetText("Bateria Lanterna: " + lantern.CurrenBattery);
    }
}
