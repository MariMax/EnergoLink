using System.Collections.Generic;

namespace CloudAskue.BusinessLogic.Contracts
{
    public class Maket
    {
        public List<Area> Areas { get; set; }

        public Maket()
        {
            Areas=new List<Area>();
        }
    }
}
