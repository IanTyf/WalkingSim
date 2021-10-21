using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeSkyboxTrigger : MonoBehaviour
{
    public Vector4 TargetColor;
    private GameObject player;
    private Camera cam;

    public bool lerp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        cam = player.transform.GetChild(0).gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lerp)
        {
            Color currentCol = cam.backgroundColor;
            Vector4 newColVec = Vector4.Lerp(new Vector4(currentCol.r, currentCol.g, currentCol.b, currentCol.a),
                new Vector4(TargetColor.x/255f, TargetColor.y/255f, TargetColor.z/255f, TargetColor.w/255f), 0.005f);
            cam.backgroundColor = new Color(newColVec.x, newColVec.y, newColVec.z, newColVec.w);

            if (Vector4.Distance(newColVec, new Vector4(currentCol.r, currentCol.g, currentCol.b, currentCol.a)) < 0.001f)
            {
                lerp = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //cam.backgroundColor = new Color(TargetColor.x/255f, TargetColor.y/255f, TargetColor.z/255f, TargetColor.w/255f);
        lerp = true;
    }
}
