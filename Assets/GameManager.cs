using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager access;
    public GameLogic GL;
    //public Settings S;
    
    void Awake() 
    {
        access = this;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
