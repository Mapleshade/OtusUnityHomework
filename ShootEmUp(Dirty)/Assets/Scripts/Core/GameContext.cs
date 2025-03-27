using System.Collections.Generic;

namespace ShootEmUp
{
	public class GameContext
	{
		public List<IInitializable> Initializables { get; } = new();
		public List<IFixedUpdate> FixedUpdates { get; } = new();
		public List<IUpdate> Updates { get; } = new();
		public List<IDisposable> Disposables { get; } = new();
		public List<CharacterEntity> CharacterEntities { get; } = new();
	}
}