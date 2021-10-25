using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public SationAnim StationAnim;

    void Start()
    {
        StationAnim = GameObject.FindObjectOfType<SationAnim>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StationAnim.AnimBegin();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
