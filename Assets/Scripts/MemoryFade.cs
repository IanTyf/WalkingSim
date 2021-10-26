using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryFade : MonoBehaviour
{

    public Material MemoryMat;
    public float LerpSpeed;
    public Color TargetColor = new Color(1,1,1);
    public bool BeginFade;
    // Start is called before the first frame update
    void Start()
    {
        MemoryMat.color = new Color(1, 0, 0);
    }

    public void ColorLerp() 
    {
         Color color = Color.Lerp(MemoryMat.color,TargetColor,LerpSpeed);
        //MemoryMat.SetColor ("_Base Map",color);
        MemoryMat.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (BeginFade) ColorLerp();
    }
}
