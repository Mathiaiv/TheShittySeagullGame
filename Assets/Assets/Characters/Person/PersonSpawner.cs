using System.Linq;
using UnityEngine;

public class PersonSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float spawnRate = 1;
    public int maxPersons = 1;
    public PersonMovement personPrefab;

    private float _whenToSpawn;
    private int _numberOfPersons;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = transform.GetComponentsInChildren<Transform>().Where(t => t != transform).ToArray();
        _whenToSpawn = 0;
        _numberOfPersons = 0;
    }

    private void Update()
    {
        _whenToSpawn += Time.deltaTime;
        if (_whenToSpawn < spawnRate) return;
        if (_numberOfPersons < maxPersons)
        {
            _numberOfPersons++;
            PersonMovement person = Instantiate(personPrefab);
            int i = Random.Range(0, spawnPoints.Length);
            person.start = spawnPoints[i];
            int j = 0;
            do {
                j = Random.Range(0, spawnPoints.Length);
            } while (i == j);
            person.end = spawnPoints[j];
        }
        _whenToSpawn = 0;
    }
}
