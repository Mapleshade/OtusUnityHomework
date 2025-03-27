using UnityEngine;

namespace ShootEmUp
{
	public sealed class InputSystem : IUpdate
	{
		private readonly GameContext _gameContext;

		public InputSystem(GameContext gameContext)
		{
			_gameContext = gameContext;
		}

		public void CustomUpdate()
		{
			var myPlayer = _gameContext.CharacterEntities.GetMyPlayer();

			if (Input.GetKeyDown(KeyCode.Space))
				myPlayer.FireComponent.FireRequired = true;

			if (Input.GetKey(KeyCode.LeftArrow))
			{
				myPlayer.InputComponent.HorizontalDirection = -1;
				return;
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				myPlayer.InputComponent.HorizontalDirection = 1;
				return;
			}

			myPlayer.InputComponent.HorizontalDirection = 0;
		}
	}
}