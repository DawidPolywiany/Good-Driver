using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Animator[] closeAnimations = new Animator[3]; //All exit animations

    //When player touch screen
    public void OnPointerDown(PointerEventData eventData)
    {
    }
    //When player untouch screen
    public void OnPointerUp(PointerEventData evantData)
    {
        for (int i = 0; i < 3; i++) closeAnimations[i].SetBool("IfClose", true); //Start exit animations
        Invoke("StartGame", 0.55f); //Start "StartGame" function in 0.55f seconds
    }
    //Load game scene
    private void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); //Load scene
    }
}
