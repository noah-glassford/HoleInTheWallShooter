using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script needs to be attached to where the bullets come from
public class Shoot : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float BulletSpeed ;

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && GameManager._instance.isDead == false && SceneManager.GetActiveScene().name == "MainScene")
        {
            GameObject firedBullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
           
            firedBullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed, ForceMode.Impulse);

        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && SceneManager.GetActiveScene().name == "BuildingScene")
        {
            GameObject firedBullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        } 
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && SceneManager.GetActiveScene().name == "BuildingScene")
        {
            GameObject firedBullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        } 
    }
}
