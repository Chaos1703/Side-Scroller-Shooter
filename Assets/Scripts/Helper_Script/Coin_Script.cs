using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script : MonoBehaviour
{
    private Gun_Script gun;
    private float coin_speed = 0.1f;

    void Awake()
    {
        UI_Logic_Script.isGamePaused = false;
        gun = GameObject.Find("Gun").GetComponent<Gun_Script>();
    }
    void Update()
    {
        if(!UI_Logic_Script.isGamePaused)
            move_coin();
        StartCoroutine(self_destruct());
    }
    void move_coin()
    {
        transform.Translate(Vector3.left * coin_speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gun.AddCoinScore(1);
            Destroy(gameObject);
        }
    }

    IEnumerator self_destruct()
    {
        yield return new WaitForSeconds(5f);
            Destroy(gameObject);
    }
}
