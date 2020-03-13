using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    #region Variables

    // These varaibles are saved to the Global COntrol
    // This integer can be between 0 and 1, end points included.
    public float musicLevel;
    public bool[] activeStars;
    public bool[] activeLevels;

    public AudioSource mainMusic;
    public Slider musicSlider;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        musicLevel = GlobalControl.Instance.musicLevel;
        activeStars = GlobalControl.Instance.activeStars;
        activeLevels = GlobalControl.Instance.activeLevels;
    }

    // Update is called once per frame
    void Update()
    {
        VolumeController();
    }

    #region Functions

    //Save data to Global Control
    public void SaveData()
    {
        musicLevel = musicSlider.value;
        GlobalControl.Instance.musicLevel = musicLevel;
        GlobalControl.Instance.activeStars = activeStars;
        GlobalControl.Instance.activeLevels = activeLevels;
    }

    public void ClickStart()
    {
        SaveData();
        SceneManager.LoadScene(sceneBuildIndex:1);
    }

    public void ClickQuit()
    {
        Application.Quit();
    }

    public void VolumeController()
    {
        mainMusic.volume = musicSlider.value;

    }


    #endregion
}
