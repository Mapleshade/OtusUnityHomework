using UnityEngine;

namespace ShootEmUp
{
	public class GameFinishSystem : IUpdate
	{
		private readonly CharacterEntity _characterEntity;

		public GameFinishSystem(CharacterEntity characterEntity)
		{
			_characterEntity = characterEntity;
		}
		public void CustomUpdate()
		{
			if (!_characterEntity.HitPointsComponent.IsHitPointsExists())
				FinishGame();
		}

		private void FinishGame()
		{
			Debug.Log("Game over!");
			Time.timeScale = 0;
		}
	}
}