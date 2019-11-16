using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] private Bonfire bonfire; //костер
    [SerializeField] private Player player; //игрок
    [SerializeField] private Stick stick; //тестовая палка
    private float elapsedTime { get; set; }
    private List<Stick> sticks;
    private List<NPC> npcs;
    private bool counting;

    void Awake()
    {
        sticks = new List<Stick>();
        npcs = new List<NPC>();
    }
    void Start()
    {
        elapsedTime = 0f;
        counting = true;
    }

    void Update()
    {
        if (counting)
            elapsedTime += Time.deltaTime;

        if(bonfire.CurrentPower <= 0)
        {
            counting = false;
            Debug.Log("You survived for" + elapsedTime);
        }
    }

    void OnGameStart()
    {
        counting = true;
    }
    void OnGameOver()
    {
        counting = false;
        //отправить результат на экран
    }
}
