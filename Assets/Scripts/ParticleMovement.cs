using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour
{
    public float speed;
    public int checkpoint;
    public Vector3[] stops;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        checkpoint = 0;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, stops[checkpoint], 0.003f);
        transform.position = Vector3.MoveTowards(transform.position, stops[checkpoint], speed * Time.deltaTime);

        if (Vector3.Distance(player.transform.position, stops[checkpoint]) < 6f)
        {
            checkpoint++;
        }

        if (Vector3.Distance(transform.position, stops[checkpoint]) < 2f)
        {
            if (checkpoint == 1 || checkpoint == 4 || checkpoint == 8 || checkpoint == 9 || checkpoint == 10 || checkpoint == 7)
            {
                checkpoint++;
            }
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            checkpoint++;
        }
    }
    */
}
