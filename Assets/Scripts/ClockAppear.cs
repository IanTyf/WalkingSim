using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockAppear : MonoBehaviour
{
    public GameObject clock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i=0; i<clock.transform.childCount; i++)
            {
                clock.transform.GetChild(i).GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
