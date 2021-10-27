using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBastion : MonoBehaviour
{
    private Material OldMat;
    private Material mat;
    public Material endMat;

    public float Height;
    public float Duration;
    public Vector3 Direction;

    public float Delay;

    public bool active;
    public bool deactive;
    public float Appear;
    private bool AppearCompleted;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        deactive = false;
        Appear = 1;
        AppearCompleted = false;

        OldMat = GetComponent<MeshRenderer>().material;
        mat = new Material(OldMat);
        mat.SetFloat("_Height", Height);
        mat.SetFloat("_Appear", Appear);
        mat.SetVector("_Direction", Direction);
        this.gameObject.GetComponent<MeshRenderer>().material = mat;


        Height += Random.Range(-0.3f, 0.3f);
        Duration += Random.Range(-0.5f, 0.1f);
        Delay += Random.Range(0, 1f);
    }

    void Update()
    {
        if (active)
        {
            Appear -= (1 / Duration) * Time.deltaTime;
            mat.SetFloat("_Appear", Appear);
            if (Appear <= 0)
            {
                active = false;
                AppearCompleted = true;
                //this.gameObject.GetComponent<MeshRenderer>().material = endMat;
            }
        }

        if (deactive)
        {
            Appear += (1 / Duration) * Time.deltaTime;
            mat.SetFloat("_Appear", Appear);
            if (Appear >= 1)
            {
                deactive = false;
            }
        }
    }

    public void Active()
    {
        if (AppearCompleted) return;
        //AppearCompleted = true;
        if (Delay == 0) active = true;
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
        //}
    }

    public void ActiveReverse()
    {
        /*
        if (Delay == 0) deactive = true;
        else
        {
            StartCoroutine(WaitAndDeactive(Delay));
        }
        */
        deactive = true;
    }

    IEnumerator WaitAndDeactive(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        deactive = true;
    }
}
