using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour
{

    public int checkpoint;
    public Vector3[] stops;

    // Start is called before the first frame update
    void Start()
    {
        checkpoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, stops[checkpoint], 0.003f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            checkpoint++;
        }
    }
}
