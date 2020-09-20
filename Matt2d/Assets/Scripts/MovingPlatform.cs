using System;
using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField] private Transform origin, target;
    [SerializeField] private float platformSpeed = 1f;
    private bool _moveToTarget = false;
    
    void Start()
    {

    }


    void FixedUpdate()
    {
        if (transform.position == origin.position)
        {
            _moveToTarget = true;
        }

        if (transform.position == target.position)
        {
            _moveToTarget = false; //aka move towards origin
        }

        if (_moveToTarget)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * platformSpeed);
        }
        else //aka move to origin
        {
            transform.position =
                Vector3.MoveTowards(transform.position, origin.position, Time.deltaTime * platformSpeed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           other.transform.SetParent(null);
        }
    }
}
