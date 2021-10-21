using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveMaterialSwap : MonoBehaviour
{
    private Material OldMat;
    private Material mat;
    public float DissolveDuration;
    public Vector3 DissolveDirection;
    public float Scale;
    public Vector2 Range;

    public float Delay;

    public bool active;
    public float dissolve;
    private bool dissolveCompleted;

    //private GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        dissolve = 1f;
        dissolveCompleted = false;
        
        OldMat = GetComponent<MeshRenderer>().material;
        mat = new Material(OldMat);
        mat.SetVector("_Direction", DissolveDirection);
        mat.SetFloat("_Scale", Scale);
        mat.SetVector("_Range", Range);
        mat.SetFloat("_Dissolve", dissolve);
        this.gameObject.GetComponent<MeshRenderer>().material = mat;

        //playerObj = GameObject.Find("Player");
    }

    void Update()
    {
        if (active)
        {
            dissolve -= (1 / DissolveDuration) * Time.deltaTime;
            mat.SetFloat("_Dissolve", dissolve);
            if (dissolve <= 0)
            {
                active = false;
                dissolveCompleted = true;
            }
        }
    }

    public void Active()
    {
        if (dissolveCompleted) return;

        if (Delay == 0) active = true;
        else
        {
            StartCoroutine(WaitAndActive(Delay));
        }
    }

    private IEnumerator WaitAndActive(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            active = true;
        }
    }

}
