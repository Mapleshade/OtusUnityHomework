using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
	public class EnemyCharacterEntity : MonoBehaviour
	{
		[SerializeField]
		private WeaponComponent _weaponComponent;
		[SerializeField]
		private HitPointsComponent _hitPointsComponent;
		[SerializeField]
		private RigidbodyComponent _rigidbodyComponent;
		[SerializeField]
		private TeamComponent _teamComponent;
		[SerializeField]
		private EnemyMoveComponent _enemyMoveComponent;
		[SerializeField]
		private EnemyAttackComponent _enemyAttackComponent;
		public RigidbodyComponent RigidbodyComponent => _rigidbodyComponent;
		public TeamComponent TeamComponent => _teamComponent;
		public WeaponComponent WeaponComponent => _weaponComponent;
		public HitPointsComponent HitPointsComponent => _hitPointsComponent;
		public EnemyMoveComponent EnemyMoveComponent => _enemyMoveComponent;
		public EnemyAttackComponent EnemyAttackComponent => _enemyAttackComponent;
	}
}