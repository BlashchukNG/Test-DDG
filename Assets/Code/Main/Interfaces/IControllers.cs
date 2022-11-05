namespace Code.Main.Interfaces
{
  public interface IControllers
  {
    void Add(IController controller);
    void Remove(IController controller);
    void Tick(float delta);
    void FixedTick(float delta);
    void LateTick(float delta);
  }
}