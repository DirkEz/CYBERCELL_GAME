using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSMG : MonoBehaviour, IDamageable
{
    [Header("OBJECTS")]
    public GameObject ARObject;
    public GameObject SMGObject;
    public float health;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) {
            ActivateTargetObject();
            DeactivateTargetObject();
        };
    }
    public void ActivateTargetObject()
    {
        // Check if the targetObject is not null
        if (SMGObject != null)
        {
            // Activate the target object
            SMGObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Target object is not assigned!");
        }
    }

    // Function to deactivate the target object
    public void DeactivateTargetObject()
    {
        // Check if the targetObject is not null
        if (ARObject != null)
        {
            // Deactivate the target object
            ARObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Target object is not assigned!");
        }
    }
}

