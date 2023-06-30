using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lght : MonoBehaviour
{
    float timer = 5;
    Animator anim;
    private bool isBroken = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!isBroken) 
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                int x = Random.Range(1, 20);
                if (x > 15) { anim.Play("LightOff"); }
                timer = 5;
            }
        }
        
    }
    public void LightExplode()
    {
        anim.Play("LightsExplosion");
        isBroken = true;
    }
}
