public class Repetable: Pane
{
    public Repetable()
    {
        Item = new List ();
    }

    public List GetItems()
    {
        return (List)Item;
    }

    public void Remove(ViewItem model)
    {
        GetItems().ListItems.Remove(model);
    }

    public void Add(ViewItem model)
    {
        GetItems().ListItems.Add(model);
    }
}