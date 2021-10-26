using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void ReverseRun() 
    {
        GetComponent<Animator>().SetBool("ReverseRunBegin", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
