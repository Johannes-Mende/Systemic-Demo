using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField] private GameObject objectToBeSpawned;
    [SerializeField] private GameObject SpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
        Debug.Log("Spawn");
        Instantiate(objectToBeSpawned, SpawnPosition.transform);  
    }

    private void OnMouseDown()
    {
        BroadcastMessage("SpawnObject");
    }
}
