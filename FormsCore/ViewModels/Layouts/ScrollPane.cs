public class ScrollPane: ViewItem
{

    ///горизонтальная прокрутка или вертикальная
    public bool IsHorizontal { get; set; }

    public float ScrollSize { get; set; }


    public ScrollPane(){
        this.ClassList.Add("front-pane");

        Changed = false;
    }

}
