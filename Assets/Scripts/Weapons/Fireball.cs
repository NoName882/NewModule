using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed;
    public float lifetime;
    public float damage = 21;
    private void DestroyBall()
    {
        Destroy(gameObject);
    }
    public void Start()
    {
        Invoke("DestroyBall", lifetime);
    }

    void Update()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        kickingA(collision);
        DestroyBall();
        
    }

    private void kickingA(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.value -= damage;
        }
    }

}
