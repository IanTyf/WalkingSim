using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SationAnim : MonoBehaviour
{
    
    public GameObject Train;
    public GameObject Water;
    

    public void AnimBegin()
    {
        //Train.gameObject.SetActive(true);
        Water.gameObject.SetActive(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
