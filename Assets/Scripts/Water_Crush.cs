using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Crush : MonoBehaviour
{

    public GameObject Cube;
    public GameObject[] WaterPlanes;
    public float DelayTime = 0.5f;
    public GameObject[] Fishes;
    // Start is called before the first frame update

    public void WaterCrush() 
    {
        for (int i=0;i<WaterPlanes.Length; i++) 
        {
            WaterPlanes[i].SetActive(false);
        }

        Cube.SetActive(true);

        if (Cube.tag == "CenterWaterCube")
        {
            Cube.GetComponent<Rigidbody>().AddForce(transform.up * 3, ForceMode.Impulse);
        }
  
        for (int j=0; j < Fishes.Length; j++) 
        {
            Destroy(Fishes[j]);
        }

        
    }

    public void BeginCrush() 
    {
        if (DelayTime == 0)
            WaterCrush();
        else 
        {
            StartCoroutine(delay());
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(DelayTime);
        WaterCrush();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
