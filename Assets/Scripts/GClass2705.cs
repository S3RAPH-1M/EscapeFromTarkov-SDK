using EFT;

public class GClass2705
{
	public enum EInteractState
	{
		None = 0,
		IsEntering = 1,
		Entered = 2,
		IsExiting = 3,
		Exited = 4
	}

	private EInteractState einteractState_0;

	private Player player_0;

	public EInteractState InteractState => einteractState_0;

	public Player InteractingPlayer => player_0;
}
