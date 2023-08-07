using UnityEngine;

public class TrainManager : MonoBehaviour
{
    public GameObject train; //Train object
    public GameObject trainLight; //Trainlight object
    private CarPhisic trainPhisic; //Train "CarPhisic" component
    private int randomDistance; //Random number 0, 29

    //Awake function
    private void Awake()
    {
        trainPhisic = train.GetComponent<CarPhisic>(); //Set train "CarPhisic" component
        randomDistance = Random.Range(0, 30); //Set random number
    }
    //Start function
    private void Start()
    {
        trainLight.transform.rotation = Quaternion.Euler(0, 0, 0); //Set Trainlight rotation 0
    }
    //Update function
    private void Update()
    {
        trainPhisic.Gas(); //Move train forward
        if (train.transform.position.x < transform.position.x - 15 - randomDistance) //If train is not in the camera
        {
            train.transform.Translate(Vector2.down * (Vector2.Distance(transform.position, train.transform.position) + 20)); //Move train to start position
            randomDistance = Random.Range(0, 30); //Reset random number
        }
    }
}
