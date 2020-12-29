using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using System;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a player enters a trigger with a DeathZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredDeathZone"></typeparam>
    public class PlayerEnteredDeathZone : Simulation.Event<PlayerEnteredDeathZone>
    {
        public DeathZone deathzone;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var gameController = GameObject.Find("GameController");            
            var popupMessage = gameController.GetComponent<PopupMessage>();
            popupMessage.Open(CallBack);
        }

        private void CallBack(bool isCorrectAnswer)
        {
            if (!isCorrectAnswer)
            {
                RaiseScoredPoint(-10);
                Simulation.Schedule<PlayerDeath>(0);
                return;
            }

            var player = model.player;
            player.Teleport(deathzone.safeObject.transform.position);
            RaiseScoredPoint(50);
        }

        private void RaiseScoredPoint(int scoredPoint)
        {
            var ev = Simulation.Schedule<PlayerScoredPoints>();
            ev.scoredePoints = scoredPoint;
        }
    }
}