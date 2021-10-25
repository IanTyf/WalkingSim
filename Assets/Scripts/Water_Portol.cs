using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Portol : MonoBehaviour
{
    // Start is called before the first frame update
    public Whale Whale;

    public void PlayeWhaleAnim() 
    {
        Whale.Active();
        Whale.Whaleanim = true;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
