using UnityEngine;
using System.Collections;

public class ChunkSpawner : MonoBehaviour {

    public GameObject wobble;
    float levelLength = 0;

	// Use this for initialization
	void Start () {
        GameObject chunk = (GameObject)Instantiate(Resources.Load("Chunk1"));
        levelLength = chunk.GetComponent<Chunk>().chunkLength;
        chunk.transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

        if (wobble.transform.position.x > levelLength - 10)
        {
            GameObject chunk = (GameObject)Instantiate(Resources.Load("Chunk1"));
            chunk.transform.position = new Vector3(levelLength, 0, 0);
            levelLength += chunk.GetComponent<Chunk>().chunkLength;
            
        }

	}
}
