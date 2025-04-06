using UnityEngine;

namespace ShootEmUp
{
    public class MovementSystem : IFixedUpdate
    {
        private readonly CharacterEntity _characterEntity;
        private readonly GameSettings _gameSettings;
        private readonly EnemiesModel _enemiesModel;

        public MovementSystem(EnemiesModel enemiesModel,
            GameSettings gameSettings,
            CharacterEntity characterEntity)
        {
            _enemiesModel = enemiesModel;
            _gameSettings = gameSettings;
            _characterEntity = characterEntity;
        }

        public void CustomFixedUpdate()
        {
            if (!_characterEntity.TeamComponent.IsPlayer)
                    return;

            var velocity = new Vector2(_characterEntity.InputComponent.HorizontalDirection, 0);
            _characterEntity.RigidbodyComponent.Rigidbody2D.MoveByRigidbodyVelocity(velocity * Time.fixedDeltaTime, _gameSettings.PlayerSpeed);

            foreach (var activeEnemy in _enemiesModel.ActiveEnemies)
            {
                if (activeEnemy.EnemyMoveComponent.IsReached)
                    continue;
            
                var vector = activeEnemy.EnemyMoveComponent.Destination - (Vector2) activeEnemy.transform.position;
                if (vector.magnitude <= 0.25f)
                {
                    activeEnemy.EnemyMoveComponent.SetReached();
                    continue;
                }

                var direction = vector.normalized * Time.fixedDeltaTime;
                activeEnemy.RigidbodyComponent.Rigidbody2D.MoveByRigidbodyVelocity(direction, _gameSettings.EnemySpeed);
            }
        }
    }
}
