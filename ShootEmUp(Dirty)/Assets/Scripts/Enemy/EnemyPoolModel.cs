using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
	public sealed class EnemyPoolModel : IInitializable
	{
		private readonly GameSettings _gameSettings;
		private readonly Transform _poolTransform;
		private readonly Transform _worldTransform;
		private readonly GameContext _gameContext;
		private readonly Queue<GameObject> enemyPool = new();

		public EnemyPoolModel(GameSettings gameSettings,
			Transform poolTransform,
			Transform worldTransform,
			GameContext gameContext)
		{
			_gameSettings = gameSettings;
			_poolTransform = poolTransform;
			_worldTransform = worldTransform;
			_gameContext = gameContext;
		}

		public void Initialize()
		{
			for (var i = 0; i < _gameSettings.InitialEnemyCount; i++)
			{
				var enemy = GameObject.Instantiate(_gameSettings.EnemyPrefab, _poolTransform);
				enemyPool.Enqueue(enemy);
			}
		}

		public EnemyCharacterEntity SpawnEnemy()
		{
			if (!enemyPool.TryDequeue(out var enemy))
				return null;
			var myPlayer = _gameContext.CharacterEntities.GetMyPlayer();
			enemy.transform.SetParent(_worldTransform);

			var spawnPosition = _gameSettings.SpawnPositions.RandomPosition();
			enemy.transform.position = spawnPosition;

			var attackPosition = _gameSettings.AttackPositions.RandomPosition();
			enemy.GetComponent<EnemyMoveComponent>().SetDestination(attackPosition);
			enemy.GetComponent<EnemyAttackComponent>().SetTarget(myPlayer.gameObject);
			return enemy.GetComponent<EnemyCharacterEntity>();
		}

		public void UnspawnEnemy(GameObject enemy)
		{
			enemy.transform.SetParent(_poolTransform);
			enemyPool.Enqueue(enemy);
		}
	}
}