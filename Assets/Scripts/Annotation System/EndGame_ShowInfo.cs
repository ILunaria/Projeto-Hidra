using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame_ShowInfo : MonoBehaviour
{
    [SerializeField] private Info_Inventory inventory;
    [SerializeField] private GameObject infoGO;
    [SerializeField] private Transform content;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventory.Infos.Count; i++)
        {
            GameObject obj = Instantiate(infoGO, content);
            EndGame_Info_UI info = obj.GetComponent<EndGame_Info_UI>();
            info.SetInfoUI(inventory.Infos[i]);
        }
    }
}
