using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Transform Player;

   
    private void Update()
    {

        if (Player.position.x - transform.position.x > 30)
        {
            transform.position = new Vector3(Player.position.x - 30, transform.position.y, transform.position.z);
        }
        else
        {
            transform.Translate(Vector3.right * (moveSpeed * Time.deltaTime));
        }
    }


}