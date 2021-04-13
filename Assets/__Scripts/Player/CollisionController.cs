using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

  public SpawnManager spawnManager;
  public Player player;
  public UIController playerSpeed;
    


     void OnCollisionEnter(Collision collision)
         {
           

             if(collision.gameObject.tag=="Barrier")
             {
               Debug.Log("hit");
               Destroy(collision.gameObject); 
               player.Hearts -=1;
          
               
             }

              if(collision.gameObject.tag=="Check")
             {  Destroy(collision.gameObject); 
                playerSpeed.speed +=5f;
             } 

             if(collision.gameObject.tag=="passed")
             {
              Destroy(collision.gameObject); 
              player.Score += 10;
              Debug.Log(player.Score);
           
             }     
         }      
}
