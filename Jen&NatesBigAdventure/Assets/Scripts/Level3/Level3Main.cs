using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level3Main : MonoBehaviour
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
    public AudioSource portal;

    #region StarImages
    public Image[] stars;
    public Image[] levels;
    public Text LevelInforText;

    float gameTimer;
    float threeStarTime = 30;
    float twoStarTime = 40;
    float oneStarTime = 50;
    bool levelEnded;

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
        if (nateOnPortal && jenOnPortal && levelEnded == false)
        {
            // Check to see how many stars should be awarded.
            if (gameTimer < threeStarTime)
            {
                activeStars[6] = true;
                activeStars[7] = true;
                activeStars[8] = true;
            }

            else if (gameTimer < twoStarTime)
            {
                activeStars[6] = true;
                activeStars[7] = true;
            }

            else if (gameTimer < oneStarTime)
            {
                activeStars[6] = true;
            }

            activeLevels[3] = true;

            levelEnded = true;

            StartCoroutine(WaitForSoundAtEnd());
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
    }

    public void DeActiveWall(int wallNumber)
    {
        walls[wallNumber].GetComponentInChildren<MovingWallCont>().locked = true;
    }

    IEnumerator WaitForSoundAtEnd()
    {
        // Save Data and load home screen.
        SaveData();
        portal.Play();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
}
