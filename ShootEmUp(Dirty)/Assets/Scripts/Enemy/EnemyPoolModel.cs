using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
	public sealed class EnemyPoolModel : IInitializable
	{
		private readonly GameSettings _gameSettings;
		private readonly Transform _poolTransform;
		private readonly Transform _worldTransform;
		private readonly CharacterEntity _characterEntity;
		private readonly Queue<GameObject> enemyPool = new();

		public EnemyPoolModel(GameSettings gameSettings,
			Transform poolTransform,
			Transform worldTransform,
			CharacterEntity characterEntity)
		{
			_gameSettings = gameSettings;
			_poolTransform = poolTransform;
			_worldTransform = worldTransform;
			_characterEntity = characterEntity;
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

			enemy.transform.SetParent(_worldTransform);

			var spawnPosition = _gameSettings.SpawnPositions.RandomPosition();
			enemy.transform.position = spawnPosition;

			var attackPosition = _gameSettings.AttackPositions.RandomPosition();
			enemy.GetComponent<EnemyMoveComponent>().SetDestination(attackPosition);
			enemy.GetComponent<EnemyAttackComponent>().SetTarget(_characterEntity.gameObject);
			return enemy.GetComponent<EnemyCharacterEntity>();
		}

		public void UnspawnEnemy(GameObject enemy)
		{
			enemy.transform.SetParent(_poolTransform);
			enemyPool.Enqueue(enemy);
		}
	}
}