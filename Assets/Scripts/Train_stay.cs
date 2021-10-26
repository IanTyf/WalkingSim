using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train_stay : MonoBehaviour
{

    public float TrainStayTime = 10f;
    public bool animBool;
  
    public Vector3 WaterPosition;
    public GameObject Water;
    public ReversePlatform ReverseP;
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
        ReverseP = FindObjectOfType<ReversePlatform>();
    }

    public void InstantMove() 
    {
       
        Water.gameObject.transform.position = WaterPosition;
    }

    public void ReverseRun() 
    {
        ReverseP.ReverseRun();
    }
    // Update is called once per frame
    void Update()
    {
        animBool = GetComponent<Animator>().GetBool("Entered");
    }
}
