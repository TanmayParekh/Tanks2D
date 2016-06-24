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
        // Destroy the bullet if it collides with any tank (other than the one firing), wall or another bullet.

        if (coll.gameObject.tag == "Tank")                  // Collision with tank
        {
            if (coll.gameObject.name != parent.name)        // If not parent tank, destroy bullet. 
            {
                Destroy(gameObject);
            }
            else                                            // If parent tank, don't destory
            {

            }
        }
        else if (coll.gameObject.tag == "Bullet")           // Collision with bullet
        {
            if (coll.gameObject.GetComponent<bulletController>().parent.name != parent.name)
            {
                Destroy(gameObject);
            } 
        }
        else if (coll.gameObject.tag == "Wall")             // Collision with wall
        {
            Destroy(gameObject);
        }      
    }

    // Update is called once per frame
    void Update () {
	
	}
}
