using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGridCube : MonoBehaviour
{

	[Header("Configurations")]
	public int gridX;
	public int gridZ;
	[SerializeField] Vector3 gridOrigin = Vector3.zero;

	[Header("Floor")]
	[SerializeField] GameObject[] blockFloorToPickFrom;

	[Header("Enviroments")]
	[SerializeField] GameObject[] enviromentsToPickFrom;

	

    // Start is called before the first frame update
    void Start()
    {
        SpawnGridFloor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void PickAndSpawnFloor (Vector3 positionToSpawn,Quaternion rotationToSpawn){

	int randomIndex = Random.Range(0,blockFloorToPickFrom.Length);
	GameObject clone = Instantiate(blockFloorToPickFrom[randomIndex],positionToSpawn,rotationToSpawn);

	}

	void SpawnGridFloor () {

		for (int x = 0; x < gridX; x++){
			for (int z = 0; z < gridZ; z++){
				Vector3 spawnPositionFloor = new Vector3(x,0,z) + gridOrigin;
				PickAndSpawnFloor(spawnPositionFloor,Quaternion.identity);		
			}
		}

	}


}
