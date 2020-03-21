using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level4Main : MonoBehaviour
{

    #region Variables

    // These varaibles are saved to the Global COntrol
    // This integer can be between 0 and 1, end points included.
    public float musicLevel;
    public bool[] activeStars;
    public bool[] activeLevels;
    public Text timeDisplay;
    public GameObject natePortalImage;
    public GameObject JenPortalImage;
    public int itemsClaimedNate;
    public int itemsClaimedJen;
    public bool nateOnPortal;
    public bool jenOnPortal;
    public AudioSource mainMusic;

    #region StarImages
    public Image[] stars;
    public Image[] levels;
    public Text LevelInforText;

    float gameTimer;
    float threeStarTime = 10;
    float twoStarTime = 20;
    float oneStarTime = 30;

    // Variables for moving walls and switches.
    public GameObject[] walls;



    #endregion

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        // Load data.
        musicLevel = GlobalControl.Instance.musicLevel;
        activeStars = GlobalControl.Instance.activeStars;
        activeLevels = GlobalControl.Instance.activeLevels;

        // Set variables to initial value.
        gameTimer = 0;
        itemsClaimedNate = 0;
        itemsClaimedJen = 0;
        nateOnPortal = false;
        jenOnPortal = false;

        // Set portals invisible.
        natePortalImage.SetActive(false);
        JenPortalImage.SetActive(false);

        // Update Music Volume.
        VolumeController();
    }

    // Update is called once per frame
    void Update()
    {

        gameTimer += Time.deltaTime;
        timeDisplay.text = Mathf.FloorToInt(gameTimer).ToString();

        // Create Portals when players have collected items.
        if (itemsClaimedNate >= 3 && natePortalImage.activeSelf == false)
        {
            natePortalImage.SetActive(true);
        }

        if (itemsClaimedJen >= 3 && JenPortalImage.activeSelf == false)
        {
            JenPortalImage.SetActive(true);
        }

        // If players are on portals and items have been collected then the user will go back to home screen.
        if (nateOnPortal && jenOnPortal)
        {
            // Check to see how many stars should be awarded.
            if (gameTimer < threeStarTime)
            {
                activeStars[9] = true;
                activeStars[10] = true;
                activeStars [11] = true;
            }

            else if (gameTimer < twoStarTime)
            {
                activeStars[9] = true;
                activeStars[10] = true;
            }

            else activeStars[9] = true;

            activeLevels[4] = true;

            // Save Data and load home screen.
            SaveData();
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }




    }

    public void SaveData()
    {
        //musicLevel = musicSlider.value;
        GlobalControl.Instance.musicLevel = musicLevel;
        GlobalControl.Instance.activeStars = activeStars;
        GlobalControl.Instance.activeLevels = activeLevels;
    }

    public void VolumeController()
    {
        mainMusic.volume = musicLevel;

    }

    public void ActivateWall(int wallNumber)
    {
        walls[wallNumber].GetComponentInChildren<MovingWallCont>().locked = false;
        Debug.Log("Active");
    }

    public void DeActiveWall(int wallNumber)
    {
        walls[wallNumber].GetComponentInChildren<MovingWallCont>().locked = true;
        Debug.Log("DeActive");
    }
}