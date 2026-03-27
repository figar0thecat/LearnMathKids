using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenu : MonoBehaviour
{
    public GameObject lock1, lock2;
    public Player Playerprofile;
    // Start is called before the first frame update
    void Start()
    {
        CheckLock();
    }

    // Update is called once per frame
    void Update()
    {
        CheckLock();
    }
    void CheckLock()
    {
        //αν εχει παρει 3 και πανω ξεκλειδωσε το επομενο κεφάλαιο
        //αν οχι παραμένει κλειστο !
        //Το else ειναι για περιπτωση που κανει επανεξεταση και παρει κατω απο 3
        if(Playerprofile.mark1 > 2)
        {
            lock1.SetActive(false);
        }
        else
        {
            lock1.SetActive(true);
        }
        if (Playerprofile.mark2 > 2)
        {
            lock2.SetActive(false);
        }
        else
        {
            lock2.SetActive(true);
        }
    }
}
