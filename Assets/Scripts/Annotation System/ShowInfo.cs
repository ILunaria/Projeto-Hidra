using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    [SerializeField] private Info_SO info;
    [Range(0,2)]
    [SerializeField] private int[] TypeInfo;
    private int actualInfo = 0;
    private string Paragraph = "";
    private TextMeshProUGUI textMesh;
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        for(int i = 0; i < info.Paragraphs.Length; i++)
        {
            if (info.Paragraphs[i].Type == PhraseType.InfoPhrase)
            {
                Paragraph += " " + info.Paragraphs[i].Text[TypeInfo[actualInfo]] + " ";
                actualInfo++;
            }
            else Paragraph += info.Paragraphs[i].Text[0];
        }
        textMesh.SetText(Paragraph);
    }

    IEnumerator TypeText()
    {
        textMesh.text = "";

        foreach (char letter in Paragraph)
        {
            textMesh.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
