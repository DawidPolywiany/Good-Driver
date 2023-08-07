using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    private Transform mainCamera; //Main camera transform
    private CarPhisic carPhisic; //Car "CarPhisic" component

    //Awake function
    private void Awake()
    {
        mainCamera = Camera.main.transform; //Set camera transform
        carPhisic = GetComponent<CarPhisic>(); //Set "CarPhisic" component
        carPhisic.maxSpeed = Random.Range(5f, 10f); //Set random speed
    }
    //Update function
    private void Update()
    {
        if (mainCamera.position.y + 10 > transform.position.y) carPhisic.Gas(); //Move car forward
    }
}
