using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientSwapTrigger : MonoBehaviour
{
    public Material mat;
    public Color targetTopColor;
    public Color targetBottomColor;
    public Color OriginalTopColor;
    public Color OriginalBottomColor;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mat.SetColor("_TopColor", targetTopColor);
            mat.SetColor("_BottomColor", targetBottomColor);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            mat.SetColor("_TopColor", OriginalTopColor);
            mat.SetColor("_BottomColor", OriginalBottomColor);
        }
    }
}
