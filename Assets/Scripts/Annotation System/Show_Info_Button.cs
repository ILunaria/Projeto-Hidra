using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Show_Info_Button : MonoBehaviour
{
    private Info_SO info;
    private TextMeshProUGUI InfoText;
    [SerializeField] private TextMeshProUGUI InfoTitle;
    public void SetVars(Info_SO _info, TextMeshProUGUI _text)
    {
        info = _info;
        InfoText = _text;
        InfoTitle.SetText(_info.Title);
    }
    public void ShowInfo()
    {
        InfoText.SetText(info.Text);
    }
}
