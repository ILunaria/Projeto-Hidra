using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Trigger : MonoBehaviour
{
    [SerializeField] private GameObject[] lightGO;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            int x = Random.Range(1, 10);
            if (x < 3)
            {
                for(int i = 0; i < lightGO.Length; i++) 
                {
                    Lght script = lightGO[i].GetComponent<Lght>();
                    script.LightExplode();
                }
            }
        }
    }
}
