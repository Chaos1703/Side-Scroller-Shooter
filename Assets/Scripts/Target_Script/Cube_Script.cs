using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Script : MonoBehaviour
{
    public Gun_Script gun;
    public Transform Upper_bound;
    public Transform lower_bound;
    private float speed = 0.05f;

    void Awake()
    {
        UI_Logic_Script.isGamePaused = false;
    }
    void Update()
    {
        if(!UI_Logic_Script.isGamePaused)
             move_cube();
    }
    void move_cube()
    {
        if (transform.position.y >= Upper_bound.position.y || transform.position.y <= lower_bound.position.y)
        {
            speed = -speed;
        }
        transform.Translate(Vector3.up * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
            gun.AddScore(1);
        }
    }
}
