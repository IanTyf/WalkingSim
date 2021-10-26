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
        GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<MeshCollider>().enabled = false;
        //GetComponent<BoxCollider>().enabled = false;
        if (TryGetComponent(out MeshCollider mc))
        {
            mc.enabled = false;
        }
        if (TryGetComponent(out BoxCollider bc))
        {
            bc.enabled = false;
        }
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
        //dissolveCompleted = true;

        if (Delay == 0)
        {
            active = true;
            GetComponent<MeshRenderer>().enabled = true;
            if (TryGetComponent(out MeshCollider mc))
            {
                mc.enabled = true;
            }
            if (TryGetComponent(out BoxCollider bc))
            {
                bc.enabled = true;
            }
        }
        else
        {
            StartCoroutine(WaitAndActive(Delay));
        }
    }

    private IEnumerator WaitAndActive(float waitTime)
    {
        //while (true)
        //{
        yield return new WaitForSeconds(waitTime);
        active = true;
        GetComponent<MeshRenderer>().enabled = true;
        if (TryGetComponent(out MeshCollider mc))
        {
            mc.enabled = true;
        }
        if (TryGetComponent(out BoxCollider bc))
        {
            bc.enabled = true;
        }
        //}
    }

}
