using ViewModel;

namespace View
{
    public interface IView<T>
    {
        T ViewModel { get; }

        public void Init();
    }
}