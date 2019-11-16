using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] private Bonfire bonfire; //костер
    [SerializeField] private Player player; //игрок
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
        counting = false;
    }

    void Update()
    {
        if (counting)
            elapsedTime += Time.deltaTime;
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
