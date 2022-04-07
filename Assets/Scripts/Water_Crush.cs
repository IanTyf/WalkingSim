using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Crush : MonoBehaviour
{

    public GameObject Cube;
    public GameObject[] WaterPlanes;
    public float DelayTime = 0.5f;
    public GameObject[] Fishes;
    public float  ExplosionStrength;
    public Vector3 ExplosionPosition;
    public float ExplosionRadius;
    public float UpMod;
    
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
            Cube.GetComponent<Rigidbody>().AddForce(transform.up * 4, ForceMode.Impulse);
        }
        else 
        {
            Cube.GetComponent<Rigidbody>().AddExplosionForce(ExplosionStrength, ExplosionPosition, ExplosionRadius,UpMod,ForceMode.Impulse);
        }
  
        for (int j=0; j < Fishes.Length; j++) 
        {
            Destroy(Fishes[j]);
        }

        
    }

    public void WaterFall() 
    {
        Cube.GetComponent<Rigidbody>().useGravity = true;
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
