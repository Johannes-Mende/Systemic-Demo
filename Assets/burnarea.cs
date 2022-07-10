using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burnarea : MonoBehaviour
{
    public GameObject detractor;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void turnOnCollider()
    {
        detractor.SetActive(true);
    }

    void turnOffCollider()
    {
        detractor.SetActive(false);
    }
}
