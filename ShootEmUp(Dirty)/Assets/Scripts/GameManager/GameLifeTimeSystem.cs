using UnityEngine;

namespace ShootEmUp
{
	public sealed class GameLifeTimeSystem : MonoBehaviour
	{
		private GameContext _gameContext;

		public void SetGameContext(GameContext gameContext)
		{
			_gameContext = gameContext;
		}

		private void Start()
		{
			foreach (var initializable in _gameContext.Initializables)
				initializable.Initialize();
		}

		private void Update()
		{
			foreach (var update in _gameContext.Updates)
				update.CustomUpdate();
		}

		private void FixedUpdate()
		{
			foreach (var fixedUpdate in _gameContext.FixedUpdates)
				fixedUpdate.CustomFixedUpdate();
		}

		private void OnApplicationQuit()
		{
			foreach (var disposable in _gameContext.Disposables)
				disposable.Dispose();
		}
	}
}