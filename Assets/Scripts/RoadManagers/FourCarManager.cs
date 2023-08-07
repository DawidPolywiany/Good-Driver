using UnityEngine;

public class FourCarManager : MonoBehaviour
{
    public GameObject[] cars = new GameObject[4]; //Car objects
    public GameObject traficLight; //Traficlight object
    public Sprite[] carTextures = new Sprite[6]; //Car textures
    private Animator traficLightAnimator; //Traficlight animator
    private CarPhisic[] carPhisics = new CarPhisic[4]; //Car "CarPhisic" components

    //Awake function
    private void Awake()
    {
        traficLightAnimator = traficLight.GetComponent<Animator>(); //Set Traficlight animator
        for (int i = 0; i < 4; i++) //Iteration all car
        {
            carPhisics[i] = cars[i].GetComponent<CarPhisic>(); //Set car "CarPhisic" components
            carPhisics[i].maxSpeed = Random.Range(5f, 15f); //Set random speed
            carPhisics[i].GetComponentInChildren<SpriteRenderer>().sprite = carTextures[Random.Range(0, 6)]; //Set random sprite
        }
        InvokeRepeating("SetNewColor", 1f, 5f); //Repeat function "SetNewColor"
    }
    //Start function
    private void Start()
    {
        traficLight.transform.rotation = Quaternion.Euler(0, 0, 0); //Set Traficlight rotation 0
    }
    //Update function
    private void Update()
    {
        for (int i = 0; i < 4; i++) //Iteration all car
        {
            //Stop car if traficlight have green color
            if (!traficLightAnimator.GetBool("IsStop") && Vector2.Distance(cars[i].transform.position, transform.position) > 8.5f) carPhisics[i].Break();
            else carPhisics[i].Gas(); //Move car forward
        }
        for (int i = 0; i < 2; i++) //Iteration 1-2 car
        {
            if (cars[i].transform.position.x < transform.position.x - 8) SetStartPosition(i); //If car is not in the camera
        }
        for (int i = 2; i < 4; i++) //Iteration 3-4 car
        {
            if (cars[i].transform.position.x > transform.position.x + 8) SetStartPosition(i); //If car is not in the camera
        }
    }
    //Move car to start position
    private void SetStartPosition(int index)
    {
        cars[index].transform.Translate(Vector2.down * 24); //Move car
        carPhisics[index].maxSpeed = Random.Range(5f, 15f); //Set random speed
        carPhisics[index].GetComponentInChildren<SpriteRenderer>().sprite = carTextures[Random.Range(0, 6)]; //Set random sprite
    }
    //Set new traficlight color
    private void SetNewColor ()
    {
        traficLightAnimator.SetBool("IsStop", !traficLightAnimator.GetBool("IsStop")); //Invert "IsStop" variable
    }
}
