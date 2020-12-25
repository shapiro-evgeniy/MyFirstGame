using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{

    /// <summary>
    /// This event is triggered when the player character enters a trigger with a VictoryZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredVictoryZone"></typeparam>
    public class PlayerEnteredSpawnPointZone : Simulation.Event<PlayerEnteredSpawnPointZone>
    {
        public SpawnPoint spawnPoint;
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            model.spawnPoint = spawnPoint.transform;

            if (spawnPoint._audio && spawnPoint.yeap)
            {
                spawnPoint._audio.PlayOneShot(spawnPoint.yeap);
            }
        }
    }
}