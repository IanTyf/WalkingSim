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

    private Color tCol;
    private Color bCol;

    public bool lerp;

    private void Update()
    {
        if (lerp)
        {
            Color currentTCol = mat.GetColor("_TopColor");
            Vector4 newColVec = Vector4.Lerp(new Vector4(currentTCol.r, currentTCol.g, currentTCol.b, currentTCol.a),
                new Vector4(tCol.r, tCol.g, tCol.b, tCol.a), 0.01f); ;
            Color newTCol = new Color(newColVec.x, newColVec.y, newColVec.z, newColVec.w);
            mat.SetColor("_TopColor", newTCol);


            Color currentBCol = mat.GetColor("_BottomColor");
            Vector4 newColVec2 = Vector4.Lerp(new Vector4(currentBCol.r, currentBCol.g, currentBCol.b, currentBCol.a),
                new Vector4(bCol.r, bCol.g, bCol.b, bCol.a), 0.01f); ;
            Color newBCol = new Color(newColVec2.x, newColVec2.y, newColVec2.z, newColVec2.w);
            mat.SetColor("_BottomColor", newBCol);

            if (Vector4.Distance(newColVec, new Vector4(currentTCol.r, currentTCol.g, currentTCol.b, currentTCol.a)) < 0.00001f
                && Vector4.Distance(newColVec2, new Vector4(currentBCol.r, currentBCol.g, currentBCol.b, currentBCol.a)) < 0.00001f)
            {
                lerp = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //mat.SetColor("_TopColor", targetTopColor);
            //mat.SetColor("_BottomColor", targetBottomColor);
            tCol = targetTopColor;
            bCol = targetBottomColor;
            lerp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //mat.SetColor("_TopColor", OriginalTopColor);
            //mat.SetColor("_BottomColor", OriginalBottomColor);
            tCol = OriginalTopColor;
            bCol = OriginalBottomColor;
            lerp = true;
        }
    }
}
