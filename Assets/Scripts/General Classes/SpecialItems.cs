public class SpecialItems : ClickableItems
{
    public bool isSpecial;

    // Constructor
    public SpecialItems(string name) : base(name)
    {
        isSpecial = true;
    }
}
