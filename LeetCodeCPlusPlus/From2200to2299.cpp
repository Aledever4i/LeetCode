#include "From2200to2299.h"

int From2200to2299::averageOfSubtree(TreeNode* root)
{
    if (root == nullptr)
    {
        return averageOfSubtreeResult;
    }

    averageOfSubtreeGetChild(root);
    return averageOfSubtreeResult;
}

std::pair<int, int> From2200to2299::averageOfSubtreeGetChild(TreeNode* childRoot)
{
    int sumLeft = 0, countLeft = 0;
    if (childRoot->left != nullptr)
    {
        auto l = averageOfSubtreeGetChild(childRoot->left);
        sumLeft = l.first;
        countLeft = l.second;
    }

    int sumRight = 0, countRight = 0;
    if (childRoot->right != nullptr)
    {
        auto r = averageOfSubtreeGetChild(childRoot->right);
        sumRight = r.first;
        countRight = r.second;
    }

    int unionSum = sumLeft + sumRight + childRoot->val;
    int unionCount = countLeft + countRight + 1;
    if (unionSum / unionCount == childRoot->val)
    {
        averageOfSubtreeResult++;
    }

    return { unionSum, unionCount };
}