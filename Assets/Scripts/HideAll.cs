using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAll : MonoBehaviour
{
    public GameObject keptObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Transform[] allObjs = GameObject.FindObjectsOfType<Transform>();
            foreach (Transform t in allObjs)
            {
                GameObject obj = t.gameObject;
                if (!(obj.tag == "Player") && !(obj.Equals(this.gameObject)) 
                    && !(obj.tag == "MainCamera") && !(obj.tag == "Important")) {
                    Destroy(obj);
                }
            }
            Instantiate(keptObj);
        }
    }
}
