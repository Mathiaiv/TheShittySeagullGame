using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// A script that defines the logic of spawning persons
/// </summary>
public class PersonSpawner : MonoBehaviour
{
    private Transform[] spawnPoints;
    public float spawnRate = 1;
    public Person personPrefab;
    private float _whenToSpawn;
    private int numberOfSkins;
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        spawnPoints = Array.FindAll(GetComponentsInChildren<Transform>(), child => child != this.transform);
        numberOfSkins = personPrefab.GetComponent<SpriteChanger>().skins.Length;
        _whenToSpawn = 0;
    }

    /// <summary>
    /// Check if it is time to spawn and spawns a person if it is
    /// </summary>
    private void Update()
    {
        _whenToSpawn += Time.deltaTime;
        if (_whenToSpawn < spawnRate) return;
        var person = PersonPool.Instance.GetPooledPerson();
        _whenToSpawn = 0;
        if (person == null) return;
        var i = Random.Range(0, spawnPoints.Length);
        var j = 0;
        do { 
            j = Random.Range(0, spawnPoints.Length);
        } while (i == j);
        var k = Random.Range(0, numberOfSkins);
        person.Spawn(k,0.05f, spawnPoints[i].position, spawnPoints[j].position);
    }
}
