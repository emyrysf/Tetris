using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        
        Instantiate(blocks[Random.Range(0, blocks.Length)],transform.position,Quaternion.identity);
    }
    
}
