using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTriggerInside : MonoBehaviour
{

    public GameObject Train;
    public GameObject Passenger;
    private bool moveAlong;

    private Vector3 previousTrainPos;

    private void Start()
    {
        previousTrainPos = Train.transform.position;
        moveAlong = false;
    }

    private void Update()
    {
        if (moveAlong)
        {
            Vector3 posDiff = Train.transform.position - previousTrainPos;
            Debug.Log(posDiff);
            Vector3 newPos = Passenger.transform.position + posDiff;
            Passenger.GetComponent<CharacterController>().enabled = false;
            Passenger.transform.position = new Vector3(newPos.x, newPos.y, newPos.z);
            Passenger.GetComponent<CharacterController>().enabled = true;


        }
        previousTrainPos = Train.transform.position;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Passenger.transform.SetParent(Train.transform, true);
        //if (other.tag == "Player") moveAlong = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Passenger.transform.SetParent(null, true);
        //if (other.tag == "Player") moveAlong = false;
    }
}
