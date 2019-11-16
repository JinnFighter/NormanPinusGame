using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    private float currentPower;
    private int state { get; set; } //состояние костра: Потушен, слабо горит, нормально, сильно, слишком сильно (нужно решить, сколько нужно)
    private float burningSpeed;     //скорость горения

    void Start()
    {
        currentPower = 50f;
        state = 1; //временные числа
        burningSpeed = 1.5f;
    }

    void Update()
    {
        currentPower -= burningSpeed;
        if (currentPower <= 0f) //если костер потух - перевести его состояние в "потушен"
            state = 0;
    }
}
