using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using System;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a player scored pointsenters from some reasons.
    /// </summary>
    /// <typeparam name="PlayerScoredPoints"></typeparam>
    public class PlayerScoredPoints : Simulation.Event<PlayerScoredPoints>
    {
        public int scoredePoints;

        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var gameController = GameObject.Find("ScorePanel");
            ScorePanel scorePanel = gameController.GetComponent<ScorePanel>();

            int finalScoredPoints = scorePanel.score + scoredePoints;
            finalScoredPoints = Math.Max(finalScoredPoints, 0);

            scorePanel.score = finalScoredPoints;            
        }
    }
}