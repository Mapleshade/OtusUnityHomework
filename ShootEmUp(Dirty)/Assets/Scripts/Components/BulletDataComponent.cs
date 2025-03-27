using UnityEngine;

namespace ShootEmUp
{
	public class BulletDataComponent : MonoBehaviour
	{
		public bool IsPlayer { get; private set; }
		public int Damage { get; private set; }

		public void SetBulletData(bool isPlayer, int damage)
		{
			IsPlayer = isPlayer;
			Damage = damage;
		}
	}
}