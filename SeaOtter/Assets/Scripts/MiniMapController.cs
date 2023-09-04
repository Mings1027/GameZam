using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    [SerializeField] private Transform playerUI;

    private void Update()
    {
        playerUI.position = new Vector3(playerUI.position.x, 0, playerUI.position.z);
    }
}
