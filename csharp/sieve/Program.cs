using System.Collections.Generic;

class Program {
	static IEnumerable<int> Generate() {
		for (var i = 2; ; i++) {
			yield return i;
		}
	}

	static IEnumerable<int> Filter(IEnumerable<int> input, int prime) {
		foreach (var i in input) {
			if (i % prime != 0) {
				yield return i;
			}
		}
	}

	static void Main(string[] args) {
		var ns = Generate();
		for (var i = 0; i < 100; i++) {
			var nse = ns.GetEnumerator();
			nse.MoveNext();
			var p = nse.Current;
			System.Console.Out.WriteLine(p);
			ns = Filter(ns, p);
		}
	}
}
