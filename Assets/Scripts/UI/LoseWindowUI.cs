using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseWindowUI : MonoBehaviour
{
    public Slider loadBar; //Timer to exit
    public Animator panelAnimator; //Main panel "Animator" component
    public Animator backgroundAnimator; //Background "Animator" component

    //Watch Ad button
    public void Continue ()
    {

    }
    //Exit to main menu button
    public void Skip ()
    {
        panelAnimator.SetBool("IfClose", true); //Start main panel animation
        backgroundAnimator.SetBool("OpenNewScene", true); //Start background animation
        Invoke("ExitToMainMenu", 0.55f); //Start "ExitToMainMenu" function in 0.55f seconds
    }
    //Update function
    private void Update()
    {
        loadBar.value -= Time.deltaTime / 5; //Use timer to exit
        if (loadBar.value <= 0) Skip(); //Exit to main menu
    }
    //Load main menu scene
    private void ExitToMainMenu ()
    {
        SceneManager.LoadScene("MainMenu"); //Load scene
    }
}
