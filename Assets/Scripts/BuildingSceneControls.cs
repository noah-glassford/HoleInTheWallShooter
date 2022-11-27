using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingSceneControls : MonoBehaviour
{

public GameObject BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            GameObject[] BuiltObjects = GameObject.FindGameObjectsWithTag("Building");
            foreach (GameObject go in BuiltObjects)
            {
                Destroy(go);
            }
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
