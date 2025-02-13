using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoinReward : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
             // Destroy the coin
            Destroy(gameObject);
        }
    }
 
}
