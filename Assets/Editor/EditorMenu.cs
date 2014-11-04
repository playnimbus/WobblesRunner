using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class EditorMenu : EditorWindow {

    [MenuItem("Chunk Menu/Check Chunk Bounds")]
    private static void CheckChunkBounds()
    {
        GameObject[] chunk = GameObject.FindGameObjectsWithTag("Chunk");
        BoxCollider[] BoxColliders = chunk[0].GetComponentsInChildren<BoxCollider>();

        GameObject lowestX = null;
        GameObject highestX = null;

        for (int i = 0; i < BoxColliders.Length; i++)
        {
            if (lowestX == null)
            {
                lowestX = BoxColliders[i].gameObject;
                
            }
            else
            {
                if ((BoxColliders[i].gameObject.transform.position.x + BoxColliders[i].center.x) - (BoxColliders[i].bounds.size.x /2) <
                    ((lowestX.transform.position.x + lowestX.GetComponent<BoxCollider>().center.x) - (lowestX.GetComponent<BoxCollider>().bounds.size.x / 2)))
                {
                    lowestX = BoxColliders[i].gameObject;
                }
            }
        }

        for (int i = 0; i < BoxColliders.Length; i++)
        {
            if (highestX == null)
            {
                highestX = BoxColliders[i].gameObject;
            }
            else
            {
                if ((BoxColliders[i].gameObject.transform.position.x + BoxColliders[i].center.x) + (BoxColliders[i].bounds.size.x / 2) >
                    ((highestX.transform.position.x + highestX.GetComponent<BoxCollider>().bounds.center.x) + (highestX.GetComponent<BoxCollider>().bounds.size.x / 2)))
                {
                    highestX = BoxColliders[i].gameObject;
                }
            }
        }

        float leftSide = ((lowestX.transform.position.x + lowestX.gameObject.GetComponent<BoxCollider>().center.x) - (lowestX.gameObject.GetComponent<BoxCollider>().size.x / 2));
        float rightSide = ((highestX.transform.position.x + highestX.gameObject.GetComponent<BoxCollider>().center.x) + (highestX.gameObject.GetComponent<BoxCollider>().size.x / 2));
        chunk[0].gameObject.GetComponent<Chunk>().chunkLength = rightSide - leftSide;

        Debug.Log("HighestX: " + highestX.name + rightSide.ToString());
        Debug.Log("LowestX: " + lowestX.name + leftSide.ToString());


        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(leftSide, lowestX.transform.position.y, 0);

        cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(rightSide, highestX.transform.position.y, 0);
    }
}
