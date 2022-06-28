using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BurnScript : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    [SerializeField] private Material OriginalMaterial;
    
    private void Start() {
        OriginalMaterial = GetComponent<MeshRenderer>().sharedMaterial;
        PlayerController playerController = GameManager.access.PC.GetComponent<PlayerController>();
        playerController.OnBurn += PlayerController_OnBurn;

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

    private void PlayerController_OnBurn(object sender, EventArgs e)
    {
        Debug.Log("Space!");
        
    }

}