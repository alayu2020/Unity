using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    private bool isDead;
    private Rigidbody2D rb2d;
    private Animator anim;                    //Reference to the Animator component.
    
    public int player_number;
    
    public float upForce = 200f;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
        
        if(gameObject.CompareTag("p1")){
            player_number = 0;
        }else{
            player_number = 1;
        }
        
        Debug.Log(player_number.ToString());    
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead){
            
            //Spacebar
            if(player_number == 1){
                
                if (Input.GetKeyDown(KeyCode.Space)){
                    anim.SetTrigger("Flap");

                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(0, upForce));
                }
                
            }else{
                
                //Left click
                if (Input.GetMouseButtonDown(0)){
                    anim.SetTrigger("Flap");

                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(0, upForce));
                }
                
            }
        }
    }
    
    void OnCollisionEnter2D(){
        rb2d.velocity = Vector2.zero;
        
      
        anim.SetTrigger ("Die");
        
        if(!isDead){
            GameControl.instance.BirdDied ();
        }
        
        isDead = true;


    }
}
