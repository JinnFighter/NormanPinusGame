using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    private float currentPower;
    public float CurrentPower { get => currentPower; set => currentPower = value; }
    private int state { get; set; } //состояние костра: Потушен, слабо горит, нормально, сильно, слишком сильно (нужно решить, сколько нужно)
    private float burningSpeed;     //скорость горения

    void Start()
    {
        currentPower = 500f;
        state = (int)BonfireStates.NORMAL; //временные числа
        burningSpeed = 1.5f;
    }

    void Update()
    {
        currentPower -= burningSpeed;
        if (currentPower <= 0f) //если костер потух - перевести его состояние в "потушен"
            state = (int)BonfireStates.EXTINGUISHED;
    }

    void AddPower(Stick stick)
    {
        currentPower += stick.Power;
    }
}
