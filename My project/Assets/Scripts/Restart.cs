using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject deathText;
    public GameObject deathImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void enableButton()
    {
        restartButton.SetActive(true);
        deathText.SetActive(true);
        deathImage.SetActive(true);
    }

    public void restartScene()
    {
        SceneManager.LoadScene(0);
    }
}
