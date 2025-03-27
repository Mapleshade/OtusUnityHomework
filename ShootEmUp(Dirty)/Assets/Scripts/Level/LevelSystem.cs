namespace ShootEmUp
{
	public class LevelSystem : IFixedUpdate
	{
		private readonly PresenterLevelBackground _presenterLevelBackground;

		public LevelSystem(PresenterLevelBackground presenterLevelBackground)
		{
			_presenterLevelBackground = presenterLevelBackground;
		}

		public void CustomFixedUpdate()
		{
			_presenterLevelBackground.Update();
		}
	}
}