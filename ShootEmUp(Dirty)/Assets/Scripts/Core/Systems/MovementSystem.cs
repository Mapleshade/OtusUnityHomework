using UnityEngine;

namespace ShootEmUp
{
    public class MovementSystem : IFixedUpdate
    {
        private readonly GameContext _gameContext;
        private readonly GameSettings _gameSettings;
        private readonly EnemiesModel _enemiesModel;

        public MovementSystem(GameContext gameContext,
            EnemiesModel enemiesModel,
            GameSettings gameSettings)
        {
            _gameContext = gameContext;
            _enemiesModel = enemiesModel;
            _gameSettings = gameSettings;
        }

        public void CustomFixedUpdate()
        {
            foreach (var characterEntity in _gameContext.CharacterEntities)
            {
                if (!characterEntity.TeamComponent.IsPlayer)
                    continue;

                var velocity = new Vector2(characterEntity.InputComponent.HorizontalDirection, 0);
                characterEntity.RigidbodyComponent.Rigidbody2D.MoveByRigidbodyVelocity(velocity * Time.fixedDeltaTime, _gameSettings.PlayerSpeed);
            }

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
