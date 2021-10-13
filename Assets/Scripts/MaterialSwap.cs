using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwap : MonoBehaviour
{
    public Material OldMat;
    private Material mat;
    public float MoveDistance;
    public Vector3 MoveDirection;
    public Vector3 TriggerDirection;
    public float Delay;

    private GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        mat = new Material(OldMat);
        mat.SetFloat("_Height", MoveDistance);
        mat.SetVector("_Direction", MoveDirection);
        mat.SetVector("_TriggerDirection", TriggerDirection);
        this.gameObject.GetComponent<MeshRenderer>().material = mat;

        playerObj = GameObject.Find("Player");
    }

    void Update()
    {
        mat.SetVector("_PlayerPos", playerObj.transform.position + new Vector3(0, 0, -Delay));
    }

}
