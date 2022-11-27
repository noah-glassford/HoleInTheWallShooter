using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            GameManager._instance.Points++; //give the palyer a point 
            Destroy(gameObject);
        }    
    }
}
