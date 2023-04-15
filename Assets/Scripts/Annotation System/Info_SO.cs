using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Annotation",fileName = "Annotation_")]
public class Info_SO : ScriptableObject
{
    [SerializeField] private Phrase[] paragraphs;
    public Phrase[] Paragraphs => paragraphs;
}
[Serializable]
public class Phrase
{
    [TextArea(2,10)]
    [SerializeField] private string[] text;
    [SerializeField] private PhraseType type;

    public string[] Text => text;
    public PhraseType Type => type;
}
public enum PhraseType
{
    ConstantPhrase,
    InfoPhrase,
}
