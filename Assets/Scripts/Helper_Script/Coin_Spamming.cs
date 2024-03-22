using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spamming : MonoBehaviour
{
    public GameObject coin;
    public Transform upper_bound;
    public Transform lower_bound;

    void Awake()
    {
        Time.timeScale = 1;
        UI_Logic_Script.isGamePaused = false;
    }
    void Start()
    {
        if(!UI_Logic_Script.isGamePaused)
            StartCoroutine(spam_coin());
    }

    IEnumerator spam_coin()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(coin, new Vector3(upper_bound.position.x, Random.Range(lower_bound.position.y, upper_bound.position.y), 0), Quaternion.identity);
        StartCoroutine(spam_coin());
    }
}
