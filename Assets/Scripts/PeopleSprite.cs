using UnityEngine;

public class PeopleSprite : MonoBehaviour
{
    private int vector = 1; //Move vector: 1 or -1
    //Start function
    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0); //Set People sprite rotation 0
        transform.Translate(Vector2.up * Random.Range(0f, 0.15f)); //Set random start position
    }
    //Update function
    private void Update()
    {
        transform.Translate(Vector2.up * vector * Time.deltaTime * 2); //Move sprite
        if (transform.localPosition.x > 0.15f) vector = -1; //Set vector down
        if (transform.localPosition.x < 0) vector = 1; //Set vector up
    }
}
