using Platformer.Core;
using Platformer.Model;
using UnityEngine;

public class iceCaveScript : MonoBehaviour
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
