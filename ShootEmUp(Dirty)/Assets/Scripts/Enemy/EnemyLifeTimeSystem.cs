using UnityEngine;

namespace ShootEmUp
{
	public sealed class EnemyLifeTimeSystem : IUpdate
	{
		private const float SYSTEM_TIMEOUT = 1f;
		private readonly EnemyPoolModel enemyPoolModel;
		private readonly EnemiesModel _enemiesModel;
		private float _lastCheckTimestamp = Utils.NOT_INITIALIZED_DEFAULT_TIME;

		public EnemyLifeTimeSystem(EnemyPoolModel enemyPoolModel,
			EnemiesModel enemiesModel)
		{
			this.enemyPoolModel = enemyPoolModel;
			_enemiesModel = enemiesModel;
		}

		public void CustomUpdate()
		{
			SpawnEnemies();
			CheckEnemiesHp();
		}

		private void CheckEnemiesHp()
		{
			for (var i = _enemiesModel.ActiveEnemies.Count - 1; i >= 0; i--)
			{
				var activeEnemy = _enemiesModel.ActiveEnemies[i];
				if (activeEnemy.HitPointsComponent.IsHitPointsExists())
					continue;

				enemyPoolModel.UnspawnEnemy(activeEnemy.gameObject);
				_enemiesModel.ActiveEnemies.Remove(activeEnemy);
			}
		}

		private void SpawnEnemies()
		{
			if (_lastCheckTimestamp == Utils.NOT_INITIALIZED_DEFAULT_TIME)
			{
				_lastCheckTimestamp = Time.realtimeSinceStartup;
				return;
			}

			if (Time.realtimeSinceStartup - _lastCheckTimestamp < SYSTEM_TIMEOUT)
				return;

			_lastCheckTimestamp = Utils.NOT_INITIALIZED_DEFAULT_TIME;

			var enemy = enemyPoolModel.SpawnEnemy();
			if (enemy != null)
				_enemiesModel.ActiveEnemies.Add(enemy);
		}
	}
}