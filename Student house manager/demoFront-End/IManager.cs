using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoFront_End
{
    interface IManager
    {
        void AddToHouseholdList(List<object> parameterList);
        void DeleteFromHouseholdList(int selectedItem);
        void EditHouseholdList(List<object> parameterList, int selectedItem);
    }
}
