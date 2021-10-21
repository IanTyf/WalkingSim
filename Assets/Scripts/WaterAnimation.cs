using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAnimation : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 Start_Position;
    public Vector3 End_Position;
    public float Delay_Time;
    private bool Anim_Start = false;
    public float Move_Speed = 0.01f;


    void LerpPosition() 
    {
        
        Vector3 New_Position = Vector3.Lerp(transform.localPosition, End_Position, Move_Speed);
        transform.localPosition = New_Position;
        
    }
    
    void Start()
    {
        transform.localPosition = Start_Position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Anim_Start == true) 
        {
            LerpPosition();
        }
    }

    public void Active()
    {
        if (Delay_Time == 0) Anim_Start = true;
        else
        {
            StartCoroutine(delay());
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(Delay_Time);
        Anim_Start = true;
    }
}
