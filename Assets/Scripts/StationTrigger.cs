using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public SationAnim StationAnim;
    public WaterLerp[] WaterLerps;

    public DissolveMaterialSwap[] DissolveMaterialSwaps;
    public GameObject[] DissolveObjects;

    void Start()
    {
        StationAnim = GameObject.FindObjectOfType<SationAnim>();
        WaterLerps = GameObject.FindObjectsOfType<WaterLerp>();

        DissolveMaterialSwaps = GameObject.FindObjectsOfType<DissolveMaterialSwap>();
        DissolveObjects = new GameObject[DissolveMaterialSwaps.Length];
        for (int i = 0; i < DissolveMaterialSwaps.Length; i++)
        {
            DissolveObjects[i] = DissolveMaterialSwaps[i].gameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StationAnim.AnimBegin();
            foreach (WaterLerp wl in WaterLerps)
            {
                wl.BeginLerp = true;
            }
            
            GameObject.FindObjectOfType<GameManager>().shouldSpawn = true;

            foreach (GameObject obj in DissolveObjects)
            {
                if (obj.tag == "Station") obj.GetComponent<DissolveMaterialSwap>().Active();
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
