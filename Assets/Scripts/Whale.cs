using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whale : MonoBehaviour
{
    public bool Whaleanim = false;
    public GameObject WhaleSound;
    public GameObject WhaleSound2;
    public Water_Crush[] WaterCrushes;
    public GameObject WhaleModel;
    // Start is called before the first frame update


    public void Active() 
    {
        WhaleModel.SetActive(true);
    }
    public void BeginPlaySound() 
    {
        WhaleSound.SetActive(true);
    }

    public void BeginPlaySound2() 
    {
        WhaleSound2.SetActive(true);
    }

    public void BeginFall() 
    {
        for (int i = 0; i < WaterCrushes.Length; i++)
        {
            WaterCrushes[i].WaterFall();
        }
    }

    void Start()
    {
        WaterCrushes = GameObject.FindObjectsOfType<Water_Crush>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Whaleanim == true) GetComponent<Animator>().SetBool("PlayAnim",true);
    }
}
