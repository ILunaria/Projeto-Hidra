using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGame_Info_UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI text;
    public void SetInfoUI(Info_SO info)
    {
        title.SetText(info.Title);
        text.SetText(info.Text);
    }
}
