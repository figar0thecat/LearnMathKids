using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chapter1Test : MonoBehaviour
{
    public Player Playerprofile;
    public TMP_Text Header , Answersresults;
    public GameObject RespopupCorrrect, RespopupFalse, Finalpopup;
    public Button[] answerButtons;
    public Image[] images = new Image[10];
    int Correctnum , loop, corrects, wrongs;
    // Start is called before the first frame update
    void Start()
    {
        //initialize
        loop = 1; //Δεικτης για τις 5 προσπάθειες
        wrongs = 0;
        corrects = 0;
        Header.text = "Δωσε τα δυνατα σου ! Εχεις ακομα " + (6 - loop) + " προσπαθειες !";
        Chapter1TestBegin();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Chapter1TestBegin()
    {
        Correctnum = Random.Range(1, 11);
        //Ενεργοποιουμε μια μια τις εικονες αναλογα το correctnum
        for (int i = 0; i<Correctnum; i++)
        {
            if (images[i] != null)
            {
                images[i].gameObject.SetActive(true);
            }
        }
        Chapter1SetAnswers();
    }
    private void Chapter1SetAnswers()
    {
        int correctButtonIndex = Random.Range(0, 3); //για να δωσουμε την σωστη τιμη τυχαια σε 1 απο τα τρια κουτακια 
        int falseAnswer1 = Random.Range(1, 11);
        int falseAnswer2 = Random.Range(1, 11);

        //gave false answer μεταβλιτη που ελεγχει αν εχει δωθει λαθος απαντηση 
        bool gfa1 = false;


        for (int i = 0; i < 3; i++)
        {
            Button button = answerButtons[i];//πινακας που εχουμε βαλει τα 3 κουμπια !

            button.onClick.RemoveAllListeners();//βγαζω ολους τους listeners γιατι βγαζει conflict αν ξανα βαλεις 
            //listener πανω σε listener 
            button.onClick.AddListener(() => Chapter1CheckAnswer(button == answerButtons[correctButtonIndex]));
            //για καθε κουμπι , βαλε event onclick οπου θα καλεσει την συνάρτηση Chapter2CheckAnswer συγκρινοντας το
            //κουμπι που πατησε με το σωστο κουμπι επιστρεφοντας ετσι true / false 

            //παιρνουμε το text του καθε κουμπιου!
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();

            //αν το i ειναι ίσο με την θεση πινακα που εχουμε θεσει το σωστο κουμπι
            //τοτε αλλαξε το text στην σωστη απάντηση !
            if (i == correctButtonIndex)
            {
                buttonText.text = Correctnum.ToString();
            }
            else
            {
                // οσο οι λαθος απαντησεις ειναι ιδιες μεταξύ τους ή ισες με την σωστη τοτε ξανα βαλε αλλο τυχαίο !
                while (falseAnswer1 == Correctnum || falseAnswer1 == falseAnswer2)
                {
                    falseAnswer1 = Random.Range(1, 10);
                    Debug.Log("false answer 1 changed : " + falseAnswer1);
                }

                while (falseAnswer2 == Correctnum || falseAnswer2 == falseAnswer1)
                {
                    falseAnswer2 = Random.Range(1, 10);
                    Debug.Log("false answer 2 changed : " + falseAnswer2);
                }
                //αναθεση τιμων σε λαθος κουμπια !
                if (!gfa1)//αν δεν εχει δωθει ακομα η πρωτη λαθος απαντηση σε κουμπι
                {
                    buttonText.text = falseAnswer1.ToString();
                    gfa1 = true;
                }
                else
                {
                    buttonText.text = falseAnswer2.ToString();
                }
            }
        }
    }

    private void Chapter1CheckAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            RespopupCorrrect.SetActive(true);
            corrects++;
        }

        else
        {
            RespopupFalse.SetActive(true);
            wrongs++;
        }
        Chapter1Finalizer();
    }

    private void Chapter1Finalizer()
    {
        //reset images
        for (int i = 0; i < Correctnum; i++)
        {
            if (images[i] != null)
            {
                images[i].gameObject.SetActive(false);
            }
        }

        loop++;
        if (loop != 6)
        {
            Header.text = "Δωσε τα δυνατα σου ! Εχεις ακομα " + (6 - loop) + " προσπαθειες !";
            Chapter1TestBegin();
        }
        else
        {
            Answersresults.text = "Τελος ! Εκανες " + corrects + " Σωστα ! Και " + wrongs + " Λαθος !";
            Finalpopup.SetActive(true);
            //Περναει τον βαθμο στο ιστορικο !
            Playerprofile.mark1 = corrects;
            //reset το τεστ για επανεξεταση !
            loop = 1;
            wrongs = 0;
            corrects = 0;
            Header.text = "Δωσε τα δυνατα σου ! Εχεις ακομα " + (6 - loop) + " προσπαθειες !";
            Chapter1TestBegin();
        }
        

    }



}
