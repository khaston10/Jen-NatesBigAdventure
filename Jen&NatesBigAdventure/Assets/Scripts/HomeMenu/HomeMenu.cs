using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    #region Variables

    // These varaibles are saved to the Global COntrol
    // This integer can be between 0 and 1, end points included.
    public float musicLevel;
    public bool[] activeStars;
    public bool[] activeLevels;

    #region StarImages
    public Image[] stars;
    public Image[] levels;
    public Text LevelInforText;
    #endregion

    public AudioSource mainMusic;
    public Slider musicSlider;

    #endregion

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

        // Set active Levels;
        for (int i = 0; i < activeLevels.Length; i++)
        {
            if (activeLevels[i] == false)
            {
                levels[i].gameObject.SetActive(false);
            }
        }

        // Set Music Volume.
        mainMusic.volume = musicLevel;
        musicSlider.value = musicLevel;

    }

    // Update is called once per frame
    void Update()
    {
        VolumeController();

    }

    #region Functions


    public void SaveData()
    {
        musicLevel = musicSlider.value;
        GlobalControl.Instance.musicLevel = musicLevel;
        GlobalControl.Instance.activeStars = activeStars;
        GlobalControl.Instance.activeLevels = activeLevels;
    }

    public void VolumeController()
    {
        mainMusic.volume = musicSlider.value;

    }

    public void HoverExit()
    {
        LevelInforText.text = "";
    }

    public void Hover1()
    {
        LevelInforText.text = "First Date: The Picnic";
    }

    public void Click1()
    {
        //SaveData();
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }

    public void Hover2()
    {
        LevelInforText.text = "Second Date: Home Movie Night";
    }

    public void Click2()
    {
        //SaveData();
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }

    public void Hover3()
    {
        LevelInforText.text = "A Beach Proposal";
    }

    public void Click3()
    {
        //SaveData();
        SceneManager.LoadScene(sceneBuildIndex: 4);
    }

    public void Hover4()
    {
        LevelInforText.text = "The Wedding";
        SceneManager.LoadScene(sceneBuildIndex: 5);
    }

    public void Hover5()
    {
        LevelInforText.text = "The HoneyMoon";
    }


    #endregion
}