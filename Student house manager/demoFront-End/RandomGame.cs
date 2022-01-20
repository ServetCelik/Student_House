using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoFront_End
{
    public class RandomGame
    {

        List<RandomGame> listOfTen = new List<RandomGame>();


        private string tenName;

        public RandomGame(string tenName)
        {
            this.TenName = tenName;
        }

        public string TenName
        {
            get { return this.tenName; }
            set { this.tenName = value; }
        }

        public void AddTen(RandomGame tenName)
        {

            listOfTen.Add(tenName);
        }

        public string GetInfo()
        {
            return $"{tenName}";
        }
    }
}
