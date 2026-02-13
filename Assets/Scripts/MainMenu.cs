using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    //  El 1 Es por la escena, se puede ver en FILE - Build Profiles

    public void PlayGame(){
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame(){
        Application.Quit();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
