using UnityEngine;
using Zenject;

namespace ShootEmUp
{
	public class PresenterLevelBackground : IInitializable
	{
		private ViewLevelBackground _view;
		private GameSettings _gameSettings;
		private float _startPositionY;
		private float _endPositionY;
		private float _movingSpeedY;
		private float _positionX;
		private float _positionZ;

		public PresenterLevelBackground(ViewLevelBackground view,
			GameSettings gameSettings)
		{
			_view = view;
			_gameSettings = gameSettings;
		}

		public void Initialize()
		{
			_startPositionY = _gameSettings.StartPositionY;
			_endPositionY = _gameSettings.EndPositionY;
			_movingSpeedY = _gameSettings.MovingSpeedY;
			var position = _view.LevelTransform.position;
			_positionX = position.x;
			_positionZ = position.z;
		}

		public void Update()
		{
			if (_view.LevelTransform.position.y <= _endPositionY)
			{
				_view.LevelTransform.position = new Vector3(
					_positionX,
					_startPositionY,
					_positionZ
				);
			}

			_view.LevelTransform.position -= new Vector3(
				_positionX,
				_movingSpeedY * Time.fixedDeltaTime,
				_positionZ
			);
		}
	}
}