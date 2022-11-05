using System.Collections.Generic;
using Code.Main.Interfaces;

namespace Code.Main
{
  public sealed class Controllers :
    IControllers
  {
    private readonly List<IController> _controllers = new List<IController>(100);
    private readonly List<ITick> _ticks = new List<ITick>(100);
    private readonly List<IFixedTick> _fixedTicks = new List<IFixedTick>(100);
    private readonly List<ILateTick> _lateTicks = new List<ILateTick>(5);

    public void Add(IController controller)
    {
      _controllers.Add(controller);
      if (controller is ITick tick) _ticks.Add(tick);
      if (controller is IFixedTick fixedTick) _fixedTicks.Add(fixedTick);
      if (controller is ILateTick lateTick) _lateTicks.Add(lateTick);
    }

    public void Remove(IController controller)
    {
      _controllers.Remove(controller);
      if (controller is ITick tick) _ticks.Add(tick);
      if (controller is IFixedTick fixedTick) _fixedTicks.Add(fixedTick);
      if (controller is ILateTick lateTick) _lateTicks.Add(lateTick);
    }

    public void Tick(float delta)
    {
      var count = _ticks.Count;
      for (var i = 0; i < count; i++)
      {
        _ticks[i].Tick(delta);
      }
    }

    public void FixedTick(float delta)
    {
      var count = _fixedTicks.Count;
      for (var i = 0; i < count; i++)
      {
        _fixedTicks[i].FixedTick(delta);
      }
    }

    public void LateTick(float delta)
    {
      var count = _lateTicks.Count;
      for (var i = 0; i < count; i++)
      {
        _lateTicks[i].LateTick(delta);
      }
    }
  }
}