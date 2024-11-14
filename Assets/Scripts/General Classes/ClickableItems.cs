public class ClickableItems : GameItem
{
    public bool isClickable;

    // Constructor
    public ClickableItems(string name) : base(name)
    {
        isClickable = true;
    }
}
