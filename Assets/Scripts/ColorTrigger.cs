using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject TargetObj;
    public MemoryFade Script;
    void Start()
    {
        Script = TargetObj.GetComponent<MemoryFade>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        { 
            Script.BeginFade = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
