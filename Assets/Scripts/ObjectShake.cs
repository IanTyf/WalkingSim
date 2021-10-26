using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShake : MonoBehaviour
{
    public GameObject bedroom;
    private MeshRenderer[] mrs;
    private GameObject[] objs;
    private Vector3[] objsPos;

    public bool shake;
    public Vector2 shakeAmount;
    public float shakeAmplifySpeed;
    private float shakeAmplify;

    // Start is called before the first frame update
    void Start()
    {
        mrs = bedroom.transform.GetComponentsInChildren<MeshRenderer>();
        objs = new GameObject[mrs.Length];
        objsPos = new Vector3[mrs.Length];
        for (int i=0; i<mrs.Length; i++)
        {
            objs[i] = mrs[i].gameObject;
            objsPos[i] = objs[i].transform.position;
        }

        shakeAmplify = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (shake)
        {
            for (int i=0; i<objs.Length; i++)
            {
                shakePosition(objs[i], i);
            }
            shakeAmplify = 1 + shakeAmplifySpeed * Time.deltaTime;
            shakeAmplifySpeed += 0.04f;
        }

        if (Input.GetMouseButtonDown(1)) {
            shake = false;
            Break();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            shake = true;
        }
        
    }

    private void shakePosition(GameObject obj, int i)
    {
        //Vector3 oldPos = obj.transform.position;
        obj.transform.position = new Vector3(objsPos[i].x + Random.Range(shakeAmount.x, shakeAmount.y) * shakeAmplify, objsPos[i].y + Random.Range(shakeAmount.x, shakeAmount.y) * shakeAmplify,
            objsPos[i].z + Random.Range(shakeAmount.x, shakeAmount.y) * shakeAmplify);
    }

    private void Break()
    {
        foreach (GameObject obj in objs)
        {
            Rigidbody rb = obj.AddComponent<Rigidbody>();
            if (obj.tag != "Pillar" && obj.tag != "Skylight") rb.useGravity = false;
            rb.AddExplosionForce(1000, new Vector3(-1.3f, 7.4f, -55.81f), 25f);
            if (obj.tag == "Ceiling") rb.AddForceAtPosition(new Vector3(10, 10, 0), transform.position, ForceMode.Impulse);
            //if (obj.tag == "Skylight") rb.useGravity = true;
        }
    }

    public void Shake()
    {
        shake = true;
    }

    public void Explode()
    {
        shake = false;
        Break();
    }
}
