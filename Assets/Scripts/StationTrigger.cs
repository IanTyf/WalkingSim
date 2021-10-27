using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    //public SationAnim StationAnim;
    private WaterLerp[] WaterLerps;
    public GameObject StationPlatform;

    void Start()
    {
        //StationAnim = GameObject.FindObjectOfType<SationAnim>();
        WaterLerps = GameObject.FindObjectsOfType<WaterLerp>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //StationAnim.AnimBegin();
            StationPlatform.SetActive(true);
            foreach (WaterLerp wl in WaterLerps)
            {
                wl.BeginLerp = true;
            }
            
            GameObject.FindObjectOfType<GameManager>().shouldSpawn = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
