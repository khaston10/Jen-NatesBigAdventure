using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{

    // These varaibles are saved to the Global COntrol
    // This integer can be between 0 and 1, end points included.
    public float musicLevel;
    public bool[] activeStars;
    public bool[] activeLevels;

    public Image[] stars;
    public AudioSource mainMusic;
    public Text ButtonInfoText;

    // Start is called before the first frame update
    void Start()
    {
        // Load data.
        musicLevel = GlobalControl.Instance.musicLevel;
        activeStars = GlobalControl.Instance.activeStars;
        activeLevels = GlobalControl.Instance.activeLevels;

        // Set active appropriate stars in array.
        for (int i = 0; i < stars.Length; i++)
        {
            if (activeStars[i] == false)
            {
                stars[i].gameObject.SetActive(false);
            }
        }

        // Set Music Volume.
        mainMusic.volume = musicLevel;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackHome()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

    public void HoverB()
    {
        ButtonInfoText.text = "Back to HOME SCREEN";
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void HoverQ()
    {
        ButtonInfoText.text = "QUIT GAME";
    }

    public void HoverExitText()
    {
        ButtonInfoText.text = "";
    }
}
