using UnityEngine;

public class Windboxy : MonoBehaviour
{
    [SerializeField] private float strength;        //Strength of the wind

    private Vector2 direction;
    private Vector2 wind;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }

    private void OnTriggerStay2D(Collider2D col)    //Triggers when a gameobject with a trigger enters the area
    {
        //What happens when the seagull is inside the windbox
        if (col.gameObject.name == "Seagull")
        {
            Debug.Log("Yas");
            //Movement.changeResistance();
        }
    }

}
