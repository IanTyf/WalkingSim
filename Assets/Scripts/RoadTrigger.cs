using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTrigger : MonoBehaviour
{
    //opublic Material roadMat;
    public GameObject road;
    public Animator clock;
    //private bool dissolve;

    //public float dissolveSpeed;

    public AudioSource audio;
    private bool audioStarted;

    // Start is called before the first frame update
    void Start()
    {
        //dissolve = false;
        //roadMat.SetFloat("_Dissolve", 1);
        audioStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (dissolve)
        {
            float currentD = roadMat.GetFloat("_Dissolve");
            float newD = currentD - dissolveSpeed * Time.deltaTime * 0.1f;
            if (newD <= 0)
            {
                newD = 0;
                dissolve = false;
            }
            roadMat.SetFloat("_Dissolve", newD);
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            road.GetComponent<DissolveMaterialSwap>().Active();

            if (clock != null) clock.SetTrigger("ClockStart");

            if (!audioStarted && audio != null)
            {
                audio.Play();
                audioStarted = true;
            }

            GameObject.Find("GameManager").GetComponent<GameManager>().StartTimerSince15 = true;
        }
    }
}
