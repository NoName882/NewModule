using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    
    
    public GameObject explodePrefab;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", 3);
    }

    private void Explosion()
    {
        Destroy(gameObject);
        var explode = Instantiate(explodePrefab);
        explode.transform.position = transform.position;
    }

    // Update is called once per frame
    
}
