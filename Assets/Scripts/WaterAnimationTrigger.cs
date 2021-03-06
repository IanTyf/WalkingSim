using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAnimationTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public WaterAnimation[] waterAnims;
    public GameObject[] waterCubes;

    //public GameObject[] fences;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            for (int i = 0; i < waterAnims.Length; i++)
            {
                waterAnims[i].Active();
            }
            GameObject.FindObjectOfType<GameManager>().aquaShouldCrush = true;
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

        //fences = GameObject.FindGameObjectsWithTag("Fence");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
