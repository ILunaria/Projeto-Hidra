using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    private bool isClosed;

    private LayerMask interactMask;
    private Animator anim;
    private InputActions inputs;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        inputs = new InputActions();

        inputs.Enable();
        inputs.Player.Interact.performed += Interact_Input;
    }
    private void Interact_Input(InputAction.CallbackContext obj)
    {
        
    }
    private void CheckInteract()
    {
        var obj = Physics.CheckSphere(transform.position, 3, interactMask);
    }
}
