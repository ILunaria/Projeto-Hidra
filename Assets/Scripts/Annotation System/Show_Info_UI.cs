using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Show_Info_UI : MonoBehaviour
{
    [SerializeField] private GameObject annotationUI;
    [SerializeField] private GameObject infoButton;
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private TextMeshProUGUI text;

    private Info_Inventory inventory;
    private InputActions input;

    private bool inUI;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindAnyObjectByType<Info_Inventory>().GetComponent<Info_Inventory>();
        input = new InputActions();
        input.Player.Enable();
        input.Player.Annotations.performed += Annotation_Input;
    }
    private void Annotation_Input(InputAction.CallbackContext obj)
    {
        Debug.Log(GameManager.isPaused);
        if (GameManager.isPaused) return;
        else AnnotationUI();
    }
    private void AnnotationUI()
    {
        if(inUI)
        {
            CloseUI();
        }
        else
        {
            OpenUI();
        }
    }
    private void OpenUI()
    {
        annotationUI.SetActive(true);
        inUI = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        ShowButtons();
    }
    private void CloseUI()
    {
        annotationUI.SetActive(false);
        inUI = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
    private void ShowButtons()
    {
        foreach(Transform buttons in buttonContainer)
        {
            Destroy(buttons.gameObject);
        }
        if(inventory.Infos.Count > 0)
        {
            for (int i = 0; i < inventory.Infos.Count; i++)
            {
                GameObject obj = Instantiate(infoButton, buttonContainer);
                Show_Info_Button button = obj.GetComponent<Show_Info_Button>();

                button.SetVars(inventory.Infos[i], text);
            }
        }
    }
}
