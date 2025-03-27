using UnityEngine;

namespace ShootEmUp
{
	public sealed class RigidbodyComponent : MonoBehaviour
	{
		[SerializeField]
		private new Rigidbody2D rigidbody2D;
		public Rigidbody2D Rigidbody2D => rigidbody2D;
	}
}