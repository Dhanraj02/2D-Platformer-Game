using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelcontroller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<playercontroller>() !=null)
        {
            Debug.Log("level finished by the player");
        }
    }
}
