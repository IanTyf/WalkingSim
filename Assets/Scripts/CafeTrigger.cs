using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeTrigger : MonoBehaviour
{
    //public GameObject Particle;

    public DissolveMaterialSwap[] DissolveMaterialSwaps;
    public GameObject[] DissolveObjects;

    public BastionMaterialSwap[] BastionMaterialSwaps;
    public GameObject[] BastionObjects;

    // Start is called before the first frame update
    void Start()
    {
        DissolveMaterialSwaps = GameObject.FindObjectsOfType<DissolveMaterialSwap>();
        DissolveObjects = new GameObject[DissolveMaterialSwaps.Length];
        for (int i=0; i<DissolveMaterialSwaps.Length; i++)
        {
            DissolveObjects[i] = DissolveMaterialSwaps[i].gameObject;
        }

        BastionMaterialSwaps = GameObject.FindObjectsOfType<BastionMaterialSwap>();
        BastionObjects = new GameObject[BastionMaterialSwaps.Length];
        for (int i=0; i<BastionMaterialSwaps.Length; i++)
        {
            BastionObjects[i] = BastionMaterialSwaps[i].gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Particle.GetComponent<ParticleMovement>().disappear = true;
        if (other.tag == "Player")
        {
            foreach (GameObject obj in DissolveObjects)
            {
                if ((obj.tag != "road") && (obj.tag != "Fence") && (obj.tag != "Station")) obj.GetComponent<DissolveMaterialSwap>().Active();
            }

            foreach (GameObject obj in BastionObjects)
            {
                if ((obj.tag != "road") && (obj.tag != "Fence") && (obj.tag != "Station") && (obj.tag != "FinalStairs") && (obj.tag != "AquaSeat")) obj.GetComponent<BastionMaterialSwap>().Active();
            }
        }
    }
}
