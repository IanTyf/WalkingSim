using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public SationAnim StationAnim;
    public WaterLerp WaterLerp;

    void Start()
    {
        StationAnim = GameObject.FindObjectOfType<SationAnim>();
        WaterLerp = GameObject.FindObjectOfType<WaterLerp>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StationAnim.AnimBegin();
            WaterLerp.BeginLerp = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
