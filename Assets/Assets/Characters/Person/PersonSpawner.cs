using System.Linq;
using UnityEngine;

/// <summary>
/// A script that defines the logic of spawning persons
/// </summary>
public class PersonSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnRate = 1;
    public int maxPersons = 10;
    public PersonMovement personPrefab;

    private float _whenToSpawn;
    private int _numberOfPersons;
    
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        spawnPoints = transform.GetComponentsInChildren<Transform>().Where(t => t != transform).ToArray();
        _whenToSpawn = 0;
        _numberOfPersons = 0;
    }

    /// <summary>
    /// Check if it is time to spawn and spawns a person if it is
    /// </summary>
    private void Update()
    {
        _whenToSpawn += Time.deltaTime;
        if (_whenToSpawn < spawnRate) return;
        if (_numberOfPersons < maxPersons)
        {
            _numberOfPersons++;
            var person = Instantiate(personPrefab);
            var i = Random.Range(0, spawnPoints.Length);
            person.start = spawnPoints[i];
            var j = 0;
            do {
                j = Random.Range(0, spawnPoints.Length);
            } while (i == j);
            person.end = spawnPoints[j];
        }
        _whenToSpawn = 0;
    }
}
