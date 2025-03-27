using UnityEngine;

namespace ShootEmUp
{
	internal static class BulletUtils
	{
		internal static void DealDamage(BulletEntity bulletEntity, GameObject other)
		{
			if (!other.TryGetComponent(out TeamComponent team))
				return;

			var bulletDataComponent = bulletEntity.BulletDataComponent;
			if (bulletDataComponent.IsPlayer == team.IsPlayer)
				return;

			if (other.TryGetComponent(out HitPointsComponent hitPoints))
				hitPoints.TakeDamage(bulletDataComponent.Damage);
		}
	}
}