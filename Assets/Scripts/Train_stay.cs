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

    public GameObject views;

    public GameObject altWater;
    public GameObject FadeObj;
    public GameObject Luggage;
    public GameObject TrackSound;

    public MemoryFade Script;
    public MemoryFade Script1;
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
        Script = FadeObj.GetComponent<MemoryFade>();
        Script1 = Luggage.GetComponent<MemoryFade>();
    }

    public void InstantMove() 
    {
        altWater.GetComponent<MeshRenderer>().enabled = true;
        Water.gameObject.transform.position = WaterPosition;
    }

    public void MemoFade() 
    {
        Script.BeginFade = true;
        Luggage.GetComponent<MeshRenderer>().material = Script1.MemoryMat;
        Script1.BeginFade = true;
    }

    public void playTrackSound() 
    {
        TrackSound.SetActive(true);
    }
    public void stopTrackSound() 
    {
        TrackSound.SetActive(false);
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

    public void destroyView()
    {
        Destroy(views);
    }
}
