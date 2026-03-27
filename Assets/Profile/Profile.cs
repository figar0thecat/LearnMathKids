using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Profile : MonoBehaviour
{
    public Player Playerprofile;
    public TMP_Text Txtname, Marksch1, Marksch2, Marksch3;
    public TMP_InputField InputName;
    // Start is called before the first frame update
    void Start()
    {
        //initialize Profile Page 
        Txtname.text = Playerprofile.name;
        CheckMarks();
    }

    // Update is called once per frame
    void Update()
    {
        CheckMarks();
    }

    void CheckMarks()
    {   //Check if Player havent done Tests !
        if (Playerprofile.mark1 != -1)
        {
            Marksch1.text = Playerprofile.mark1 + " στα 5 ";
        }
        if (Playerprofile.mark2 != -1)
        {
            Marksch2.text = Playerprofile.mark2 + " στα 5 ";
        }
        if (Playerprofile.mark3 != -1)
        {
            Marksch3.text = Playerprofile.mark3 + " στα 5 ";
        }

    }
    //changes the name of the current user !
    public void ChangeName()
    {
        Txtname.text = InputName.text;
        Playerprofile.name = Txtname.text;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetString("name",Playerprofile.name);
        PlayerPrefs.SetInt("mark1", Playerprofile.mark1);
        PlayerPrefs.SetInt("mark2", Playerprofile.mark2);
        PlayerPrefs.SetInt("mark3", Playerprofile.mark3);
    }
    
    public void LoadGame()
    {
        //Check if there is a file 
        if (PlayerPrefs.GetString("name")!="")
        {
        //Load user from file
        Playerprofile.name = PlayerPrefs.GetString("name");
        Playerprofile.mark1 = PlayerPrefs.GetInt("mark1");
        Playerprofile.mark2 = PlayerPrefs.GetInt("mark2");
        Playerprofile.mark3 = PlayerPrefs.GetInt("mark3");
        //Load new values to profile page 
        Txtname.text = Playerprofile.name;
        }
    }

    public void NewGame()
    {
        //delete old data
        PlayerPrefs.DeleteAll();
        //Reload Game 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
