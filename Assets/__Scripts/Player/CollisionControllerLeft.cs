using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControllerLeft : MonoBehaviour
{
   public Player player;
     void OnCollisionEnter(Collision collision)
         {
           

             if(collision.gameObject.tag=="Barrier")
             {
               Debug.Log("hit");
               Destroy(collision.gameObject); 
               player.Hearts -=1;
               
               
             }

           

             if(collision.gameObject.tag=="passed")
             {
               Destroy(collision.gameObject); 
               player.Score += 10;
               
             }     
         }      
}
