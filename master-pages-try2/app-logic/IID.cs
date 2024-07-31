using System;

namespace master_pages_try2.app_logic
{
    public interface IIDSingleton : IID { }
    public interface IIDScoped : IID { }
    public interface IIDTransient : IID { }

    public interface IID
    {
        Guid Value { get; }
    }

    public class ID : IIDSingleton, IIDScoped, IIDTransient
    {
        public Guid Value { get; private set; } = Guid.NewGuid();
        public int x = 10;
    }
}
