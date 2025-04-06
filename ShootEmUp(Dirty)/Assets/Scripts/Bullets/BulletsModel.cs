using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
	public sealed class BulletsModel : IInitializable
	{
		private readonly Transform _poolTransform;
		private readonly Transform _worldTransform;
		private readonly GameSettings _gameSettings;

		private readonly Queue<BulletEntity> _bulletPool = new();
		private readonly HashSet<BulletEntity> _activeBullets = new();
		private readonly List<BulletEntity> _cache = new();

		public BulletsModel(Transform poolTransform,
			Transform worldTransform,
			GameSettings gameSettings)
		{
			_poolTransform = poolTransform;
			_worldTransform = worldTransform;
			_gameSettings = gameSettings;
		}

		public void UpdateCache()
		{
			_cache.Clear();
			_cache.AddRange(_activeBullets);

			for (int i = 0, count = _cache.Count; i < count; i++)
			{
				var bullet = _cache[i];
				if (!bullet.transform.position
						.InBounds(_gameSettings.LeftBorder,
							_gameSettings.RightBorder,
							_gameSettings.DownBorder,
							_gameSettings.TopBorder))
				{
					RemoveBullet(bullet);
				}
			}
		}

		public void FlyBulletByArgs(BulletArgs args)
		{
			if (_bulletPool.TryDequeue(out var bullet))
				bullet.transform.SetParent(_worldTransform);
			else
				bullet = GameObject.Instantiate(_gameSettings.BulletEntityPrefab, _worldTransform);

			var bulletView = bullet.BulletViewComponent;
			var bulletData = bullet.BulletDataComponent;
			var bulletRigidBody = bullet.RigidbodyComponent;

			bulletView.Transform.position = args.Position;
			bulletView.SpriteRenderer.color = args.Color;
			bulletView.GameObject.layer = args.PhysicsLayer;
			bulletData.SetBulletData(args.IsPlayer, args.Damage);
			bulletRigidBody.Rigidbody2D.velocity = args.Velocity;

			if (_activeBullets.Add(bullet))
				bullet.OnCollisionEntered += OnBulletCollision;
		}

		private void OnBulletCollision(BulletEntity bulletEntity, Collision2D collision)
		{
			BulletUtils.DealDamage(bulletEntity, collision.gameObject);
			RemoveBullet(bulletEntity);
		}

		private void RemoveBullet(BulletEntity bulletEntity)
		{
			if (!_activeBullets.Remove(bulletEntity))
				return;

			bulletEntity.OnCollisionEntered -= OnBulletCollision;
			bulletEntity.transform.SetParent(_poolTransform);
			_bulletPool.Enqueue(bulletEntity);
		}

		public void Initialize()
		{
			for (var i = 0; i < _gameSettings.InitialCount; i++)
			{
				var bullet = GameObject.Instantiate(_gameSettings.BulletEntityPrefab, _poolTransform);
				_bulletPool.Enqueue(bullet);
			}
		}
	}
}