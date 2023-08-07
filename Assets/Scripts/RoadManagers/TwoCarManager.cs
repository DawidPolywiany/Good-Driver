using UnityEngine;

public class TwoCarManager : MonoBehaviour
{
    public GameObject[] cars = new GameObject[2]; //Car objects
    private CarPhisic[] carPhisics = new CarPhisic[2]; //Car "CarPhisic" components

    //Awake function
    private void Awake()
    {
        for (int i = 0; i < 2; i++) //Iteration all car
        {
            carPhisics[i] = cars[i].GetComponent<CarPhisic>(); //Set car "CarPhisic" components
            carPhisics[i].maxSpeed = Random.Range(5f, 10f); //Set random speed
        }
    }
    //Update function
    private void Update()
    {
        for (int i = 0; i < 2; i++) carPhisics[i].Gas(); //Move car forward
        if (cars[0].transform.position.x < transform.position.x - 8) SetStartPosition(0); //If car is not in the camera
        if (cars[1].transform.position.x > transform.position.x + 8) SetStartPosition(1); //If car is not in the camera
    }
    //Move car to start position
    private void SetStartPosition (int index)
    {
        cars[index].transform.Translate(Vector2.down * 24); //Move car
        carPhisics[index].maxSpeed = Random.Range(5f, 10f); //Set random speed
    }
}
