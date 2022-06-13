using System;

public interface IRepository<in T>
{
   event Action OnChanged;
   int GetLevel(T resource);
   void Use(T resource);
}
