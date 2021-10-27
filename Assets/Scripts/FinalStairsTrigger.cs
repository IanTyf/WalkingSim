using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalStairsTrigger : MonoBehaviour
{
    public BastionMaterialSwap[] BastionMaterialSwaps;
    public GameObject[] BastionObjects;

    public GameObject FinalParticleTrigger;
    // Start is called before the first frame update
    void Start()
    {
        BastionMaterialSwaps = GameObject.FindObjectsOfType<BastionMaterialSwap>();
        BastionObjects = new GameObject[BastionMaterialSwaps.Length];
        for (int i = 0; i < BastionMaterialSwaps.Length; i++)
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
        if (other.tag == "Player")
        {
            foreach (GameObject obj in BastionObjects)
            {
                if (obj != null)
                {
                    if (obj.tag == "FinalStairs")
                    {
                        obj.GetComponent<BastionMaterialSwap>().Active();
                    }
                }
            }
            FinalParticleTrigger.SetActive(true);
        }
    }
}
