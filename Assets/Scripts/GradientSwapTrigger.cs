using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientSwapTrigger : MonoBehaviour
{
    public Material mat;
    public Color targetColor;
    public Color OriginalColor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }
}
