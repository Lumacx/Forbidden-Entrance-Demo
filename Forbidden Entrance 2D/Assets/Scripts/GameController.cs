using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    Vector2 checkpointPos;
    Rigidbody2D PlayerRb;

    void Start()
    {
        checkpointPos = transform.position;
        PlayerRb = GetComponent<Rigidbody2D>();
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Respawn"))
        {
            Die();
        }
    }
    void Die()
    {
        StartCoroutine(Respawn(1f));
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }
    
    
    IEnumerator Respawn(float duration)
    {
        PlayerRb.linearVelocity = new Vector2(0,0);
        PlayerRb.simulated = false;
        transform.localPosition= new Vector3(0,0,0);
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        transform.localPosition = new Vector3(1,1,1);
        PlayerRb.simulated = true;

    }
}
