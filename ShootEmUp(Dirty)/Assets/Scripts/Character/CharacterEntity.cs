using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public sealed class CharacterEntity : MonoBehaviour
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
        private InputComponent _inputComponent;
        [SerializeField]
        private FireComponent _fireComponent;
        public RigidbodyComponent RigidbodyComponent => _rigidbodyComponent;
        public TeamComponent TeamComponent => _teamComponent;
        public InputComponent InputComponent => _inputComponent;
        public FireComponent FireComponent => _fireComponent;
        public WeaponComponent WeaponComponent => _weaponComponent;
        public HitPointsComponent HitPointsComponent => _hitPointsComponent;
    }
}