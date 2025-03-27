using System;
using UnityEngine;

namespace ShootEmUp
{
	public sealed class BulletEntity : MonoBehaviour
	{
		public event Action<BulletEntity, Collision2D> OnCollisionEntered;

		[SerializeField]
		private RigidbodyComponent _rigidbodyComponent;
		[SerializeField]
		private BulletDataComponent _bulletDataComponent;
		[SerializeField]
		private BulletViewComponent _bulletViewComponent;

		public RigidbodyComponent RigidbodyComponent => _rigidbodyComponent;
		public BulletDataComponent BulletDataComponent => _bulletDataComponent;
		public BulletViewComponent BulletViewComponent => _bulletViewComponent;

		private void OnCollisionEnter2D(Collision2D collision)
		{
			OnCollisionEntered?.Invoke(this, collision);
		}
	}
}