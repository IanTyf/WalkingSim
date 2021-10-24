using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenDoor : MonoBehaviour
{
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") GetComponent<Animator>().SetTrigger("Up");

        Debug.Log("enter");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") GetComponent<Animator>().SetTrigger("Down");

        Debug.Log("exit");
    }
    */

    private GameObject player;
    private bool up;
    private bool down;

    private void Start()
    {
        up = false;
        down = false;
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (!up)
        {
            if (Vector3.Distance(player.transform.position, this.transform.position) < 2f)
            {
                GetComponent<Animator>().SetTrigger("Up");
                up = true;
                down = false;
            }
        }
        else if (!down)
        {
            if (Vector3.Distance(player.transform.position, this.transform.position) > 4f)
            {
                GetComponent<Animator>().SetTrigger("Down");
                up = false;
                down = true;
            }
        }
        
    }
}
