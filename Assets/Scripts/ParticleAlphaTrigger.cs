using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAlphaTrigger : MonoBehaviour
{
    private GameObject Particle;
    public bool disappear;


    // Start is called before the first frame update
    void Start()
    {
        Particle = GameObject.Find("Particle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (disappear) Particle.GetComponent<ParticleMovement>().disappear = true;
            else Particle.GetComponent<ParticleMovement>().disappear = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //Particle.GetComponent<ParticleMovement>().disappear = false;
        }
    }
}
