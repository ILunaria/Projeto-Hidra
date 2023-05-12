using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info_Inventory : MonoBehaviour
{
    [SerializeField] private List<Info_SO> infos = new List<Info_SO>();
    private Info_SO CurrentInfo;

    public delegate void SameInfo();
    public SameInfo same;

    public void SetCurrentInfo(Info_SO info)
    {
        CurrentInfo = info;
    }

    public void AddInfo()
    {
        if (CurrentInfo.Type == InfoType.IncostantInfo)
        {
            for (int i = 0; i < infos.Count; i++)
            {
                if (infos[i].Index == CurrentInfo.Index)
                {
                    if (same != null)
                    {
                        same();
                        return;
                    }
                    else return;
                }
            }
            infos.Add(CurrentInfo);
        }
        else
        {
            infos.Add(CurrentInfo);
        }
        Debug.Log(infos.Count);
    }
    public void OverWriteInfo()
    {
        for(int i = 0; i < infos.Count; i++)
        {
            if (infos[i].Index == CurrentInfo.Index)
            {
                infos[i] = CurrentInfo;
            }
        }
    }
    public void Set_SameInfo(SameInfo dele)
    {
        same += dele;
    }
}
