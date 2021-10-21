using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAnimationTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public WaterAnimation[] waterAnims;
    public GameObject[] waterCubes;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < waterAnims.Length; i++) 
        {
            waterAnims[i].Active();
        }
    }

    void Start()
    {
        waterAnims = GameObject.FindObjectsOfType<WaterAnimation>();
        waterCubes = new GameObject[waterAnims.Length];
        for (int i=0; i<waterAnims.Length; i++)
        {
            waterCubes[i] = waterAnims[i].gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
