using UnityEngine;

namespace ShootEmUp
{
	public sealed class HitPointsComponent : MonoBehaviour
	{
		[SerializeField]
		private int _hitPoints;

		public bool IsHitPointsExists()
		{
			return _hitPoints > 0;
		}

		public void TakeDamage(int damage)
		{
			_hitPoints -= damage;
		}
	}
}