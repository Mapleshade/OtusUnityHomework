using UnityEngine;

namespace ShootEmUp
{
	public sealed class ViewLevelBackground : MonoBehaviour
	{
		[SerializeField]
		private Transform _levelTransform;

		public Transform LevelTransform => _levelTransform;
	}
}