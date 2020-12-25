using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// Marks a gameobject as a spawnpoint in a scene.
    /// </summary>
    public class SpawnPoint : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredSpawnPointZone>();
                ev.spawnPoint = this;
            }
        }
    }
}