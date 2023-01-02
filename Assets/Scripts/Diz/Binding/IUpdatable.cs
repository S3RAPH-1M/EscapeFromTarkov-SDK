using System;

namespace Diz.Binding
{
	// Token: 0x02002422 RID: 9250
	public interface IUpdatable<in T> where T : IUpdatable<T>
	{
		// Token: 0x0600D1C8 RID: 53704
		bool Compare(T other);

		// Token: 0x0600D1C9 RID: 53705
		void UpdateFromAnotherItem(T other);
	}
}
