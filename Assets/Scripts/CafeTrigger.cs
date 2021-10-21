using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeTrigger : MonoBehaviour
{

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
        foreach (GameObject obj in DissolveObjects)
        {
            obj.GetComponent<DissolveMaterialSwap>().Active();
        }

        foreach (GameObject obj in BastionObjects)
        {
            obj.GetComponent<BastionMaterialSwap>().Active();
        }
    }
}
