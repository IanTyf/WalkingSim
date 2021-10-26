using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool StartTimerSince15;
    public float TimerSince15;

    public float StartCollapseAfterSeconds;
    public float EndCollapseAfterSeconds;
    public float TrainSpawnTime;
    public float TrainRideAudioPlayTime;
    public AudioSource TrainRide;
    private bool StartCollapsed;
    private bool FinishCollapsed;

    private ObjectShake OS;

    public Material outlineMat;

    private Water_Crush[] WaterCrushes;
    public GameObject WaterPortal;
    public GameObject Train;

    private bool trainSpawned;
    public bool shouldSpawn;
    public bool aquaShouldCrush;

    private bool trainRidePlayed;

    // Start is called before the first frame update
    void Start()
    {
        outlineMat.SetFloat("_NormalsStrength", 1f);
        outlineMat.SetFloat("_NormalsTightening", 1f);

        StartTimerSince15 = false;
        TimerSince15 = 0;
        StartCollapsed = false;
        OS = GameObject.FindObjectOfType<ObjectShake>();

        WaterCrushes = GameObject.FindObjectsOfType<Water_Crush>();

        trainSpawned = false;
        shouldSpawn = false;
        trainRidePlayed = false;
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

        if (!trainSpawned && TimerSince15 > TrainSpawnTime && shouldSpawn && TimerSince15 < TrainSpawnTime+0.2)
        {
            trainSpawned = true;
            Train.SetActive(true);
        }

        if (!trainRidePlayed && TimerSince15 > TrainRideAudioPlayTime)
        {
            trainRidePlayed = true;
            TrainRide.Play();
        }
    }

    public void TriggerStartCollapse()
    {
        OS.Shake();
        if (aquaShouldCrush) AquariumCollapse();
        PreventAquariumSpawn();
    }

    public void TriggerCollapse()
    {
        OS.Explode();
        AquariumFall();
    }

    public void AquariumCollapse()
    {
        WaterPortal.SetActive(true);
        for (int i = 0; i < WaterCrushes.Length; i++)
        {
            WaterCrushes[i].BeginCrush();
        }
    }

    public void AquariumFall()
    {
        GameObject.FindObjectOfType<BastionFloorTrigger>().floorCrush();
    }

    public void PreventAquariumSpawn()
    {
        GameObject.FindObjectOfType<WaterAnimationTrigger>().gameObject.SetActive(false);
    }
}
