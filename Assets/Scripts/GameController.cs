using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] private Bonfire bonfire; //костер
    [SerializeField] private Player player; //игрок
    [SerializeField] private Stick stick; //тестовая палка
    private Dictionary<int, float> npcSpawnRate;
    private Dictionary<int, int> weatherChangeRate;
    private float elapsedTime { get; set; }
    private List<Stick> sticks;
    private List<NPC> npcs;
    private bool counting;
    private GameplayTimer bonfireChecker;
    private GameplayTimer weatherChecker;
    private bool isPlaying;

    void Awake()
    {
        isPlaying = false;
        sticks = new List<Stick>();
        npcs = new List<NPC>();
        bonfireChecker = new GameplayTimer(30f);
        weatherChecker = new GameplayTimer(47f);
        npcSpawnRate = new Dictionary<int, float> {     { (int)BonfireStates.EXTINGUISHED, 0f },
                                                        { (int)BonfireStates.WEAK, 0.4f },
                                                        { (int)BonfireStates.NORMAL, 0.6f },
                                                        { (int)BonfireStates.STRONG, 0.8f },
                                                        { (int)BonfireStates.UNCONTROLLABLE, 0.1f } };
        weatherChangeRate = new Dictionary<int, int> { { (int)WeatherStates.CLEAR, 7 },
                                                        { (int)WeatherStates.RAIN, 9 },
                                                        { (int)WeatherStates.WIND, 10 } };
    }
    void Start()
    {
        elapsedTime = 0f;
        bonfire.WeatherState = (int)WeatherStates.CLEAR;
        counting = false;
        StartGame();
    }

    void Update()
    {
        if (!isPlaying)
            return;
        if (counting)
            elapsedTime += Time.deltaTime;
        else return;

        if(bonfire.State == (int)BonfireStates.EXTINGUISHED)
        {
            OnGameOver();
        }
        if(!bonfireChecker.Counting)
        {
            float prob = UnityEngine.Random.Range(0, 1);
            if (prob <= npcSpawnRate[(int)bonfire.State] && npcs.Count < 10)
                SpawnNPC();
            bonfireChecker.RestartTimer();
        }
        if (!weatherChecker.Counting)
        {
            float prob = UnityEngine.Random.Range(1, 10);
            if (prob <= weatherChangeRate[(int)WeatherStates.CLEAR])
            {
                bonfire.WeatherState = (int)WeatherStates.CLEAR;
                weatherChecker.ResetTimer(47f);
            }
            else
            {
                if(prob <= weatherChangeRate[(int)WeatherStates.RAIN])
                {
                    bonfire.WeatherState = (int)WeatherStates.RAIN;
                    weatherChecker.ResetTimer(94f);
                }
                else
                {
                    bonfire.WeatherState = (int)WeatherStates.WIND;
                    weatherChecker.ResetTimer(141f);
                }
            }
            weatherChecker.RestartTimer();
        }
    }

    void OnGameStart()
    {
        counting = true;
    }
    void OnGameOver()
    {
        counting = false;
        Debug.Log("You Survived for " + elapsedTime);
        //отправить результат на экран
    }
    public void SpawnNPC()
    {
        npcs.Add(new NPC());
    }

    public void StartGame()
    {
        isPlaying = true;
        counting = true;
        bonfireChecker.StartTimer();
        weatherChecker.StartTimer();
    }
    public void PauseGame()
    {
        isPlaying = false;
        counting = false;
        bonfireChecker.PauseTimer();
        weatherChecker.PauseTimer();
    }
    public void ContinueGame()
    {
        isPlaying = true;
        counting = true;
        bonfireChecker.ResumeTimer();
        weatherChecker.ResumeTimer();
    }
}
