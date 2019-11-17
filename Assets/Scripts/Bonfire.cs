using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    private float currentPower;
    public float CurrentPower { get => currentPower; set => currentPower = value; }
    private int state { get; set; } //состояние костра: Потушен, слабо горит, нормально, сильно, слишком сильно (нужно решить, сколько нужно)
    private float burningSpeed;     //скорость горения
    private List<Stick> sticksPile;

    void Awake()
    {
        sticksPile = new List<Stick>();
    }
    void Start()
    {
        currentPower = 500f;
        state = (int)BonfireStates.NORMAL; //временные числа
        burningSpeed = 1.5f;
    }

    void Update()
    {
        if(state != (int)BonfireStates.EXTINGUISHED)
            currentPower -= burningSpeed;

        if (currentPower <= 0f) //если костер потух - перевести его состояние в "потушен"
            state = (int)BonfireStates.EXTINGUISHED;
    }

    public void AddPower(float power)
    {
        currentPower += power;
    }
    public void AddToPile(Stick stick)
    {
        Stick foundStick = new Stick(stick.Power, stick.StickType);
        sticksPile.Add(foundStick);
    }
    public Stick RemoveFromPile()
    {
        Stick res = sticksPile[0];
        sticksPile.RemoveAt(0);
        return res;
    }
}
