using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

  public Player player;
  public UIController playerSpeed;
    


     void OnCollisionEnter(Collision collision)
         {
           

             if(collision.gameObject.tag=="Barrier")    // If the player collides with the barrier reduce hearts
             {
               Debug.Log("hit");
               Destroy(collision.gameObject); 
               player.Hearts -=1;           
          
               
             }

              if(collision.gameObject.tag=="Check")  // If the player goes past the barrier increase speed
             {  Destroy(collision.gameObject); 
                playerSpeed.speed +=2.5f;
             } 

             if(collision.gameObject.tag=="passed")  // If the player goes past the barrier increase scoresss
             {
              Destroy(collision.gameObject); 
              player.Score += 10;
              Debug.Log(player.Score);
           
             }     
         }      
}
