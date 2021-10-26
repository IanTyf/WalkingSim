using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationPlatform : MonoBehaviour
{
    // Start is called before the first frame update

    public bool BeginCrush;
    public Animator Animator;
    public GameObject RiseSound;
    public GameObject DownSound;
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    

    // Update is called once per frame
    void Update()
    {
        BeginCrush = Animator.GetBool("StationCrush");
    }

    public void PlatformCrush()
    {
        Animator.SetBool("StationCrush", true);
    }


    public void PlayRiseSound() 
    {
        RiseSound.GetComponent<AudioSource>().gameObject.SetActive(true);
    }

    public void PlayDownSound() 
    {
        DownSound.GetComponent<AudioSource>().gameObject.SetActive(true);
    }

}
