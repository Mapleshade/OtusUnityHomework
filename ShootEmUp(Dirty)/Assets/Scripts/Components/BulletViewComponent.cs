using UnityEngine;

namespace ShootEmUp
{
	public class BulletViewComponent : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _spriteRenderer;
		public Transform Transform => transform;
		public GameObject GameObject => gameObject;
		public SpriteRenderer SpriteRenderer => _spriteRenderer;
	}
}