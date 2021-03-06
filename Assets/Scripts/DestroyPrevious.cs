using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrevious : MonoBehaviour
{
    public int sceneNum;
    public GameObject[] roads;

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
            if (sceneNum == 1)
            {
                GameObject.FindObjectOfType<ObjectShake>().Break();
                GameObject.FindObjectOfType<GameManager>().cafeShouldCrush = false;
            }
            else if (sceneNum == 2)
            {
                GameObject.FindObjectOfType<GameManager>().AquariumCollapse();
                GameObject.FindObjectOfType<GameManager>().aquaShouldCrush = false;
                foreach (GameObject obj in roads)
                {
                    if (obj != null)
                    {
                        Destroy(obj);
                    }
                }
                StartCoroutine(destroyFloor());
            }

        }
    }

    IEnumerator destroyFloor()
    {
        yield return new WaitForSeconds(33.3f);
        GameObject.FindObjectOfType<GameManager>().AquariumFall();
    }
}
