using UnityEngine;

public class CrosswalkManager : MonoBehaviour
{
    public GameObject[] peoples = new GameObject[2]; //People objects
    private CarPhisic[] carPhisics = new CarPhisic[2]; //People "CarPhisic" components
    private Vector3[] defaultPositions = new Vector3[2]; //People default positions

    //Awake function
    private void Awake()
    {
        for (int i = 0; i < 2; i++) //Iteration all car
        {
            carPhisics[i] = peoples[i].GetComponent<CarPhisic>(); //Set car "CarPhisic" components
            defaultPositions[i] = peoples[i].transform.localPosition; //Set default positions
            carPhisics[i].maxSpeed = Random.Range(1f, 3f); //Set random speed
        }
    }
    //Update function
    private void Update()
    {
        for (int i = 0; i < 2; i++) carPhisics[i].Gas(); //Move people forward
        if (peoples[0].transform.localPosition.x < -2.921f) SetStartPos(0); //If people is not in the camera
        if (peoples[1].transform.localPosition.x > 3.663f) SetStartPos(1); //If people is not in the camera
    }
    //Move people to start position
    private void SetStartPos(int index)
    {
        carPhisics[index].transform.localPosition = defaultPositions[index]; //Set start position
        carPhisics[index].maxSpeed = Random.Range(1f, 3f); //Set random speed
    }
}
