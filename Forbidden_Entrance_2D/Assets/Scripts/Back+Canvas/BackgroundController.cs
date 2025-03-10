using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPos, lenght;
    public GameObject cam;
    public float parallaxEffect; // the speed at which the background should move relative to camera
    
    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        //Calculate distance background move based on cam movement
        float distance = cam.transform.position.x * parallaxEffect; // 0 = move with cam ~ 1 it won't move ~ 0.5 = half
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        // if background has reached the end of it's length adjust its position for infinite scrolling
        if (movement > startPos + lenght) 
        {
            startPos += lenght;
        }
        else if (movement < startPos - lenght) 
        
        {
            startPos -= lenght;
        }



    }


}
