using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class WalkTowardsPlayer : MonoBehaviour
{
   
    public bool TryingToCross = false;
    private float CrossingTimer = 0f;
    public float DelayBeforeCrossing = 5f;
    public float Speed = 1f;
    private GameObject PlayerTarget;
    private CharacterController ThisRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        ThisRigidBody = gameObject.GetComponent<CharacterController>();
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void FixedUpdate() 
    {
      
        Vector3 EnemyToPlayer = Vector3.zero;
        
        EnemyToPlayer = PlayerTarget.transform.position - transform.position;
        
        if(!TryingToCross && !GameManager._instance.isDead)
        {
            ThisRigidBody.Move((EnemyToPlayer.normalized *Time.fixedDeltaTime) * Speed);
        }
        else
        {
            CrossingTimer += Time.deltaTime;
        }
        

        if (EnemyToPlayer.magnitude <= 4f)
        {
            TryingToCross = true;
        }

        if (CrossingTimer > DelayBeforeCrossing)
        {
            TryingToCross = false;
            gameObject.layer = 0;
        }


    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
   }
}
