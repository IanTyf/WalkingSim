using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BastionFloorTrigger : MonoBehaviour
{

    private FloorBastion[] fbs;
    public GameObject bastionFloorParent;
    public GameObject realFloor;

    public GameObject[] fences;
    public GameObject[] seats;

    // Start is called before the first frame update
    void Start()
    {
        fbs = GameObject.FindObjectsOfType<FloorBastion>();

        fences = GameObject.FindGameObjectsWithTag("Fence");
        seats = GameObject.FindGameObjectsWithTag("AquaSeat");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    floorCrush();
        //    FenceCrush();
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            foreach (FloorBastion fb in fbs)
            {
                fb.Active();
            }
            StartCoroutine(swapFloor());
        }
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

        foreach (GameObject obj in seats)
        {
            obj.GetComponent<BastionMaterialSwap>().Active();
        }
    }

    public void floorCrush()
    {
        realFloor.SetActive(false);
        bastionFloorParent.SetActive(true);
        foreach (FloorBastion fb in fbs)
        {
            fb.ActiveReverse();
            fb.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    public void FenceCrush()
    {
        foreach (GameObject obj in fences)
        {
            Rigidbody rb = obj.AddComponent<Rigidbody>();
            rb.useGravity = true;
            rb.AddExplosionForce(500, new Vector3(1f, 0.78f, 73.3f), 50);
        }
    }

    public void SeatsCrush()
    {
        foreach (GameObject obj in seats)
        {
            Rigidbody rb = obj.AddComponent<Rigidbody>();
            rb.useGravity = true;
            rb.AddExplosionForce(500, new Vector3(1f, 0.78f, 73.3f), 50);
        }
    }
}
