using System;

namespace Diz.Binding
{
	// Token: 0x02002408 RID: 9224
	public interface IBindable<out T>
	{
		// Token: 0x0600D139 RID: 53561
		Action Bind(Action<T> handler);

		// Token: 0x0600D13A RID: 53562
		Action Subscribe(Action<T> handler);

		// Token: 0x0600D13B RID: 53563

		// Token: 0x17001BE2 RID: 7138
		// (get) Token: 0x0600D13C RID: 53564
		T Value { get; }
	}
}
