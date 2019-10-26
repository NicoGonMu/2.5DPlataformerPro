using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Player>().AddCoins();
        Destroy(gameObject);
    }
}
