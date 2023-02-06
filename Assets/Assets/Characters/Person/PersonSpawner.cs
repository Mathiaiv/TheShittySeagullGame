using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// A script that defines the logic of spawning persons
/// </summary>
public class PersonSpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public float spawnRate = 1;
    public int maxPersons = 10;
    public PersonMovement personPrefab;

    private float _whenToSpawn;
    private int _numberOfPersons;
    private List<PersonMovement> persons;
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        _whenToSpawn = 0;
        _numberOfPersons = 0;
        for (var i = 0; i < maxPersons; i++)
        {
            persons.Add(Instantiate(personPrefab));
        }
    }

    private void KillAllFinished()
    {
        foreach (var personMovement in persons)
        {
            if (personMovement.isFinished) personMovement.enabled = false;
        }
    }

    /// <summary>
    /// Check if it is time to spawn and spawns a person if it is
    /// </summary>
    private void Update()
    {
        //KillAllFinished();
        _whenToSpawn += Time.deltaTime;
        if (_whenToSpawn < spawnRate) return;
        if (_numberOfPersons < maxPersons)
        {
            _numberOfPersons++;
            var person = Instantiate(personPrefab);
            var i = Random.Range(0, spawnPoints.Length);
            person.start = spawnPoints[i].transform;
            var j = 0;
            do {
                j = Random.Range(0, spawnPoints.Length);
            } while (i == j);
            person.end = spawnPoints[j].transform;
            person.Spawn();
        }
        _whenToSpawn = 0;
    }
}
