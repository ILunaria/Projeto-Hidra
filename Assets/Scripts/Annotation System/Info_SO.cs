using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Info",fileName = "Info_")]
public class Info_SO : ScriptableObject
{
    [TextArea(2, 10)]
    [SerializeField] private string text;
    [SerializeField] private string index;
    [SerializeField] private InfoType type;

    public string Text => text;
    public string Index => index;
    public InfoType Type => type;
}
public enum InfoType
{
    ConstantInfo,
    IncostantInfo,
}
