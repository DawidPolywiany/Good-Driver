using UnityEngine;

public class FourCarManager : MonoBehaviour
{
    public GameObject[] Cars = new GameObject[4]; //Car objects
    private CarPhisic[] carPhisics = new CarPhisic[4]; //Car "CarPhisic" components

    //Awake function
    private void Awake()
    {
        for (int i = 0; i < 4; i++) //Iteration all car
        {
            carPhisics[i] = Cars[i].GetComponent<CarPhisic>(); //Set car "CarPhisic" components
            carPhisics[i].maxSpeed = Random.Range(5f, 15f); //Set random speed
        }
    }
    //Update function
    private void Update()
    {
        for (int i = 0; i < 4; i++) carPhisics[i].Gas(); //Move car forward
        for (int i = 0; i < 2; i++) //Iteration 1-2 car
        {
            if (Cars[i].transform.position.x < transform.position.x - 8) SetStartPosition(i); //If car is not in the camera
        }
        for (int i = 2; i < 4; i++) //Iteration 3-4 car
        {
            if (Cars[i].transform.position.x > transform.position.x + 8) SetStartPosition(i); //If car is not in the camera
        }
    }
    //Move car to start position
    private void SetStartPosition(int index)
    {
        Cars[index].transform.Translate(Vector2.down * 24); //Move car
        carPhisics[index].maxSpeed = Random.Range(5f, 15f); //Set random speed
    }
}
