using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ShootEmUp
{
	public class GameInstaller : MonoInstaller<GameInstaller>
	{
		[SerializeField]
		private GameSettings _gameSettings;
		[SerializeField]
		private GameLifeTimeSystem _gameLifeTimeSystem;
		[SerializeField]
		private Transform _bulletsPoolTransform;
		[SerializeField]
		private Transform _enemiesPoolTransform;
		[SerializeField]
		private Transform _worldTransform;
		[SerializeField]
		private CharacterEntity _characterEntity;

		[Header("Views")]
		[SerializeField]
		private ViewLevelBackground _viewLevelBackground;

		public override void InstallBindings()
		{
			Container.BindInstance(_characterEntity).AsSingle().NonLazy();
			Container.BindInstance(_gameSettings).AsSingle().NonLazy();
			Container.BindInstance(_viewLevelBackground).AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<PresenterLevelBackground>().AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<BulletsModel>().AsSingle().WithArguments(_bulletsPoolTransform, _worldTransform, _gameSettings).NonLazy();
			Container.BindInterfacesAndSelfTo<EnemiesModel>().AsSingle().NonLazy();
			Container.BindInterfacesAndSelfTo<EnemyPoolModel>().AsSingle().WithArguments(_gameSettings, _enemiesPoolTransform, _worldTransform, _characterEntity).NonLazy();

			Container.Bind<List<IFixedUpdate>>().AsSingle().NonLazy();
			Container.Bind<List<IUpdate>>().AsSingle().NonLazy();

			Container.BindInterfacesAndSelfTo<LevelSystem>().AsSingle().OnInstantiated<LevelSystem>((_, system) => Container.Resolve<List<IFixedUpdate>>().Add(system)).NonLazy();
			Container.BindInterfacesAndSelfTo<InputSystem>().AsSingle().OnInstantiated<InputSystem>((_, system) => Container.Resolve<List<IUpdate>>().Add(system)).NonLazy();
			Container.BindInterfacesAndSelfTo<EnemyLifeTimeSystem>().AsSingle().OnInstantiated<EnemyLifeTimeSystem>((_, system) => Container.Resolve<List<IUpdate>>().Add(system)).NonLazy();
			Container.BindInterfacesAndSelfTo<MovementSystem>().AsSingle().OnInstantiated<MovementSystem>((_, system) => Container.Resolve<List<IFixedUpdate>>().Add(system)).NonLazy();
			Container.BindInterfacesAndSelfTo<ShootingSystem>().AsSingle().OnInstantiated<ShootingSystem>((_, system) => Container.Resolve<List<IFixedUpdate>>().Add(system)).NonLazy();
			Container.BindInterfacesAndSelfTo<GameFinishSystem>().AsSingle().OnInstantiated<GameFinishSystem>((_, system) => Container.Resolve<List<IUpdate>>().Add(system)).NonLazy();

			Container.BindInstance(_gameLifeTimeSystem);
		}
	}
}