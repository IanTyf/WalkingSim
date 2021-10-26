using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool StartTimerSince15;
    public float TimerSince15;

    public float StartCollapseAfterSeconds;
    public float EndCollapseAfterSeconds;
    private bool StartCollapsed;
    private bool FinishCollapsed;

    private ObjectShake OS;

    // Start is called before the first frame update
    void Start()
    {
        StartTimerSince15 = false;
        TimerSince15 = 0;
        StartCollapsed = false;
        OS = GameObject.FindObjectOfType<ObjectShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTimerSince15)
        {
            TimerSince15 += Time.deltaTime;
        }

        if (!StartCollapsed && TimerSince15 > StartCollapseAfterSeconds)
        {
            StartCollapsed = true;
            TriggerStartCollapse();
        }

        if (!FinishCollapsed && TimerSince15 > EndCollapseAfterSeconds)
        {
            FinishCollapsed = true;
            TriggerCollapse();
        }
    }

    public void TriggerStartCollapse()
    {
        OS.Shake();
    }

    public void TriggerCollapse()
    {
        OS.Explode();
    }
}
