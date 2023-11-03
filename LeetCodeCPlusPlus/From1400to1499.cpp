#include "From1400to1499.h"

std::vector<std::string> From1400to1499::buildArray(std::vector<int>& target, int n)
{
    std::vector<std::string> result;
    int currentNumber = 1;

    for (int item : target)
    {
        while (currentNumber < item)
        {
            result.push_back("Push");
            result.push_back("Pop");
            currentNumber++;
        }

        result.push_back("Push");
        currentNumber++;
    }

    return result;
}
