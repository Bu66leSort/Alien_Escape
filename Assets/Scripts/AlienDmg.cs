using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienDmg : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        GG_moving ggController = other.GetComponent<GG_moving>();

        if (ggController != null)
        {
            ggController.ChangeHealth(-1);
        }
    }
}
