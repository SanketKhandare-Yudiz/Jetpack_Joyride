using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shild : PlayerActions
{
    private float speed = 20f;
    Player player;

    public override void movment()
    {
       player.player.AddForce(Vector2.right * speed);
    }
}
