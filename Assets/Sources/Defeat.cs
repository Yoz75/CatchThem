using System;
using UnityEngine;

public class Defeat : MonoBehaviour
{
    private event Action LoseEvent;
    public static Defeat Instance
    {
        get; private set;
    }

    private void Awake()
    {
        Instance = this;
    }

    public void Lose()
    {
        LoseEvent?.Invoke();
    }

    public void AddOnLose(Action action)
    {
        LoseEvent += action;
    }
}
