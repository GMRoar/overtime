using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMechanics : MonoBehaviour
{
    // Variables used in the main program of the game.
    // Variables to show in the Unity Inspector
    public static bool clockedIn = false;
    public GameObject pauseMenu;
    public GameObject ConsignmentList;
    public int counter;
    public int randomNumber;
    public string location;
    public string item;
    public bool objectiveFinished = false;
    public bool notAlreadyRun = true;
    public bool isPlaying = false;
    public bool hasPlayed = false;

    // String lists of names, items, addresses and locations.
    private string[] itemList = new string[] { "Spirtzer", "DookerPancake", "Stickberry", "Usher", "Colins", "Bweanz", "Poptus", "Shams", "Rashist", "Blozro", "Gheggies", "Rhemet", "Gheebey", "Shemah", "Blesokordo", "Wheels on Meals", "DentureGummy", "MathJerps", "DooberZoober" };
    private string[] nameList = new string[] { "Katie Clarke", "Ben Parker", "Dell Conagher", "Debra Oliver", "Wilbur Ott", "Maybelline Atwood", "Percy Christopher", "Kelly Winter", "Gabe Oldwell", "Jasmine Ninness", "Lilac Sampson", "Brooke Osborne", "Annie Bush", "Frederick Wood", "John Ceiling", "Tyler Kimberley", "Jac Todd", "Kate Waters", "Caitlin Bird", "Tyler Petty" };
    private string[] addressList = new string[] { "80, Box Street, 2363, BOX", "64, Parcel Lane, 7563, RCL", "07, North Brib Street, 7299, ROB", "97, Engadine Road, 3848, ENG", "39, Paradox Lane, 5391, ALD", "32, Hoot Street, 1083, RFC", "20, Acacia Road, 4094, BOC", "72, Valley Road, 9203, VYB", "12, Cherry Lane, 6724, JAN", "17, Starfish Street, 1280, SWO", "81, Countdown Road, 2392, CTD", "44, Maple Lane, 7390, MAL", "56, Blu Lane, 8200, UBL", "70, Gravel Road, 6789, GFC", "24, Decor Street, 4210, DQM", "01, Cafe Road, 9329, CFA", "59, Hedge Lane, 6238, HDG", "88, Tek Street, 8800, BNE", "70, Kira Road, 1320, SYL", "43, Floor Lane, 6289, FLR" };
    private string[] locationList = new string[] { "A1L", "A2L", "A3L", "A4L", "A5L", "A6L", "A7L", "B1L", "B2L", "B3L", "B4L", "B5L", "B6L", "B7L", "C1L", "C2L", "C3L", "C4L", "C5L", "C6L", "C7L", "D1L", "D2L", "D3L", "D4L", "D5L", "D6L", "D7L", "E1L", "E2L", "E3L", "E4L", "E5L", "E6L", "E7L", "A1R", "A2R", "A3R", "A4R", "A5R", "A6R", "A7R", "B1R", "B2R", "B3R", "B4R", "B5R", "B6R", "B7R", "C1R", "C2R", "C3R", "C4R", "C5R", "C6R", "C7R", "D1R", "D2R", "D3R", "D4R", "D5R", "D6R", "D7R", "E1R", "E2R", "E3R", "E4R", "E5R", "E6R", "E7R", };

    // Creation of new lists to store the chosen variables from the above lists.
    private List<string> chosenLocations = new List<string>();

    private List<string> chosenItemList = new List<string>();
    private List<string> inventoryArray = new List<string>();
    private List<string> truckArray = new List<string>();

    // Variables for the audio sources.
    public AudioSource footsteps;

    public AudioSource pickup;
    public AudioSource music;
    public AudioClip pop;
    public AudioClip intro1;
    public AudioClip intro2;
    public AudioClip loop1;
    public AudioClip loop2;
    public AudioClip whistle;
    public AudioClip clockInSound;
    public AudioClip clockTick;
    public GameObject footstepsObject;
    public AudioSource timerSounds;

    // Variables for the UI
    public bool inTruckRange = false;

    public GameObject invBox1;
    public GameObject invBox2;
    public GameObject invBox3;
    public GameObject invBox4;
    public GameObject invBox5;
    public GameObject wrongBoxText;
    public GameObject Tutorial;
    public GameObject invisibleWall;

    public GameObject selected1;
    public GameObject selected2;
    public GameObject selected3;
    public GameObject selected4;
    public GameObject selected5;
    public GameObject startPrompt;
    public string currentItem;

    // Variables for Raycasting and Selecting Objects
    public GameObject player;

    public Vector3 position;

    // Variables for inventory slots and consignment list text items
    public TMP_Text inventory1;

    public TMP_Text inventory2;
    public TMP_Text inventory3;
    public TMP_Text inventory4;
    public TMP_Text inventory5;
    public float inventorySelected;
    public int selectedSlot = 0;
    public TMP_Text deliveryName;
    public TMP_Text Address;
    public TMP_Text ItemLocation1;
    public TMP_Text ItemLocation2;
    public TMP_Text ItemLocation3;
    public TMP_Text ItemLocation4;
    public TMP_Text ItemLocation5;
    public TMP_Text ItemLocation6;
    public TMP_Text ItemLocation7;
    public TMP_Text ItemLocation8;
    public TMP_Text ItemName1;
    public TMP_Text ItemName2;
    public TMP_Text ItemName3;
    public TMP_Text ItemName4;
    public TMP_Text ItemName5;
    public TMP_Text ItemName6;
    public TMP_Text ItemName7;
    public TMP_Text ItemName8;
    public TMP_Text PlayerName;

    // Variables for GameObjects for boxes in the game, and their particle systems

    public GameObject A1L;
    public GameObject A2L;
    public GameObject A3L;
    public GameObject A4L;
    public GameObject A5L;
    public GameObject A6L;
    public GameObject A7L;
    public GameObject B1L;
    public GameObject B2L;
    public GameObject B3L;
    public GameObject B4L;
    public GameObject B5L;
    public GameObject B6L;
    public GameObject B7L;
    public GameObject C1L;
    public GameObject C2L;
    public GameObject C3L;
    public GameObject C4L;
    public GameObject C5L;
    public GameObject C6L;
    public GameObject C7L;
    public GameObject D1L;
    public GameObject D2L;
    public GameObject D3L;
    public GameObject D4L;
    public GameObject D5L;
    public GameObject D6L;
    public GameObject D7L;
    public GameObject E1L;
    public GameObject E2L;
    public GameObject E3L;
    public GameObject E4L;
    public GameObject E5L;
    public GameObject E6L;
    public GameObject E7L;

    public GameObject A1R;
    public GameObject A2R;
    public GameObject A3R;
    public GameObject A4R;
    public GameObject A5R;
    public GameObject A6R;
    public GameObject A7R;
    public GameObject B1R;
    public GameObject B2R;
    public GameObject B3R;
    public GameObject B4R;
    public GameObject B5R;
    public GameObject B6R;
    public GameObject B7R;
    public GameObject C1R;
    public GameObject C2R;
    public GameObject C3R;
    public GameObject C4R;
    public GameObject C5R;
    public GameObject C6R;
    public GameObject C7R;
    public GameObject D1R;
    public GameObject D2R;
    public GameObject D3R;
    public GameObject D4R;
    public GameObject D5R;
    public GameObject D6R;
    public GameObject D7R;
    public GameObject E1R;
    public GameObject E2R;
    public GameObject E3R;
    public GameObject E4R;
    public GameObject E5R;
    public GameObject E6R;
    public GameObject E7R;

    public ParticleSystem A1LParticle;
    public ParticleSystem A2LParticle;
    public ParticleSystem A3LParticle;
    public ParticleSystem A4LParticle;
    public ParticleSystem A5LParticle;
    public ParticleSystem A6LParticle;
    public ParticleSystem A7LParticle;
    public ParticleSystem B1LParticle;
    public ParticleSystem B2LParticle;
    public ParticleSystem B3LParticle;
    public ParticleSystem B4LParticle;
    public ParticleSystem B5LParticle;
    public ParticleSystem B6LParticle;
    public ParticleSystem B7LParticle;
    public ParticleSystem C1LParticle;
    public ParticleSystem C2LParticle;
    public ParticleSystem C3LParticle;
    public ParticleSystem C4LParticle;
    public ParticleSystem C5LParticle;
    public ParticleSystem C6LParticle;
    public ParticleSystem C7LParticle;
    public ParticleSystem D1LParticle;
    public ParticleSystem D2LParticle;
    public ParticleSystem D3LParticle;
    public ParticleSystem D4LParticle;
    public ParticleSystem D5LParticle;
    public ParticleSystem D6LParticle;
    public ParticleSystem D7LParticle;
    public ParticleSystem E1LParticle;
    public ParticleSystem E2LParticle;
    public ParticleSystem E3LParticle;
    public ParticleSystem E4LParticle;
    public ParticleSystem E5LParticle;
    public ParticleSystem E6LParticle;
    public ParticleSystem E7LParticle;

    public ParticleSystem A1RParticle;
    public ParticleSystem A2RParticle;
    public ParticleSystem A3RParticle;
    public ParticleSystem A4RParticle;
    public ParticleSystem A5RParticle;
    public ParticleSystem A6RParticle;
    public ParticleSystem A7RParticle;
    public ParticleSystem B1RParticle;
    public ParticleSystem B2RParticle;
    public ParticleSystem B3RParticle;
    public ParticleSystem B4RParticle;
    public ParticleSystem B5RParticle;
    public ParticleSystem B6RParticle;
    public ParticleSystem B7RParticle;
    public ParticleSystem C1RParticle;
    public ParticleSystem C2RParticle;
    public ParticleSystem C3RParticle;
    public ParticleSystem C4RParticle;
    public ParticleSystem C5RParticle;
    public ParticleSystem C6RParticle;
    public ParticleSystem C7RParticle;
    public ParticleSystem D1RParticle;
    public ParticleSystem D2RParticle;
    public ParticleSystem D3RParticle;
    public ParticleSystem D4RParticle;
    public ParticleSystem D5RParticle;
    public ParticleSystem D6RParticle;
    public ParticleSystem D7RParticle;
    public ParticleSystem E1RParticle;
    public ParticleSystem E2RParticle;
    public ParticleSystem E3RParticle;
    public ParticleSystem E4RParticle;
    public ParticleSystem E5RParticle;
    public ParticleSystem E6RParticle;
    public ParticleSystem E7RParticle;

    // Variables for finish screens.

    private bool clockedInRange;
    public GameObject finishedMenu;
    public GameObject overtimeResult;
    public GameObject finishResult;
    public TMP_Text gameLevel;
    public TMP_Text timeLeft;
    public TMP_Text rating;

    private void Start()
    {
        // Clear music clip
        music.clip = null;
        // Flags for testing during development, this will print the chosen locations to the console before and after the generation of the list.
        foreach (var x in chosenLocations)
        {
            Debug.Log(x.ToString());
        }
        GenerateListOfItems();
        foreach (var x in chosenLocations)
        {
            Debug.Log(x.ToString());
        }
        // Checks to see if the tutorial should be shown based on the saved file, otherwise shows the start prompt text.
        if (PlayerPrefs.GetInt("doTutorial") == 1)
        {
            Tutorial.SetActive(true);
            startPrompt.SetActive(true);
            PlayerPrefs.SetInt("doTutorial", 0);
            PlayerPrefs.Save();
        }
        else
        {
            startPrompt.SetActive(true);
        }
        // Chooses between the two gameplay tracks and intros.
        if (UnityEngine.Random.Range(1, 2) == 1)
        {
            music.PlayOneShot(intro1);
            music.clip = loop1;
            music.PlayDelayed(intro1.length);
        }
        else
        {
            music.PlayOneShot(intro2);
            music.clip = loop2;
            music.PlayDelayed(intro2.length);
        }
    }

    public void Inventory()
    {
        // Sets the items in the inventory array
        if (inventoryArray.Count <= 0)
        {
            inventory1.text = "";
            inventory2.text = "";
            inventory3.text = "";
            inventory4.text = "";
            inventory5.text = "";
        }
        if (inventoryArray.Count == 1)
        {
            inventory1.text = inventoryArray[0];
            inventory2.text = "";
        }
        else
        {
            inventory2.text = "";
            inventory3.text = "";
            inventory4.text = "";
            inventory5.text = "";
        }
        if (inventoryArray.Count == 2)
        {
            inventory1.text = inventoryArray[0];
            inventory2.text = inventoryArray[1];
        }
        else
        {
            inventory3.text = "";
            inventory4.text = "";
            inventory5.text = "";
        }
        if (inventoryArray.Count == 3)
        {
            inventory1.text = inventoryArray[0];
            inventory2.text = inventoryArray[1];
            inventory3.text = inventoryArray[2];
        }
        else
        {
            inventory4.text = "";
            inventory5.text = "";
        }
        if (inventoryArray.Count == 4)
        {
            inventory1.text = inventoryArray[0];
            inventory2.text = inventoryArray[1];
            inventory3.text = inventoryArray[2];
            inventory4.text = inventoryArray[3];
        }
        else
        {
            inventory5.text = "";
        }
        if (inventoryArray.Count == 5)
        {
            inventory1.text = inventoryArray[0];
            inventory2.text = inventoryArray[1];
            inventory3.text = inventoryArray[2];
            inventory4.text = inventoryArray[3];
            inventory5.text = inventoryArray[4];
        }

        // Sets the selected slot based on the hotbar.
        if (Input.GetKeyDown("1") & inventoryArray.Count >= 1)
        {
            selectedSlot = 0;
            selected1.SetActive(true);
            selected2.SetActive(false);
            selected3.SetActive(false);
            selected4.SetActive(false);
            selected5.SetActive(false);
        }
        if (Input.GetKeyDown("2") & inventoryArray.Count >= 2)
        {
            selectedSlot = 1;
            selected2.SetActive(true);
            selected1.SetActive(false);
            selected3.SetActive(false);
            selected4.SetActive(false);
            selected5.SetActive(false);
        }
        if (Input.GetKeyDown("3") & inventoryArray.Count >= 3)
        {
            selectedSlot = 2;
            selected3.SetActive(true);
            selected1.SetActive(false);
            selected2.SetActive(false);
            selected4.SetActive(false);
            selected5.SetActive(false);
        }
        if (Input.GetKeyDown("4") & inventoryArray.Count >= 4)
        {
            selectedSlot = 3;
            selected4.SetActive(true);
            selected2.SetActive(false);
            selected3.SetActive(false);
            selected1.SetActive(false);
            selected5.SetActive(false);
        }
        if (Input.GetKeyDown("5") & inventoryArray.Count >= 5)
        {
            selectedSlot = 4;
            selected5.SetActive(true);
            selected2.SetActive(false);
            selected3.SetActive(false);
            selected4.SetActive(false);
            selected1.SetActive(false);
        }
    }

    public void Update()
    {
        if (Input.GetButtonDown("Journal") & !ConsignmentList.activeSelf)
        {
            ConsignmentList.SetActive(true);
            Debug.Log("journal pressed");
        }
        else if (Input.GetButtonDown("Journal") & ConsignmentList.activeSelf)
        {
            ConsignmentList.SetActive(false);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            pauseMenu.SetActive(true);
        }

        if (!clockedIn)
        {
            invisibleWall.SetActive(true);
        }
        else
        {
            invisibleWall.SetActive(false);
        }

        if (inTruckRange)
        {
            SetTruckBoxes();
        }
        if (clockedInRange & Input.GetButtonDown("Activate"))
        {
            clockedIn = true;
            pickup.PlayOneShot(clockInSound);
            Debug.Log("ClockedIN");
            startPrompt.SetActive(false);
        }
        if (objectiveFinished & clockedInRange & Input.GetButtonDown("Activate"))
        {
            clockedIn = false;
            pickup.PlayOneShot(clockInSound);
        }

        if (truckArray.Count == 8)
        {
            print("done");
            Debug.Log(clockedIn);
            objectiveFinished = true;
        }

        if (objectiveFinished & !clockedIn & notAlreadyRun)
        {
            GameResult();
        }
        SoundController();
        Inventory();
        PickUpBox();
        UpdateUI();
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "clockIn")
        {
            clockedInRange = true;
            Debug.Log("Clock in range");
        }
        if (collider.gameObject.tag == "truck")
        {
            inTruckRange = true;

            Debug.Log("Truck is detected");
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "truck")
        {
            inTruckRange = false;
        }

        if (collider.gameObject.tag == "clockIn")
        {
            clockedInRange = false;
        }
    }

    public void GenerateListOfItems()
    {
        /// This function will take items from the arrays and place it in another array, then another part of this will take each part of the list, such as chosenLocation[1] = ItemLocation1.text, repeated this line for each item and location.
        /// This is an absolutely terrible way to do this, but my pea brain can't think of another way to do this other than just writing out each line, which is easier.
        /// After the lists are generated, you are going to have to figure out a way to generate the items on the fly based on this list, and maybe even colour the boxes yellow, so that they are differentiated?
        while (chosenLocations.Count != 8)
        {
            location = locationList[UnityEngine.Random.Range(0, 69)];
            item = itemList[UnityEngine.Random.Range(0, 19)];
            chosenItemList.Add(item);

            if (!chosenLocations.Contains(location))
            {
                chosenLocations.Add(location);
            }
        }
        
        PlayerName.text = PlayerPrefs.GetString("playerName");
        deliveryName.text = nameList[UnityEngine.Random.Range(0, 19)];
        Address.text = addressList[UnityEngine.Random.Range(0, 19)];

        ItemLocation1.text = chosenLocations[0];
        if (truckArray.Contains(chosenLocations[0])) { ItemLocation1.color = Color.green; }
        ItemLocation2.text = chosenLocations[1];
        if (truckArray.Contains(chosenLocations[1])) { ItemLocation2.color = Color.green; }
        ItemLocation3.text = chosenLocations[2];
        if (truckArray.Contains(chosenLocations[2])) { ItemLocation3.color = Color.green; }
        ItemLocation4.text = chosenLocations[3];
        if (truckArray.Contains(chosenLocations[3])) { ItemLocation4.color = Color.green; }
        ItemLocation5.text = chosenLocations[4];
        if (truckArray.Contains(chosenLocations[4])) { ItemLocation5.color = Color.green; }
        ItemLocation6.text = chosenLocations[5];
        if (truckArray.Contains(chosenLocations[5])) { ItemLocation6.color = Color.green; }
        ItemLocation7.text = chosenLocations[6];
        if (truckArray.Contains(chosenLocations[6])) { ItemLocation7.color = Color.green; }
        ItemLocation8.text = chosenLocations[7];
        if (truckArray.Contains(chosenLocations[7])) { ItemLocation8.color = Color.green; }

        ItemName1.text = chosenItemList[0];
        ItemName2.text = chosenItemList[1];
        ItemName3.text = chosenItemList[2];
        ItemName4.text = chosenItemList[3];
        ItemName5.text = chosenItemList[4];
        ItemName6.text = chosenItemList[5];
        ItemName7.text = chosenItemList[6];
        ItemName8.text = chosenItemList[7];

        if (chosenLocations.Contains("A1L"))
        {
            A1LParticle.Play();
        }
        if (chosenLocations.Contains("A1R"))
        {
            A1RParticle.Play();
        }
        if (chosenLocations.Contains("A2L"))
        {
            A2LParticle.Play();
        }
        if (chosenLocations.Contains("A2R"))
        {
            A2RParticle.Play();
        }
        if (chosenLocations.Contains("A3L"))
        {
            A3LParticle.Play();
        }
        if (chosenLocations.Contains("A3R"))
        {
            A3RParticle.Play();
        }
        if (chosenLocations.Contains("A4L"))
        {
            A4LParticle.Play();
        }
        if (chosenLocations.Contains("A4R"))
        {
            A4RParticle.Play();
        }
        if (chosenLocations.Contains("A5L"))
        {
            A5LParticle.Play();
        }
        if (chosenLocations.Contains("A5R"))
        {
            A5RParticle.Play();
        }
        if (chosenLocations.Contains("A6L"))
        {
            A6LParticle.Play();
        }
        if (chosenLocations.Contains("A6R"))
        {
            A6RParticle.Play();
        }
        if (chosenLocations.Contains("A7L"))
        {
            A7LParticle.Play();
        }
        if (chosenLocations.Contains("A7R"))
        {
            A7RParticle.Play();
        }

        if (chosenLocations.Contains("B1L"))
        {
            B1LParticle.Play();
        }
        if (chosenLocations.Contains("B1R"))
        {
            B1RParticle.Play();
        }
        if (chosenLocations.Contains("B2L"))
        {
            B2LParticle.Play();
        }
        if (chosenLocations.Contains("B2R"))
        {
            B2RParticle.Play();
        }
        if (chosenLocations.Contains("B3L"))
        {
            B3LParticle.Play();
        }
        if (chosenLocations.Contains("B3R"))
        {
            B3RParticle.Play();
        }
        if (chosenLocations.Contains("B4L"))
        {
            B4LParticle.Play();
        }
        if (chosenLocations.Contains("B4R"))
        {
            B4RParticle.Play();
        }
        if (chosenLocations.Contains("B5L"))
        {
            B5LParticle.Play();
        }
        if (chosenLocations.Contains("B5R"))
        {
            B5RParticle.Play();
        }
        if (chosenLocations.Contains("B6L"))
        {
            B6LParticle.Play();
        }
        if (chosenLocations.Contains("B6R"))
        {
            B6RParticle.Play();
        }
        if (chosenLocations.Contains("B7L"))
        {
            B7LParticle.Play();
        }
        if (chosenLocations.Contains("B7R"))
        {
            B7RParticle.Play();
        }

        if (chosenLocations.Contains("C1L"))
        {
            C1LParticle.Play();
        }
        if (chosenLocations.Contains("C1R"))
        {
            C1RParticle.Play();
        }
        if (chosenLocations.Contains("C2L"))
        {
            C2LParticle.Play();
        }
        if (chosenLocations.Contains("C2R"))
        {
            C2RParticle.Play();
        }
        if (chosenLocations.Contains("C3L"))
        {
            C3LParticle.Play();
        }
        if (chosenLocations.Contains("C3R"))
        {
            C3RParticle.Play();
        }
        if (chosenLocations.Contains("C4L"))
        {
            C4LParticle.Play();
        }
        if (chosenLocations.Contains("C4R"))
        {
            C4RParticle.Play();
        }
        if (chosenLocations.Contains("C5L"))
        {
            C5LParticle.Play();
        }
        if (chosenLocations.Contains("C5R"))
        {
            C5RParticle.Play();
        }
        if (chosenLocations.Contains("C6L"))
        {
            C6LParticle.Play();
        }
        if (chosenLocations.Contains("C6R"))
        {
            C6RParticle.Play();
        }
        if (chosenLocations.Contains("C7L"))
        {
            C7LParticle.Play();
        }
        if (chosenLocations.Contains("C7R"))
        {
            C7RParticle.Play();
        }

        if (chosenLocations.Contains("D1L"))
        {
            D1LParticle.Play();
        }
        if (chosenLocations.Contains("D1R"))
        {
            D1RParticle.Play();
        }
        if (chosenLocations.Contains("D2L"))
        {
            D2LParticle.Play();
        }
        if (chosenLocations.Contains("D2R"))
        {
            D2RParticle.Play();
        }
        if (chosenLocations.Contains("D3L"))
        {
            D3LParticle.Play();
        }
        if (chosenLocations.Contains("D3R"))
        {
            D3RParticle.Play();
        }
        if (chosenLocations.Contains("D4L"))
        {
            D4LParticle.Play();
        }
        if (chosenLocations.Contains("D4R"))
        {
            D4RParticle.Play();
        }
        if (chosenLocations.Contains("D5L"))
        {
            D5LParticle.Play();
        }
        if (chosenLocations.Contains("D5R"))
        {
            D5RParticle.Play();
        }
        if (chosenLocations.Contains("D6L"))
        {
            D6LParticle.Play();
        }
        if (chosenLocations.Contains("D6R"))
        {
            D6RParticle.Play();
        }
        if (chosenLocations.Contains("D7L"))
        {
            D7LParticle.Play();
        }
        if (chosenLocations.Contains("D7R"))
        {
            D7RParticle.Play();
        }

        if (chosenLocations.Contains("E1L"))
        {
            E1LParticle.Play();
        }
        if (chosenLocations.Contains("E1R"))
        {
            E1RParticle.Play();
        }
        if (chosenLocations.Contains("E2L"))
        {
            E2LParticle.Play();
        }
        if (chosenLocations.Contains("E2R"))
        {
            E2RParticle.Play();
        }
        if (chosenLocations.Contains("E3L"))
        {
            E3LParticle.Play();
        }
        if (chosenLocations.Contains("E3R"))
        {
            E3RParticle.Play();
        }
        if (chosenLocations.Contains("E4L"))
        {
            E4LParticle.Play();
        }
        if (chosenLocations.Contains("E4R"))
        {
            E4RParticle.Play();
        }
        if (chosenLocations.Contains("E5L"))
        {
            E5LParticle.Play();
        }
        if (chosenLocations.Contains("E5R"))
        {
            E5RParticle.Play();
        }
        if (chosenLocations.Contains("E6L"))
        {
            E6LParticle.Play();
        }
        if (chosenLocations.Contains("E6R"))
        {
            E6RParticle.Play();
        }
        if (chosenLocations.Contains("E7L"))
        {
            E7LParticle.Play();
        }
        if (chosenLocations.Contains("E7R"))
        {
            E7RParticle.Play();
        }
    }

    public void SetTruckBoxes()
    {
        if (inventoryArray.Count != 0)
        {
            if (Input.GetButtonDown("Activate") & chosenLocations.Contains(inventoryArray[selectedSlot]))
            {
                currentItem = inventoryArray[selectedSlot];
                truckArray.Add(currentItem);
                inventoryArray.Remove(currentItem);
                currentItem = "";
                selectedSlot = 0;
                pickup.PlayOneShot(pop);
                UpdateUI();
            }
        }
        else
        {
        }
    }

    public void UpdateUI()
    {
        if (inventoryArray.Count <= 0)
        {
            invBox1.SetActive(false);
            invBox2.SetActive(false);
            invBox3.SetActive(false);
            invBox4.SetActive(false);
            invBox5.SetActive(false);
        }
        if (inventoryArray.Count == 1)
        {
            invBox1.SetActive(true);
            invBox2.SetActive(false);
        }
        else
        {
            invBox2.SetActive(false);
            invBox3.SetActive(false);
            invBox4.SetActive(false);
            invBox5.SetActive(false);
        }
        if (inventoryArray.Count == 2)
        {
            invBox1.SetActive(true);
            invBox2.SetActive(true);
        }
        else
        {
            invBox3.SetActive(false);
            invBox4.SetActive(false);
            invBox5.SetActive(false);
        }
        if (inventoryArray.Count == 3)
        {
            invBox1.SetActive(true);
            invBox2.SetActive(true);
            invBox3.SetActive(true);
        }
        else
        {
            invBox4.SetActive(false);
            invBox5.SetActive(false);
        }
        if (inventoryArray.Count == 4)
        {
            invBox1.SetActive(true);
            invBox2.SetActive(true);
            invBox3.SetActive(true);
            invBox4.SetActive(true);
        }
        else
        {
            invBox5.SetActive(false);
        }
        if (inventoryArray.Count == 5)
        {
            invBox1.SetActive(true);
            invBox2.SetActive(true);
            invBox3.SetActive(true);
            invBox4.SetActive(true);
            invBox5.SetActive(true);
        }
        else
        {
        }

        ItemLocation1.text = chosenLocations[0];
        if (truckArray.Contains(chosenLocations[0])) { ItemLocation1.color = Color.green; }
        ItemLocation2.text = chosenLocations[1];
        if (truckArray.Contains(chosenLocations[1])) { ItemLocation2.color = Color.green; }
        ItemLocation3.text = chosenLocations[2];
        if (truckArray.Contains(chosenLocations[2])) { ItemLocation3.color = Color.green; }
        ItemLocation4.text = chosenLocations[3];
        if (truckArray.Contains(chosenLocations[3])) { ItemLocation4.color = Color.green; }
        ItemLocation5.text = chosenLocations[4];
        if (truckArray.Contains(chosenLocations[4])) { ItemLocation5.color = Color.green; }
        ItemLocation6.text = chosenLocations[5];
        if (truckArray.Contains(chosenLocations[5])) { ItemLocation6.color = Color.green; }
        ItemLocation7.text = chosenLocations[6];
        if (truckArray.Contains(chosenLocations[6])) { ItemLocation7.color = Color.green; }
        ItemLocation8.text = chosenLocations[7];
        if (truckArray.Contains(chosenLocations[7])) { ItemLocation8.color = Color.green; }
    }

    public void SoundController()
    {
        if (Input.GetAxis("Horizontal") != 0 & Input.GetKey(KeyCode.LeftShift))
        {
            footstepsObject.SetActive(true);
            footsteps.pitch = 0.79f;
        }
        else if (Input.GetAxis("Vertical") != 0 & Input.GetKey(KeyCode.LeftShift))
        {
            footstepsObject.SetActive(true);
            footsteps.pitch = 0.79f;
        }
        else if (Input.GetAxis("Horizontal") != 0)
        {
            footstepsObject.SetActive(true);
            footsteps.pitch = 0.58f;
        }
        else if (Input.GetAxis("Vertical") != 0)
        {
            footstepsObject.SetActive(true);
            footsteps.pitch = 0.58f;
        }
        else
        {
            footstepsObject.SetActive(false);
        }

        if (Timer.levelTimeRemaining < 60 & isPlaying == false)
        {
            timerSounds.Play();
            isPlaying = true;
        }
        if (Timer.OvertimeMode & !hasPlayed)
        {
            music.PlayOneShot(whistle, 1);
            hasPlayed = true;
            timerSounds.Pause();
        }
    }

    public void PickUpBox()
    {
        if (chosenLocations.Contains(BoxHighlight._selection.name))
        {
            wrongBoxText.SetActive(false);
        }
        else if (Input.GetButtonDown("Activate") & !chosenLocations.Contains(BoxHighlight._selection.name))
        {
            wrongBoxText.SetActive(true);
        }
        if (Input.GetButtonDown("Activate") & inventoryArray.Count < 5 & inTruckRange == false & chosenLocations.Contains(BoxHighlight._selection.name))
        {
            pickup.PlayOneShot(pop);
            inventoryArray.Add(BoxHighlight._selection.name);
            BoxHighlight._selection.gameObject.SetActive(false);
        }

        UpdateUI();
    }

    public void GameResult()
    {
        if (true)
        {
            notAlreadyRun = false;
            finishedMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;

            if (Timer.OvertimeMode)
            {
                overtimeResult.SetActive(true);
                gameLevel.text = Convert.ToString(PlayerPrefs.GetInt("playerLevel"));
                rating.text = "Unsatisfactory";
                rating.color = Color.red;
            }
            if (!Timer.OvertimeMode)
            {
                finishResult.SetActive(true);
                gameLevel.text = Convert.ToString(PlayerPrefs.GetInt("playerLevel"));
                PlayerPrefs.SetInt("playerLevel", PlayerPrefs.GetInt("playerLevel") + 1);
                timeLeft.text = Convert.ToString(Timer.levelTimeRemaining);
                if (Timer.levelTimeRemaining <= 30)
                {
                    rating.text = "C";
                    rating.color = Color.yellow;
                }
                else if (Timer.levelTimeRemaining <= 60)
                {
                    rating.text = "B";
                    rating.color = Color.green;
                }
                else if (Timer.levelTimeRemaining >= 80)
                {
                    rating.text = "A";
                    rating.color = Color.blue;
                }
                else if (Timer.levelTimeRemaining >= 100)
                {
                    rating.text = "S";
                    rating.color = Color.red;
                }
                else
                {
                    rating.text = "C";
                }
            }
        }
    }

    public void NextLevel()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level1");
    }

    public void Exit()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainMenu");
    }
}