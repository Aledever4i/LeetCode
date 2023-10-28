#include "from1200to1299.h"


from1200to1299::from1200to1299()
{
};

/// <summary>
/// 1220. Count Vowels Permutation
/// </summary>
int from1200to1299::countVowelPermutation(int n) {
	int mod = 1000000007;
	long long a = 1, e = 1, i = 1, o = 1, u = 1;

	for (int j = 1; j < n; j++)
	{
		long long next_a = e;
		long long next_e = (a + i) % mod;
		long long next_i = (a + e + o + u) % mod;
		long long next_o = (i + u) % mod;
		long long next_u = a;

		a = next_a;
		e = next_e;
		i = next_i;
		o = next_o;
		u = next_u;
	}

	return (a + e + i + o + u) % mod;
};