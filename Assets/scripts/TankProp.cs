using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankProp : MonoBehaviour {

    public float maxHealth = 100f;
    public GameObject health;
    public float relativeDownDistance = 1f;

    private float actualHealth;
    private Scrollbar healthBar;
    private float tankAngle;

	// Use this for initialization
	void Start () {

        healthBar = health.GetComponentInChildren<Scrollbar>();
    
        // Don't rotate HealthBar with tank. Keep the rotation zero.
        var rotation = health.transform.rotation.eulerAngles;
        rotation.z = 0;
        health.transform.rotation = Quaternion.Euler(rotation);

        // Keep the HealthBar below the tank.
        health.transform.position = transform.position - new Vector3(0,relativeDownDistance,0);

        // Initializing the tank with full health
        actualHealth = maxHealth;
        healthBar.size = 1f;
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        // If the colliding gameobject is not the tank firing it, then destroy bullet.
        // Add damage to the colliding tank and make change in health bar.
        if (coll.gameObject.GetComponent<bulletController>().parent.name != gameObject.name)            // Only checks bullet and tank collision. Might need to make it modular.
        {
            Debug.Log(coll.gameObject.GetComponent<bulletController>().parent.name + ' ' + gameObject.name);
            float bulletDamage = coll.gameObject.GetComponent<bulletController>().damage;
            actualHealth -= bulletDamage;
            healthBar.size = Mathf.Max(actualHealth / maxHealth,0f);

            if (actualHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void LateUpdate () {

        var rotation = health.transform.rotation.eulerAngles;
        rotation.z = 0;
        health.transform.rotation = Quaternion.Euler(rotation);

        health.transform.position = transform.position - new Vector3(0,relativeDownDistance, 0);

    }
}
