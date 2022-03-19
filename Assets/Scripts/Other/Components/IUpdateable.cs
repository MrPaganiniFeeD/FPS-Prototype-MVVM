namespace Components
{
    public interface IUpdateable
    {
        void Update(float deltaTime);
        void FixedUpdate(float deltaTime);
    }
}