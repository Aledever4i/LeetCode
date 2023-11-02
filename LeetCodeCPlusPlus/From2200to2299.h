#pragma once
#include "TreeNode.h"
#include "Tuple";

class From2200to2299
{
	public:
		int averageOfSubtreeResult = 0;

		/// <summary>
		/// 2265. Count Nodes Equal to Average of Subtree
		/// </summary>
		int averageOfSubtree(TreeNode* root);

	private:
		std::pair<int, int> averageOfSubtreeGetChild(TreeNode* childRoot);
};

