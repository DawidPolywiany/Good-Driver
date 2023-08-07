using UnityEngine;
using UnityEngine.SceneManagement;

public class CarPhisic : MonoBehaviour
{
    //Car phisic variables
    public int yVector = 1; //Move car vector
    public float maxSpeed = 7.5f; //Max car speed
    private float carSpeed = 0f; //Car speed
    private float carRotation = 0f; //Car rotation
    public bool handBreak = false; //If hand break on
    //
    private GameObject carSprite; //Car texture object
    private Transform mainCamera; //Main camera transform

    //Gas pedal function
    public void Gas()
    {
        if (!handBreak) //If hand break off
        {
            if (carSpeed < maxSpeed) carSpeed += 0.1f; //Increase car speed
        }
        if (carSpeed > maxSpeed) carSpeed = maxSpeed; //Set max speed
    }

    //Break pedal function
    public void Break()
    {
        if (carSpeed > 0) carSpeed -= 0.3f; //Decrease car speed
        else carSpeed = 0; //Set min speed
    }
    //Rotate car function
    public void Rotate (float angle)
    {
        carRotation += angle; //Set angle
        if (carRotation > 7.5f) carRotation = 7.5f; //Set max angle
        if (carRotation < -7.5f) carRotation = -7.5f; //Set min angle
    }
    //Set carRotation 0
    public void ResetAngle ()
    {
        carRotation = 0; //Set angle
    }
    //Awake function
    private void Awake()
    {
        carSprite = transform.GetChild(0).gameObject; //Set car sprite
        mainCamera = Camera.main.transform; //Set main camera
    }
    //Update function
    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * carSpeed * yVector); //Move car forward
        transform.Rotate(0, 0, Time.deltaTime * carSpeed * carRotation * 1.5f); //Rotate car
        //Move camera
        if (carSprite.tag == "Player") //If this car - Player
        {
            Vector3 newCameraPosition = mainCamera.position; //Create new camera position
            //Change position x
            if (carSprite.transform.position.x - 0.65f > newCameraPosition.x) newCameraPosition.x = carSprite.transform.position.x - 0.65f; //Move left
            if (carSprite.transform.position.x + 0.65f < newCameraPosition.x) newCameraPosition.x = carSprite.transform.position.x + 0.65f; //Move right
            newCameraPosition.y = carSprite.transform.position.y + 1.05f; //Change position y
            mainCamera.position = newCameraPosition; //Set new position
        }
    }
    //Off this car
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (carSprite.tag == "Player") //If this car - Player
        {
            if (collision.tag == "Block" || collision.tag == "Barrier")
            {
                this.enabled = false; //Disable "CarPhisic" component
                SceneManager.LoadScene("LoseWindow", LoadSceneMode.Additive); //Open new scene
            }
        }
        else if (collision.tag == "Player") this.enabled = false; //Disable "CarPhisic" component)
    }
}
