using UnityEngine;

public class NpcControl : MonoBehaviour
{
    public CarPhisic carPhisic; //This car "CarPhisic" component

    //If car in watch zone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Block") carPhisic.handBreak = true; //On hand break
    }
    //If car stay in watch zone
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Block") carPhisic.Break(); //Break thic car
    }
    //If car leave watch zone
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Block") carPhisic.handBreak = false; //Off hand break
    }
}
