using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Controller : MonoBehaviour
{
    public Transform destination; //Other Portal
    GameObject player;
    //Animation anim; //** animation not working, remove due to time but keep the portal to teleport
    Rigidbody2D playerRB;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Access the player
      //  anim = player.GetComponent<Animation>();
        playerRB = player.GetComponent<Rigidbody2D>();

    }

    private void OnTriggerEnter2D (Collider2D collision)

    {
        if (collision.CompareTag("Player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position) > 0.3f)

            {
                StartCoroutine(PortalIn());
            }
        }
    }

    IEnumerator PortalIn()
    {
        playerRB.simulated = false;
        SFX_Manager.Play("Teleport_in");
        //anim.Play("teleport in");
        StartCoroutine(MoveInPortal());
        yield return new WaitForSeconds(0.5f);
        player.transform.position = destination.transform.position;
        playerRB.linearVelocity = Vector2.zero;
        SFX_Manager.Play("Teleport_out");
        //anim.Play("teleport out");
        yield return new WaitForSeconds(0.5f);
        playerRB.simulated = true;
    }

    IEnumerator MoveInPortal()
    {
        float timer = 0;
        while (timer < 0.5f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, 3 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
    }

}
