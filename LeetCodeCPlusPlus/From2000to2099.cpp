#include "From2000to2099.h"
#include <vector>
#include <algorithm>
#include <unordered_set>
#include <iostream>

/// <summary>
/// 2009. Minimum Number of Operations to Make Array Continuous
/// </summary>
int From2000to2099::minOperations(std::vector<int>& nums)
{
    int initialN = nums.size();
    int ans = initialN;
    std::unordered_set<int> hs;

    for (int i = 0; i < initialN; i++)
    {
        hs.insert(nums[i]);
    }
    
    int uniqueSize = hs.size();
    std::vector<int> newArray = {};

    std::for_each(
        hs.begin(),
        hs.end(),
        [&](int n) {
            newArray.push_back(n);
        }
    );

    std::sort(newArray.begin(), newArray.end());

    int j = 0;
    for (int i = 0; i < uniqueSize; i++)
    {
        int vMax = newArray[i] + initialN;
        while (j < uniqueSize && newArray[j] < vMax)
        {
            j++;
        }

        ans = std::min(ans, initialN - j + i);
    }

    return ans;
}