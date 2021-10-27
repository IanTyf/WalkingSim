using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableController()
    {
        Player.GetComponent<CharacterController>().enabled = true;
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
