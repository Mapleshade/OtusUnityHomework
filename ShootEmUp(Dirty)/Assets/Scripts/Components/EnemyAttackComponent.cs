using UnityEngine;

namespace ShootEmUp
{
	public sealed class EnemyAttackComponent : MonoBehaviour
	{
		private GameObject _target;
		private float _currentTime;

		public GameObject Target => _target;
		public float CurrentTime => _currentTime;

		public void SetTarget(GameObject target)
		{
			_target = target;
		}

		public void SetCurrentTime(float currentTime)
		{
			_currentTime = currentTime;
		}
	}
}