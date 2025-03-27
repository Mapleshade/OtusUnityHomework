using UnityEngine;

namespace ShootEmUp
{
	public class GameInstaller : MonoBehaviour
	{
		[SerializeField]
		private GameSettings _gameSettings;
		[SerializeField]
		private GameLifeTimeSystem _gameLifeTimeSystem;
		[SerializeField]
		private Transform _bulletsPoolTransform;
		[SerializeField]
		private Transform _enemiesPoolTransform;
		[SerializeField]
		private Transform _worldTransform;
		[SerializeField]
		private CharacterEntity _characterEntity;

		[Header("Views")]
		[SerializeField]
		private ViewLevelBackground _viewLevelBackground;

		private void Awake()
		{
			var gameContext = new GameContext();
			gameContext.CharacterEntities.Add(_characterEntity);
			_gameLifeTimeSystem.SetGameContext(gameContext);

			var presenterLevelBackground = new PresenterLevelBackground(_viewLevelBackground, _gameSettings);
			gameContext.Initializables.Add(presenterLevelBackground);
			var levelSystem = new LevelSystem(presenterLevelBackground);
			gameContext.FixedUpdates.Add(levelSystem);

			var bulletsModel = new BulletsModel(_bulletsPoolTransform, _worldTransform, _gameSettings);
			gameContext.Initializables.Add(bulletsModel);

			var enemiesModel = new EnemiesModel();
			var enemiesPool = new EnemyPoolModel(_gameSettings, _enemiesPoolTransform, _worldTransform, gameContext);
			gameContext.Initializables.Add(enemiesPool);

			var inputSystem = new InputSystem(gameContext);
			gameContext.Updates.Add(inputSystem);

			var enemyLifeTimeSystem = new EnemyLifeTimeSystem(enemiesPool, enemiesModel);
			gameContext.Updates.Add(enemyLifeTimeSystem);

			var movementSystem = new MovementSystem(gameContext, enemiesModel, _gameSettings);
			gameContext.FixedUpdates.Add(movementSystem);

			var shootingSystem = new ShootingSystem(gameContext, bulletsModel, enemiesModel, _gameSettings);
			gameContext.FixedUpdates.Add(shootingSystem);

			var gameFinishSystem = new GameFinishSystem(gameContext);
			gameContext.Updates.Add(gameFinishSystem);
		}
	}
}