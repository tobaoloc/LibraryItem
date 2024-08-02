using System;
using System.Collections;

namespace AutomatedTesting
{
	public class ClassTestData : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			yield return new object[] { "Test DVD1", "Test Director1", true, new DateOnly(2021, 2, 2), 120 };
            yield return new object[] { "Test DVD2", "Test Director2", true, new DateOnly(2022, 2, 2), 120 };
            yield return new object[] { "Test DVD3", "Test Director3", true, new DateOnly(2023, 2, 2), 120 };
        }
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}

