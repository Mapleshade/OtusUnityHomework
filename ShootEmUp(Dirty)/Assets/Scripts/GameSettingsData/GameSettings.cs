using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{

	[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings", order = 1)]
	public class GameSettings : ScriptableObject
	{
		[Header("level border data")] [SerializeField]
		private float _leftBorder;

		[SerializeField]
		private float _rightBorder;
		[SerializeField]
		private float _downBorder;
		[SerializeField]
		private float _topBorder;

		[Header("level background data")]
		[SerializeField]
		private float _startPositionY;

		[SerializeField]
		private float _endPositionY;
		[SerializeField]
		private float _movingSpeedY;

		[Header("Bullets data")]
		[SerializeField]
		private int _initialCount = 50;
		[FormerlySerializedAs("_bulletPrefab")] [SerializeField]
		private BulletEntity bulletEntityPrefab;

		[Header("Enemy data")]
		[SerializeField]
		private GameObject _enemyPrefab;
		[SerializeField]
		private Vector3[] _spawnPositions;
		[SerializeField]
		private Vector3[] _attackPositions;
		[SerializeField]
		private int _initialEnemyCount = 7;
		[SerializeField]
		private int _enemySpeed = 7;
		[SerializeField]
		private int _enemyCountdown = 1;

		[Header("Player data")]
		[SerializeField]
		private int _playerSpeed = 5;

		public float LeftBorder => _leftBorder;
		public float RightBorder => _rightBorder;
		public float DownBorder => _downBorder;
		public float TopBorder => _topBorder;
		public float StartPositionY => _startPositionY;
		public float EndPositionY => _endPositionY;
		public float MovingSpeedY => _movingSpeedY;
		public int InitialCount => _initialCount;
		public BulletEntity BulletEntityPrefab => bulletEntityPrefab;
		public GameObject EnemyPrefab => _enemyPrefab;
		public Vector3[] SpawnPositions => _spawnPositions;
		public Vector3[] AttackPositions => _attackPositions;
		public int InitialEnemyCount => _initialEnemyCount;
		public int EnemySpeed => _enemySpeed;
		public int PlayerSpeed => _playerSpeed;
		public int EnemyCountdown => _enemyCountdown;
	}
}