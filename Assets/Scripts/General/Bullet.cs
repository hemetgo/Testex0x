using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Target target;
    public int damage;
    public float bulletSpeed;
    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = transform.right * bulletSpeed;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == target.ToString())
		{
            collision.GetComponent<HealthController>().TakeDamage(damage);
            Destroy(gameObject);
		}
        else if (collision.tag == "Obstacle")
		{
            Destroy(gameObject);
		}
	}

    public enum Target { Enemy, Player }
}
