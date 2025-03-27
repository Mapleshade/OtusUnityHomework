using UnityEngine;

namespace ShootEmUp
{
	public sealed class WeaponComponent : MonoBehaviour
	{
		[SerializeField]
		private Transform firePoint;
		[SerializeField]
		private BulletConfig _bulletConfig;

		public Vector2 Position
		{
			get { return this.firePoint.position; }
		}

		public Quaternion Rotation
		{
			get { return this.firePoint.rotation; }
		}

		public BulletConfig BulletConfig => _bulletConfig;
	}
}