using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    public string name;
    public int mark1;
    public int mark2;
    public int mark3;

    public Player()
    {
        this.name = "Επισκεπτης";
        this.mark1 = -1;
        this.mark2 = -1;
        this.mark3 = -1;
    }
}
