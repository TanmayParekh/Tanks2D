using UnityEngine;
using System.Collections;

public class bulletController : MonoBehaviour {

    public GameObject parent;           // The tank which has fired this bullet
    public float damage;                // Damage that this bullet can do
    public float radius;                // Radius of the bullet

    private float prevScale;

    // Use this for initialization
    void Start ()
    {
        // Change the radius to the given radius
        gameObject.transform.localScale = new Vector3(1,1,1) * radius;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // If the colliding gameobject is not the tank firing it, then destroy bullet.
        // We can add damage to the colliding tank here.
        if (coll.gameObject.name != parent.name)
        {
            Destroy(gameObject);
        }       
    }

    // Update is called once per frame
    void Update () {
	
	}
}
