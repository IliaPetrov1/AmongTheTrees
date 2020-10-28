using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignoring : MonoBehaviour
{
    public GameObject red;
    public GameObject blue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(red.GetComponent<Collider2D>(), blue.GetComponent<Collider2D>());
    }
}
