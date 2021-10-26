using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour
{
    public float speed;
    public int checkpoint;
    public Vector3[] stops;

    public bool disappear;
    private ParticleSystem ps;
    private float alpha;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        checkpoint = 0;
        player = GameObject.Find("Player");
        disappear = false;
        ps = GetComponent<ParticleSystem>();
        alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpoint == 11)
        {
            Destroy(this.gameObject);
        }

        //transform.position = Vector3.Lerp(transform.position, stops[checkpoint], 0.003f);
        transform.position = Vector3.MoveTowards(transform.position, stops[checkpoint], speed * Time.deltaTime);

        if (Vector3.Distance(player.transform.position, stops[checkpoint]) < 6f)
        {
            checkpoint++;
        }

        if (Vector3.Distance(transform.position, stops[checkpoint]) < 2f)
        {
            if (checkpoint == 1 || checkpoint == 3 || checkpoint == 8 || checkpoint == 9 || checkpoint == 10 || checkpoint == 7)
            {
                checkpoint++;
            }
        }

        //if (checkpoint == 3)
        //{
            //disappear = true;
        //}

        if (disappear)
        {
            var main = ps.main;
            main.startColor = new Color(1, 1, 1, alpha);

            var main2 = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().main;
            main2.startColor = new Color(1, 1, 1, alpha);

            var main3 = transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().main;
            main3.startColor = new Color(1, 1, 1, alpha);

            alpha -= 20f * Time.deltaTime;
            if (alpha < 0) alpha = 0;
        }
        else
        {
            var main = ps.main;
            main.startColor = new Color(1, 1, 1, alpha);

            var main2 = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().main;
            main2.startColor = new Color(1, 1, 1, alpha);

            var main3 = transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().main;
            main3.startColor = new Color(1, 1, 1, alpha);

            alpha += 20f * Time.deltaTime;
            if (alpha > 1) alpha = 1;
        }

        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ParticleDisappear")
        {
            disappear = true;
        }
    }
    
}
