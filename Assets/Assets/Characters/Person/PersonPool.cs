
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PersonPool : MonoBehaviour
{
    public static PersonPool Instance;

    private readonly List<Person> _pooledPerson = new List<Person>();
    [SerializeField] private int numberOfPersons = 10;
    [SerializeField] private Person personPrefab;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        for (var i = 0; i < numberOfPersons; i++)
        {
            _pooledPerson.Add(Instantiate(personPrefab));
        }
    }

    public Person GetPooledPerson()
    {
        return _pooledPerson.FirstOrDefault(t => !t.gameObject.activeInHierarchy);
    }
}
