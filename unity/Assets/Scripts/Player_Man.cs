using UnityEngine;
using System.Collections;

public class Player_Man : Player
{
    public static Player_Man Instance;

    void Start()
    {
        Instance = this;
        opposite = Player_Enemy.Instance;
    }
}