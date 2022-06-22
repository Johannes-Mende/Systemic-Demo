using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void LightAction();
    public static event LightAction OnHit;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
