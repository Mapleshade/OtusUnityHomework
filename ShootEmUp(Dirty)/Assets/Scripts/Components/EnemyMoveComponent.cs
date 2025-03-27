using UnityEngine;

namespace ShootEmUp
{
	public sealed class EnemyMoveComponent : MonoBehaviour
	{
		private Vector2 _destination;
		private bool _isReached;

		public Vector2 Destination => _destination;

		public bool IsReached => _isReached;

		public void SetDestination(Vector2 endPoint)
		{
			_destination = endPoint;
			_isReached = false;
		}

		public void SetReached()
		{
			_isReached = true;
		}
	}
}