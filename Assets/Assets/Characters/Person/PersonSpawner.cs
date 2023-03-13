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
    public Person personPrefab;
    
    private float _whenToSpawn;
    private List<Person> persons;
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        persons = new List<Person>();
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
        if (person != null)
        {
            person.gameObject.SetActive(true);
            var i = Random.Range(0, spawnPoints.Length);
            person.start = spawnPoints[i].transform;
            var j = 0;
            do { 
                j = Random.Range(0, spawnPoints.Length);
            } while (i == j);
            person.end = spawnPoints[j].transform;
            var k = Random.Range(0, personPrefab.GetComponent<SpriteChanger>().skins.Length);
            person.GetComponent<SpriteChanger>().skinNr = k;
            person.Spawn();
        }
        _whenToSpawn = 0;
    }
}
