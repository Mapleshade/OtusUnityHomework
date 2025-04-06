using UnityEngine;

namespace ShootEmUp
{
	public sealed class InputSystem : IUpdate
	{
		private readonly CharacterEntity _characterEntity;

		public InputSystem(CharacterEntity characterEntity)
		{
			_characterEntity = characterEntity;
		}

		public void CustomUpdate()
		{
			if (Input.GetKeyDown(KeyCode.Space))
				_characterEntity.FireComponent.FireRequired = true;

			if (Input.GetKey(KeyCode.LeftArrow))
			{
				_characterEntity.InputComponent.HorizontalDirection = -1;
				return;
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				_characterEntity.InputComponent.HorizontalDirection = 1;
				return;
			}

			_characterEntity.InputComponent.HorizontalDirection = 0;
		}
	}
}