using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CoinCollection : MonoBehaviour
{
    private int bunnyCount;
    public int bunniesToWin = 5;
    public TMP_Text bunnyText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag=="Bunny")
        {
            bunnyCount++;
            bunnyText.text= bunnyCount.ToString();
            Debug.Log(bunnyCount);
            Destroy(other.gameObject);

            if (bunnyCount >= bunniesToWin)
            {
                LoadNextScene();
            }
        }
    }


    void LoadNextScene()
    {
        SceneManager.LoadScene(2);
    }
}