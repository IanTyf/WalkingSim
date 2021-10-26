using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train_stay : MonoBehaviour
{

    public float TrainStayTime = 10f;
    public bool animBool;
    // Start is called before the first frame update

    public void TrainStay() 
    {
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(TrainStayTime);
        GetComponent<Animator>().SetBool("Entered", true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animBool = GetComponent<Animator>().GetBool("Entered");
    }
}
