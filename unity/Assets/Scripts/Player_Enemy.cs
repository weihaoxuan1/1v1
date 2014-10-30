using UnityEngine;
using System.Collections;

public class Player_Enemy : Player
{
    public static Player_Enemy Instance;

    void Start()
    {
        Instance = this;
        opposite = Player_Man.Instance;
    }
}