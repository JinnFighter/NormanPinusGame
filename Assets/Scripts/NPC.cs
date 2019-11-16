using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private int hostileState;
    public int HostileState { get => hostileState; set => hostileState = value; }
    private int joyState { get; set; }
    public int JoyState { get => joyState; set => joyState = value; }
    private int happinessState { get; set; }
    public int HappinessState { get => happinessState; set => happinessState = value; }
    private float age; //возраст(на что влияет?)
   
    void Start()
    {
        age = 20; //временные цифры
        hostileState = Random.Range(10, 100);
        joyState = Random.Range(0, 100-hostileState);
        happinessState = Random.Range(0, 100-(hostileState + joyState));
    }

    void Update()
    {
        
    }
}
