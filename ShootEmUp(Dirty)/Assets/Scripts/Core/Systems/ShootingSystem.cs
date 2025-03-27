using UnityEngine;

namespace ShootEmUp
{
	public class ShootingSystem : IFixedUpdate
	{
		private readonly GameContext _gameContext;
		private readonly GameSettings _gameSettings;
		private readonly BulletsModel _bulletsModel;
		private readonly EnemiesModel _enemiesModel;

		public ShootingSystem(GameContext gameContext,
			BulletsModel bulletsModel,
			EnemiesModel enemiesModel,
			GameSettings gameSettings)
		{
			_gameContext = gameContext;
			_bulletsModel = bulletsModel;
			_enemiesModel = enemiesModel;
			_gameSettings = gameSettings;
		}

		public void CustomFixedUpdate()
		{
			CheckFiredPlayers();
			CheckFiredEnemies();
			_bulletsModel.UpdateCache();
		}

		private void CheckFiredPlayers()
		{
			foreach (var characterEntity in _gameContext.CharacterEntities)
			{
				if (!characterEntity.FireComponent.FireRequired)
					continue;

				if (!characterEntity.TeamComponent.IsPlayer)
					continue;

				var weapon = characterEntity.WeaponComponent;
				var direction = weapon.Rotation * Vector3.up * weapon.BulletConfig.Speed;
				Fire(weapon.Position, direction, characterEntity.TeamComponent.IsPlayer, weapon.BulletConfig);
				characterEntity.FireComponent.FireRequired = false;
			}
		}

		private void CheckFiredEnemies()
		{
			foreach (var activeEnemy in _enemiesModel.ActiveEnemies)
			{
				if (!activeEnemy.EnemyMoveComponent.IsReached)
					continue;

				if (!activeEnemy.EnemyAttackComponent.Target.GetComponent<HitPointsComponent>().IsHitPointsExists())
					continue;

				activeEnemy.EnemyAttackComponent.SetCurrentTime(activeEnemy.EnemyAttackComponent.CurrentTime -
																Time.fixedDeltaTime);
				if (activeEnemy.EnemyAttackComponent.CurrentTime > 0)
					continue;

				var weapon = activeEnemy.WeaponComponent;
				var vector = (Vector2) activeEnemy.EnemyAttackComponent.Target.transform.position - weapon.Position;
				var direction = vector.normalized;
				Fire(weapon.Position, direction, activeEnemy.TeamComponent.IsPlayer, weapon.BulletConfig);
				activeEnemy.EnemyAttackComponent.SetCurrentTime(activeEnemy.EnemyAttackComponent.CurrentTime +
																_gameSettings.EnemyCountdown);
			}
		}

		private void Fire(Vector3 weaponPos, Vector2 direction, bool isPlayer, BulletConfig bulletConfig)
		{
			_bulletsModel.FlyBulletByArgs(new BulletArgs
			{
				IsPlayer = isPlayer,
				PhysicsLayer = (int) bulletConfig.PhysicsLayer,
				Color = bulletConfig.Color,
				Damage = bulletConfig.Damage,
				Position = weaponPos,
				Velocity = direction
			});
		}
	}
}