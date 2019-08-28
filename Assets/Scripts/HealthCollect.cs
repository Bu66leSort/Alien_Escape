using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollect : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        GG_moving ggController = other.GetComponent<GG_moving>();

        if (ggController != null && ggController.currentHealth < ggController.maxHealth)
        {
            ggController.ChangeHealth(1);
            Destroy(gameObject);
        }
    }
}
