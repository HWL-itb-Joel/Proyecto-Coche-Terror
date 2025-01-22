using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action OnSpeak = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        OnSpeak.Invoke();
    }
}
