using ToDo.Common.Interfaces.Special;

namespace ToDo.Common.Implementations.Special
{
	public class Container<T> : IContainer<T>
	{
		T modObject;

		public Container(T objForContainer)
		{
			modObject = objForContainer;
		}

		public T ContainerObject
		{
			get 
			{
				return modObject;
			}
		}
	}
}
