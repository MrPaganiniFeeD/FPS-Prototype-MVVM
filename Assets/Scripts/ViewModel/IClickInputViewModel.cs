namespace ViewModel
{
    public interface IClickInputViewModel : IViewModel
    {
        void LeftClick(float delta);
        void RightClick(float delta);
    }
}