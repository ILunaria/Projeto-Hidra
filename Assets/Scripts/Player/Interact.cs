using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    #region CHECKERS
    private float checkRange = 3f;
    private LayerMask interactMask;
    #endregion
    #region COMPONENTS
    private Animator anim;
    private InputActions inputs;
    #endregion
    private float holdTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        inputs = new InputActions();

        inputs.Enable();
        inputs.Player.Interact.performed += Interact_Input;
        inputs.Player.Interact_02.performed += Interact_02_Input;
    }
    private void Interact_Input(InputAction.CallbackContext obj)
    {
        if(CanInteract())
        {
            CheckInteract();
        }
    }
    private void Interact_02_Input(InputAction.CallbackContext obj)
    {
        if (CanInteract())
        {
            BlockDoor();
        }
    }
    private void Update()
    {
        CanInteract();
    }
    private void CheckInteract()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, checkRange);

        foreach (Collider col in hitColliders)
        {
            if (col.tag == "Door")
            {
                anim = col.gameObject.GetComponent<Animator>();

                if (anim.GetBool("Blocked")) return;

                bool isClosed = anim.GetBool("Closed");
                anim.SetBool("Closed", !isClosed);
            }
        }
    }
    private bool CanInteract()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, checkRange);

        foreach (Collider col in hitColliders)
        {
            if (col.tag == "Door")
            {
                Vector3 dirToTarget = Vector3.Normalize(col.transform.position - this.transform.position);

                float dot = Vector3.Dot(this.transform.forward, dirToTarget);

                if (dot > 0.2f)
                {
                    return true;
                }
            }
        }
        return false;
    }
    private void BlockDoor()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, checkRange);

        foreach (Collider col in hitColliders)
        {
            if (col.tag == "Door")
            {
                anim = col.gameObject.GetComponent<Animator>();

                bool isBlocked = anim.GetBool("Blocked");
                if (!anim.GetBool("Closed"))
                {
                    return;
                }

                if (anim.GetBool("Closed") && !isBlocked)
                {
                    anim.SetBool("Blocked", true);
                }
                else if(anim.GetBool("Closed") && isBlocked)
                {
                    anim.SetBool("Blocked", false);
                }
                
            }
        }
    }
}
