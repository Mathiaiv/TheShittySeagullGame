using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop_Behaviour : MonoBehaviour
{

    [SerializeField] private float lifeTime;    //How many seconds before the poop disappears

    private float age;      //How long the poop has lived

    // Start is called before the first frame update
    void Start()
    {
        age = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Removes the object when its age has reached the allowed lifetime
        if (age < lifeTime)
        {
            age += Time.fixedDeltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "People")
        {
            col.GetComponent<Person>().shot();
            Debug.Log("Awesome");
            Destroy(this.gameObject);
        }
    }
}
