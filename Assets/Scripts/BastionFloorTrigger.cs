using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BastionFloorTrigger : MonoBehaviour
{

    private FloorBastion[] fbs;
    public GameObject bastionFloorParent;
    public GameObject realFloor;

    public GameObject[] fences;

    // Start is called before the first frame update
    void Start()
    {
        fbs = GameObject.FindObjectsOfType<FloorBastion>();

        fences = GameObject.FindGameObjectsWithTag("Fence");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (FloorBastion fb in fbs)
        {
            fb.Active();
        }
        StartCoroutine(swapFloor());
    }

    IEnumerator swapFloor()
    {
        yield return new WaitForSeconds(2.5f);
        bastionFloorParent.SetActive(false);
        realFloor.SetActive(true);

        foreach (GameObject obj in fences)
        {
            obj.GetComponent<DissolveMaterialSwap>().Active();
        }
    }
}
