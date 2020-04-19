using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisibility : MonoBehaviour
{
    public bool playerVisible = true;

    public bool getPlayerVisible()
    {
        return playerVisible;
    }

    public void setPlayerVisible(bool v)
    {
        playerVisible = v;
    }
}
