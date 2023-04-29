using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Door : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void CloseDoor()
    {
        if (anim.GetBool("Blocked")) return;

        bool isClosed = anim.GetBool("Closed");
        anim.SetBool("Closed", !isClosed);
    }
    public void BlockDoor()
    {
        bool isBlocked = anim.GetBool("Blocked");
        if (!anim.GetBool("Closed"))
        {
            return;
        }
        if (anim.GetBool("Closed") && !isBlocked)
        {
            anim.SetBool("Blocked", true);
        }
        else if (anim.GetBool("Closed") && isBlocked)
        {
            anim.SetBool("Blocked", false);
        }
    }
}
