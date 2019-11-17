using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    private float currentPower;
    public float CurrentPower { get => currentPower; set => currentPower = value; }
    private int state; //состояние костра: Потушен, слабо горит, нормально, сильно, слишком сильно (нужно решить, сколько нужно)
    public int State { get => state; set => state = value; }
    private float burningSpeed;     //скорость горения
    private int weatherState = 0;
    public int WeatherState { get => weatherState; set => weatherState = value; } 
    private List<Stick> sticksPile;
    private Dictionary<int, float> burningSpeeds;
    private Dictionary<int, float> weatherModifiers;

    void Awake()
    {
        sticksPile = new List<Stick>();
        burningSpeeds = new Dictionary<int, float> { { (int)BonfireStates.EXTINGUISHED, 0f },
                                                    { (int)BonfireStates.WEAK, 1.5f },
                                                    { (int)BonfireStates.NORMAL, 2f },
                                                    { (int)BonfireStates.STRONG, 2.5f },
                                                    { (int)BonfireStates.UNCONTROLLABLE, 5f } };
        weatherModifiers = new Dictionary<int, float> { { (int)WeatherStates.CLEAR, 0f },
                                                        { (int)WeatherStates.RAIN, -1.5f },
                                                        { (int)WeatherStates.WIND, -3f }};
    }
    void Start()
    {
        currentPower = 500f;
        state = (int)BonfireStates.NORMAL; //временные числа
        burningSpeed = burningSpeeds[state] = weatherModifiers[WeatherState];
    }

    void Update()
    {
        if(state != (int)BonfireStates.EXTINGUISHED)
            currentPower -= burningSpeed;

        if (currentPower <= 0f) //если костер потух - перевести его состояние в "потушен"
            state = (int)BonfireStates.EXTINGUISHED;
        else
        {
            if (currentPower <= 500f)
                state = (int)BonfireStates.WEAK;
            else if (currentPower <= 700f)
                state = (int)BonfireStates.NORMAL;
            else if (currentPower <= 900f)
                state = (int)BonfireStates.STRONG;
            else state = (int)BonfireStates.UNCONTROLLABLE;

            burningSpeed = burningSpeeds[state] + weatherModifiers[weatherState];
        }
        
    }

    public void AddPower(float power)
    {
        currentPower += power;
    }
    public void AddToPile(Stick stick)
    {
        Stick foundStick = new Stick(stick);
        sticksPile.Add(foundStick);
    }
    public Stick RemoveFromPile()
    {
        Stick res = sticksPile[0];
        sticksPile.RemoveAt(0);
        return res;
    }
}
