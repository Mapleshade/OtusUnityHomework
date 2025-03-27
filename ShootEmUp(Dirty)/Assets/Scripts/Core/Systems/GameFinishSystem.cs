using UnityEngine;

namespace ShootEmUp
{
	public class GameFinishSystem : IUpdate
	{
		private readonly GameContext _gameContext;

		public GameFinishSystem(GameContext gameContext)
		{
			_gameContext = gameContext;
		}
		public void CustomUpdate()
		{
			var myPlayer = _gameContext.CharacterEntities.GetMyPlayer();
			if (!myPlayer.HitPointsComponent.IsHitPointsExists())
				FinishGame();
		}

		private void FinishGame()
		{
			Debug.Log("Game over!");
			Time.timeScale = 0;
		}
	}
}