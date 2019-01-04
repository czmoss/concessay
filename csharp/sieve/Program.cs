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

	static IEnumerable<int> Sieve() {
		var ns = Generate();
		for (;;) {
			var nse = ns.GetEnumerator();
			nse.MoveNext();
			var p = nse.Current;
			yield return p;
			ns = Filter(ns, p);
		}
	}

	static void Main(string[] args) {
		var primes = Sieve().GetEnumerator();
		for (var i = 0; i < 100; i++) {
			primes.MoveNext();
			System.Console.Out.WriteLine(primes.Current);
		}
	}
}
