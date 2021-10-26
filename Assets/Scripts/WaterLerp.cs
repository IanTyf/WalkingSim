using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLerp : MonoBehaviour
{

    Renderer Rend;
    public float TargetAlpha;
    public float StartAlpha;
    public float LerpSpeed;
    public bool BeginLerp;
    public GameObject Plane;
    public GameObject Station;
    // Start is called before the first frame update
    void Start()
    {
        Rend = GetComponent<Renderer>();
        Rend.material.SetFloat("_Transparency", StartAlpha);
    }

    void LerpAlph() 
    {

        float New_Float = Mathf.Lerp(StartAlpha, TargetAlpha, LerpSpeed);
        Rend.material.SetFloat("_Transparency", New_Float);
        StartAlpha = New_Float;
    }

    // Update is called once per frame
    void Update()
    {

        if (StartAlpha >= TargetAlpha - 0.01f)
        {
            BeginLerp = false;
            Plane.SetActive(true);
            Station.SetActive(true);

        }


        if (BeginLerp)
        
        {
            LerpAlph();
        }
    }
}
