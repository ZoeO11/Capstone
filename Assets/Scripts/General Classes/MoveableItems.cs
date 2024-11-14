public class MoveableItems : GameItem
{
    public bool isMovable;   // A flag to check if the item can be moved

    // Constructor
    public MoveableItems(string name) : base(name)
    {
        isMovable = true;  // Default to movable
    }
}