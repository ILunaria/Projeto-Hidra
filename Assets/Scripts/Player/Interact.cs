using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    #region CHECKERS
    [SerializeField] private float checkRange = 2f;
    [SerializeField] private LayerMask interactMask;
    #endregion
    #region COMPONENTS
    private Animator anim;
    private InputActions inputs;
    private FlashLight flight;
    #endregion
    private Transform cameraTrans;
    [SerializeField] private GameObject interactIcon;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        flight = GetComponent<FlashLight>();
        inputs = new InputActions();
        cameraTrans = Camera.main.transform;

        inputs.Enable();
        inputs.Player.Interact.performed += Interact_Input;
        inputs.Player.Interact_02.performed += Interact_02_Input;
    }
    private void Interact_Input(InputAction.CallbackContext obj)
    {
        if(CanInteract())
        {
            InteractAction_01();
        }
    }
    private void Interact_02_Input(InputAction.CallbackContext obj)
    {
        if (CanInteract())
        {
            InteractAction_02();
        }
    }
    private void Update()
    {
        CanInteract();
        if (CanInteract()) { interactIcon.SetActive(true); }
        else { interactIcon.SetActive(false); }
    }
    private bool CanInteract()
    {
        Collider[] hitColliders = Physics.OverlapSphere(cameraTrans.position, checkRange, interactMask);

        foreach (Collider col in hitColliders)
        {
            if (col.tag == "Door")
            {
                Vector3 dirToTarget = Vector3.Normalize(col.transform.position - cameraTrans.position);

                float dot = Vector3.Dot(cameraTrans.forward, dirToTarget);

                if (dot > 0.5f)
                {
                    return true;
                }
            }
            if (col.tag == "Recharge")
            {
                Vector3 dirToTarget = Vector3.Normalize(col.transform.position - cameraTrans.position);

                float dot = Vector3.Dot(cameraTrans.forward, dirToTarget);

                if (dot > 0.5f)
                {
                    return true;
                }
            }
            if (col.tag == "Info")
            {
                Vector3 dirToTarget = Vector3.Normalize(col.transform.position - cameraTrans.position);

                float dot = Vector3.Dot(cameraTrans.forward, dirToTarget);

                if (dot > 0.95f)
                {
                    return true;
                }
            }
            if (col.tag == "Recharge")
            {
                Vector3 dirToTarget = Vector3.Normalize(col.transform.position - cameraTrans.position);

                float dot = Vector3.Dot(cameraTrans.forward, dirToTarget);

                if (dot > 0.5f)
                {
                    return true;
                }
            }
        }
        return false;
    }
    private void InteractAction_01()
    {
        Collider[] hitColliders = Physics.OverlapSphere(cameraTrans.position, checkRange, interactMask);

        foreach (Collider col in hitColliders)
        {
            if (col.tag == "Door")
            {
                Interact_Door door = col.gameObject.GetComponent<Interact_Door>();
                door.CloseDoor();
            }
            if (col.tag == "Info")
            {
                Info_GO inf = col.gameObject.GetComponent<Info_GO>();
                inf.OnInteract();
            }
            if (col.tag == "Recharge")
            {
                flight.StartRecharge();
            }
        }
    }
    private void InteractAction_02()
    {
        Collider[] hitColliders = Physics.OverlapSphere(cameraTrans.position, checkRange, interactMask);

        foreach (Collider col in hitColliders)
        {
            if (col.tag == "Door")
            {
                Interact_Door door = col.gameObject.GetComponent<Interact_Door>();
                door.BlockDoor();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, checkRange);
        
    }
}
