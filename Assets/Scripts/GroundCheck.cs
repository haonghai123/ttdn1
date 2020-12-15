using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GroundCheck : MonoBehaviour {
 
    public Player player;
 
    // Use this for initialization
    void Start () {
        player = gameObject.GetComponentInParent<Player>();
    }
 
    // Update is called once per frame
    void FixedUpdate()
    {
           
    }
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        player.grounded = true ;
    }
 
    private void OnCollisionStay2D(Collision2D collision)
    {
        player.grounded = true;
    }
 
    private void OnCollisionExit2D(Collision2D collision)
    {
        player.grounded = false;
    }
}