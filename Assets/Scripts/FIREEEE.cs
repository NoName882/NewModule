using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIREEEE : MonoBehaviour
{
    public Fireball NormalBall;
    public Transform BallBallSource;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(NormalBall, BallBallSource.position, BallBallSource.rotation);
        }
    }
}
