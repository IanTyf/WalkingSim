using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BastionEffect : MonoBehaviour
{

    public Material[] mats;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Material m in mats)
        {
            m.SetVector("_PlayerPos", transform.position);
        }
    }
}
