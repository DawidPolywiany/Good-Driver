using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject steeringWheel; //Steering wheel ui object
    public CarPhisic carPhisic; //Player car "CarPhisic" component
    private Image wheelImage; //Steering wheel ui image
    private bool ifCarMoving = false; //While car moving - true

    //When player touch screen
    public void OnPointerDown (PointerEventData eventData)
    {
        ifCarMoving = true; //Car mooving
    }
    //When player untouch screen
    public void OnPointerUp (PointerEventData evantData)
    {
        ifCarMoving = false; //Car stopping
        carPhisic.ResetAngle(); //Set angle 0
        steeringWheel.transform.rotation = Quaternion.Euler(0, 0, 0); //Set steering wheel angle 0
    }
    //When player drag finger
    public void OnDrag (PointerEventData eventData)
    {
        carPhisic.Rotate(eventData.delta.x * -25 / Screen.height); //Set car angle
        steeringWheel.transform.Rotate(0, 0, eventData.delta.x * -150 / Screen.height); //Rotate steering wheel
    }
    //Awake function
    private void Awake()
    {
        wheelImage = steeringWheel.GetComponent<Image>(); //Set steering wheel ui image
    }
    //Fixed Update function
    private void FixedUpdate()
    {
        if (ifCarMoving) //When car moving
        {
            carPhisic.Gas(); //Move player car
            //Show steering wheel
            if (wheelImage.color.a < 1) wheelImage.color = new Color(wheelImage.color.r, wheelImage.color.g, wheelImage.color.b, wheelImage.color.a + 0.1f);
        }
        else
        {
            carPhisic.Break(); //Stop player car
            //Hide steering wheel
            if (wheelImage.color.a > 0) wheelImage.color = new Color(wheelImage.color.r, wheelImage.color.g, wheelImage.color.b, wheelImage.color.a - 0.1f);
        }
    }
}
