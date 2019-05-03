using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Field
    {
        Boolean isAlive;

        public Field(Boolean living)
        {
            isAlive = living;
        }

        public void setAlive(Boolean living)
        {
            isAlive = living;
        }

        public Boolean getStatus() 
        {
            return isAlive;
        }
    }
    
}
