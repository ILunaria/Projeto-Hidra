using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lght : MonoBehaviour
{
    float timer = 5;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            int x = Random.Range(1, 10);
            if(x > 6) { anim.Play("LightOff"); }
            timer = 5;
        }
    }
}
