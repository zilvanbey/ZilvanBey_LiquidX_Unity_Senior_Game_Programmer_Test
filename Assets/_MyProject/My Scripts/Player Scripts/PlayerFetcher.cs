using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFetcher : MonoBehaviour
{
    public static GameObject player;

    private void Awake()
    {
        player = this.gameObject;
    }
}
