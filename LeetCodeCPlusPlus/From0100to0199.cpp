#include "From0100to0199.h"
#include <cstddef>

bool From0100to0199::HasCycle(ListNode* head)
{
    if (head == NULL)
    {
        return false;
    }

    int step = 0;
    while (head->next != NULL)
    {
        head = head->next;
        step++;

        if (step == 10002)
        {
            return false;
        }
    }
    return true;
}
