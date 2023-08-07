using UnityEngine;

public class RoadBuilder : MonoBehaviour
{
    public GameObject[] roadBlocks = new GameObject[0]; //Road prefabs
    private Vector2 lastRoad; //Last road block position
    private Transform mainCamera; //Main camera transform

    //Awake function
    private void Awake()
    {
        mainCamera = Camera.main.transform; //Set camera transform
    }
    //Update function
    private void Update()
    {
        //If road under camera
        if (mainCamera.position.y - transform.position.y >= 15)
        {
            lastRoad = GlobalVariables.lastRoad; //Set last road position
            GameObject newRoad = Instantiate(roadBlocks[Random.Range(0, 6)]); //Create new road object
            newRoad.transform.rotation = Quaternion.Euler(0, 0, GlobalVariables.roadWay * -45); //Rotate road block
            //Set road position
            if (GlobalVariables.roadWay == 0) newRoad.transform.position = new Vector2(lastRoad.x, lastRoad.y + 10); //If road forward
            else newRoad.transform.position = new Vector2(lastRoad.x + 7.1f * GlobalVariables.roadWay, lastRoad.y + 7.1f); //If road left or right
            //Set scale
            if (newRoad.tag == "TurnRoad") //If road block is "TurnRoad"
            {
                if (GlobalVariables.roadWay == 0) //If road forward
                {
                    GlobalVariables.roadWay = 1 - Random.Range(0, 2) * 2; //Set road way: 1 or -1
                    newRoad.transform.localScale = new Vector2(GlobalVariables.roadWay * -1, 1); //Set new road scale
                }
                else //If road left or right
                {
                    newRoad.transform.localScale = new Vector2(GlobalVariables.roadWay, 1); //Set new road scale
                    GlobalVariables.roadWay = 0; //Set road way 0
                }
            }
            GlobalVariables.lastRoad = newRoad.transform.position; //Set last road position
            Destroy(gameObject); //Destroy this road
        }
    }
}
