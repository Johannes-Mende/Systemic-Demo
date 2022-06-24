using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnScript : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    [SerializeField] private Material OriginalMaterial;
    
    private void Start() {
        OriginalMaterial = GetComponent<MeshRenderer>().sharedMaterial;
    }

    void OnEnable() 
    {
        //EventManager.OnHit += Burn;    
    }

    void OnDisable() 
    {
        //EventManager.OnHit -= Burn;    
    }

    void Burn()
    {

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Fire"))
        {
            
        }
    }

}