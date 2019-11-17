using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayTimer : MonoBehaviour
{
    private float startTime;
    private float currentTime = 0f;
    private bool counting;
    public bool Counting { get; }

    public GameplayTimer(float StartTime)
    {
        startTime = StartTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(counting)
            currentTime -= Time.deltaTime;
        if (currentTime <= 0f)
            counting = false;
    }

    public void StartTimer()
    {
        currentTime = startTime;
        counting = true;
    }
    public void PauseTimer()
    {
        counting = false;
    }
    public void RestartTimer()
    {
        PauseTimer();
        StartTimer();
    }
    public void ResetTimer(float value)
    {
        PauseTimer();
        startTime = value;
        currentTime = startTime;
    }
    public void ResumeTimer()
    {
        counting = true;
    }
}
