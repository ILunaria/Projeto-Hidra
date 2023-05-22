using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextMeshProUGUI = TMPro.TextMeshProUGUI;

public class Info_UI : MonoBehaviour
{
    [SerializeField] private GameObject popUp;
    [SerializeField] private GameObject infoUI;
    [SerializeField] private TextMeshProUGUI text;

    private Info_Inventory inventory;
    private GameObject GO;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindAnyObjectByType<Info_Inventory>().GetComponent<Info_Inventory>();

        inventory.Set_SameInfo(SameInfo);
    }
    public void OpenInfo(Info_SO info, GameObject obj)
    {
        GO = obj;
        infoUI.SetActive(true);
        text.SetText(info.Text);

        GameManager.SetPaused(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void SameInfo()
    {
        popUp.SetActive(true);
        GameManager.SetPaused(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void DestroyInfo()
    {
        Destroy(GO);
        GameManager.SetPaused(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
}
