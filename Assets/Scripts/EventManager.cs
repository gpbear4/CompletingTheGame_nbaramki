using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    [System.Serializable] public class TargetDestroyed : UnityEvent<int> { }
    public TargetDestroyed targetDestroyed;

    [System.Serializable] public class StartGameEvent : UnityEvent<int> { }
    public StartGameEvent startGameEvent;
    //[SerializeField] private int speed;
    public UnityEvent gameOverEvent;
}
