using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info_GO : MonoBehaviour
{
    [SerializeField] private Info_SO info;

    private Info_Inventory inventory;
    private Info_UI ui;
    public Info_SO Info => info;

    private void Start()
    {
        ui = FindObjectOfType<Info_UI>().GetComponent<Info_UI>();
        inventory = FindObjectOfType<Info_Inventory>().GetComponent<Info_Inventory>();
    }
    public void OnInteract()
    {
        inventory.SetCurrentInfo(Info);
        ui.SetText(info, gameObject);
    }
}
