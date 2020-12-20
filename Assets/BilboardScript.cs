using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilboardScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            PlatformerModel model = Simulation.GetModel<PlatformerModel>();
            if (model != null)
            {
                model.spawnPoint = transform;
                Debug.Log("Update spawn model");
            }
        }
    }
}
