using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCrushTrigger : MonoBehaviour
{
    public Water_Crush[] WaterCrushes;

    // Start is called before the first frame update
    void Start()
    {
        WaterCrushes = GameObject.FindObjectsOfType<Water_Crush>();
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < WaterCrushes.Length; i++) 
        {
            WaterCrushes[i].BeginCrush();
        }
        
    }

  
    // Update is called once per frame
    void Update()
    {
        
    }
}