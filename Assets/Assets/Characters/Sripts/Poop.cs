using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poop : MonoBehaviour
{
    public GameObject poop;
    public Slider poopBar;
    public float maxPoop = 10;
    public float poopRegenRate;
    public float poopAmount;
        
    // Start is called before the first frame update
    void Start()
    {
    }

    /*
    increases the poop gradualy over time
    */
    void FixedUpdate()
    {
        if (poopAmount < maxPoop) 
        {
            poopAmount += poopRegenRate * Time.fixedDeltaTime;
        }
        else poopAmount = 10;
        poopBar.value = poopAmount;
    }

    /*
    The seagull poops if there is poop inside your body
    */
    void OnFire()
    {
        if ( poopAmount > 1) 
        {
            poopAmount--;
            GameObject.Instantiate(poop, transform.position, default);
        }
    }
}
