using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    // Start is called before the first frame update
    public float zSpawn = 0;
    private float blockLength = 186;
    public int numberOfBlocks = 5;
    public Transform playerTransform;
    private List<GameObject> activeBlocks = new List<GameObject>();
    void Start()
    {
 
        for(int i = 0; i<numberOfBlocks;i++){
            if(i == 0){
                SpawnBlock(0);
            }
                else{
                    SpawnBlock(Random.Range(0,blockPrefabs.Length));
                }
            }
             
        }
    

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z -450 > zSpawn - (numberOfBlocks * blockLength)){
            SpawnBlock(Random.Range(0,blockPrefabs.Length));
            DeleteBlock();
        }
        
    }

    public void SpawnBlock(int blockIndex){
        GameObject go = Instantiate(blockPrefabs[blockIndex],transform.forward * zSpawn,transform.rotation);
        activeBlocks.Add(go);
        zSpawn += blockLength;
       
    }

    private void DeleteBlock(){
        Destroy(activeBlocks[0]);
        activeBlocks.RemoveAt(0);
    }
}
