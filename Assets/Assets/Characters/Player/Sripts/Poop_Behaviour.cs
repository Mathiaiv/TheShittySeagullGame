using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop_Behaviour : MonoBehaviour
{

    [SerializeField] private float lifeTime;    //How many seconds before the poop disappears
    [SerializeField] private float activationTime; //How many seconds before the poop collision activates
    [SerializeField] private float deactivationTime; //How many seconds before the poop collision activates

    private float age;      //How long the poop has lived
    private static readonly int FallingTime = Animator.StringToHash("FallingTime");

    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Animator>().SetFloat(FallingTime, activationTime);
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

    private void OnTriggerStay2D(Collider2D col)
    {
        if (age > activationTime && age < deactivationTime && col.tag.Equals("People"))
        {
            col.GetComponent<Person>().Shot();
            Destroy(this.gameObject);
        }
    }
}
