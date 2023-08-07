using UnityEngine;

public class GameUI : MonoBehaviour
{
    public GameObject[] roadBlocks = new GameObject[0]; //Road prefabs

    //Awake function
    private void Awake()
    {
        Application.targetFrameRate = 60; //Frame Controll
        //Create start road
        for (int i = 0; i < 3; i++)
        {
            GameObject newRoad = Instantiate(roadBlocks[Random.Range(0, 5)]); //Create new road object
            newRoad.transform.position = new Vector2(0, 10 * (i + 1)); //Set road position
            GlobalVariables.lastRoad = newRoad.transform.position; //Set last road position
        }
    }
}
